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

        public static NativeHandle<JPH_ContactListener> JPH_ContactListener_Create(JPH_ContactListener_Procs procs)
        {
            return CreateHandle(UnsafeBindings.JPH_ContactListener_Create(&procs, userData: null)); // TODO forward userData param
        }

        public static void JPH_ContactListener_Destroy(NativeHandle<JPH_ContactListener> listener)
        {
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
