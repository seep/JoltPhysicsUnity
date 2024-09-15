using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        private static Dictionary<IntPtr, IContactListener> managedContactListeners = new ();

        public static NativeHandle<JPH_ContactListener> JPH_ContactListener_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_ContactListener_Create());
        }

        public static void JPH_ContactListener_SetProcs(NativeHandle<JPH_ContactListener> listener, IContactListener managed)
        {
            UnsafeBindings.JPH_ContactListener_SetProcs(listener, UnsafeContactListenerProcs, listener);

            // JoltPhysicsSharp uses GCHandle with some delegate indirection to pass a closure pointer as the native
            // "user data" but my understanding is that we cannot safely do a "reverse lookup" of the managed object
            // without pinning the GC handle and reducing GC performance. If there is a better way to maintain a
            // reference to the managed interface than a static dictionary, please file a PR!

            managedContactListeners[(nint) listener.IntoPointer()] = managed;
        }

        public static void JPH_ContactListener_Destroy(NativeHandle<JPH_ContactListener> listener)
        {
            managedContactListeners.Remove((nint) listener.IntoPointer());

            UnsafeBindings.JPH_ContactListener_Destroy(listener.IntoPointer());

            listener.Dispose();
        }

        private static readonly JPH_ContactListener_Procs UnsafeContactListenerProcs = new JPH_ContactListener_Procs {
            OnContactValidate  = Marshal.GetFunctionPointerForDelegate((UnsafeContactValidate) UnsafeContactValidateCallback),
            OnContactAdded     = Marshal.GetFunctionPointerForDelegate((UnsafeContactAdded) UnsafeContactAddedCallback),
            OnContactRemoved   = Marshal.GetFunctionPointerForDelegate((UnsafeContactRemoved) UnsafeContactRemovedCallback),
            OnContactPersisted = Marshal.GetFunctionPointerForDelegate((UnsafeContactPersisted) UnsafeContactPersistedCallback),
        };

        private delegate ValidateResult UnsafeContactValidate(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB, double3* offset, CollideShapeResult* result);

        private delegate void UnsafeContactAdded(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB);

        private delegate void UnsafeContactPersisted(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB);

        private delegate void UnsafeContactRemoved(IntPtr udata, SubShapeIDPair* pair);

        private static ValidateResult UnsafeContactValidateCallback(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB, double3* offset, CollideShapeResult* result)
        {
            try
            {
                return managedContactListeners[udata]?.OnContactValidate() ?? ValidateResult.AcceptContact;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            return ValidateResult.AcceptContact;
        }

        private static void UnsafeContactAddedCallback(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB)
        {
            try
            {
                managedContactListeners[udata]?.OnContactAdded();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private static void UnsafeContactRemovedCallback(IntPtr udata, SubShapeIDPair* pair)
        {
            try
            {
                managedContactListeners[udata]?.OnContactRemoved();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private static void UnsafeContactPersistedCallback(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB)
        {
            try
            {
                managedContactListeners[udata]?.OnContactPersisted();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
