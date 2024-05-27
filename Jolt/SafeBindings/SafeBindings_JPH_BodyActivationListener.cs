using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        private static Dictionary<IntPtr, IBodyActivationListener> managedBodyActivationListeners = new ();

        public static NativeHandle<JPH_BodyActivationListener> JPH_BodyActivationListener_Create()
        {
            return CreateHandle(Bindings.JPH_BodyActivationListener_Create());
        }

        public static void JPH_BodyActivationListener_SetProcs(NativeHandle<JPH_BodyActivationListener> listener, IBodyActivationListener managed)
        {
            Bindings.JPH_BodyActivationListener_SetProcs(listener, UnsafeBodyActivationListenerProcs, listener);

            // See JoltAPI_JPH_ContactListener for notes about managed listeners.

            managedBodyActivationListeners[(nint) listener.Unwrap()] = managed;
        }

        public static void JPH_BodyActivationListener_Destroy(NativeHandle<JPH_BodyActivationListener> listener)
        {
            managedBodyActivationListeners.Remove((nint) listener.Unwrap());

            Bindings.JPH_BodyActivationListener_Destroy(listener.Unwrap());

            listener.Dispose();
        }

        private static readonly JPH_BodyActivationListener_Procs UnsafeBodyActivationListenerProcs = new () {
            OnBodyActivated   = Marshal.GetFunctionPointerForDelegate((UnsafeBodyActivated) UnsafeBodyActivatedCallback),
            OnBodyDeactivated = Marshal.GetFunctionPointerForDelegate((UnsafeBodyDeactivated) UnsafeBodyDeactivatedCallback),
        };

        private delegate void UnsafeBodyActivated(IntPtr udata, BodyID bodyID, ulong bodyUserData);

        private delegate void UnsafeBodyDeactivated(IntPtr udata, BodyID bodyID, ulong bodyUserData);

        private static void UnsafeBodyActivatedCallback(IntPtr udata, BodyID bodyID, ulong bodyUserData)
        {
            try
            {
                managedBodyActivationListeners[udata]?.OnBodyActivated(bodyID, bodyUserData);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private static void UnsafeBodyDeactivatedCallback(IntPtr udata, BodyID bodyID, ulong bodyUserData)
        {
            try
            {
                managedBodyActivationListeners[udata]?.OnBodyDeactivated(bodyID, bodyUserData);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
