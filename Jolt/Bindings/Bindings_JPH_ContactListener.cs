using System;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_ContactListener> JPH_ContactListener_Create(IContactListener listener)
        {
            AssertInitialized();

            // Getting the listeners to work requires a lot of indirection, because the listeners are represented as
            // heap objects in the native plugin with their own lifetimes. The joltc constructor for the listener takes
            // a "user data" parameter that lets us provide context to the callbacks when they are invoked.
            //
            // During initialization, we provide static callbacks to joltc. When we construct a new native listener, we
            // also create a GCHandle for the associated managed listener. These are tracked in the ManagedReference
            // static class. When Jolt invokes the native listener, it invokes the joltc static listener, which invokes
            // our own static listeners with the GCHandle parameter, which we dereference to obtain the user listener.

            var gch = GCHandle.Alloc(listener);
            var ptr = GCHandle.ToIntPtr(gch);

            var handle = CreateHandle(UnsafeBindings.JPH_ContactListener_Create(ptr));

            ManagedReference.Add(handle, gch);

            return handle;
        }

        public static void JPH_ContactListener_Destroy(NativeHandle<JPH_ContactListener> listener)
        {
            AssertInitialized();

            if (ManagedReference.Remove(listener, out var gch))
            {
                gch.Free();
            }
            else
            {
                Debug.LogError("Missing GCHandle for managed contact listener!");
            }

            UnsafeBindings.JPH_ContactListener_Destroy(listener);

            listener.Dispose();
        }

        /// <summary>
        /// Set the static callback pointers for JPH_ContactListener.
        /// </summary>
        private static void InitializeContactListeners()
        {
            fixed (JPH_ContactListener_Procs* ptr = &UnsafeContactListenerProcs)
            {
                UnsafeBindings.JPH_ContactListener_SetProcs(ptr);
            }
        }

        /// <summary>
        /// Static procs for marshalling; the lookup from static to instance listener happens in each method.
        /// </summary>
        private static readonly JPH_ContactListener_Procs UnsafeContactListenerProcs = new JPH_ContactListener_Procs {
            OnContactValidate  = GetDelegatePointer((UnsafeContactValidate) UnsafeContactValidateCallback),
            OnContactAdded     = GetDelegatePointer((UnsafeContactAdded) UnsafeContactAddedCallback),
            OnContactRemoved   = GetDelegatePointer((UnsafeContactRemoved) UnsafeContactRemovedCallback),
            OnContactPersisted = GetDelegatePointer((UnsafeContactPersisted) UnsafeContactPersistedCallback),
        };

        /// <summary>
        /// Unsafe static delegate for OnContactValidate.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate ValidateResult UnsafeContactValidate(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB, double3* offset, CollideShapeResult* result);

        /// <summary>
        /// Unsafe static delegate for OnContactAdded.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate void UnsafeContactAdded(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB);

        /// <summary>
        /// Unsafe static delegate for OnContactRemoved.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate void UnsafeContactRemoved(IntPtr udata, SubShapeIDPair* pair);

        /// <summary>
        /// Unsafe static delegate for OnContactPersisted.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private delegate void UnsafeContactPersisted(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB);

        /// <summary>
        /// Unsafe static implementation for OnContactValidate.
        /// </summary>
        private static ValidateResult UnsafeContactValidateCallback(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB, double3* offset, CollideShapeResult* result)
        {
            try
            {
                return ManagedReference.Deref<IContactListener>(udata).OnContactValidate(); // TODO forward args
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            return ValidateResult.AcceptContact;
        }

        /// <summary>
        /// Unsafe static implementation for OnContactAdded.
        /// </summary>
        private static void UnsafeContactAddedCallback(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB)
        {
            try
            {
                ManagedReference.Deref<IContactListener>(udata).OnContactAdded(); // TODO forward args
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Unsafe static implementation for OnContactRemoved.
        /// </summary>
        private static void UnsafeContactRemovedCallback(IntPtr udata, SubShapeIDPair* pair)
        {
            try
            {
                ManagedReference.Deref<IContactListener>(udata).OnContactRemoved(); // TODO forward args
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Unsafe static implementation for OnContactPersisted.
        /// </summary>
        private static void UnsafeContactPersistedCallback(IntPtr udata, JPH_Body* bodyA, JPH_Body* bodyB) // TODO forward args
        {
            try
            {
                ManagedReference.Deref<IContactListener>(udata).OnContactPersisted();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
