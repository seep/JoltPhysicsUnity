using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        private static Dictionary<IntPtr, IBodyActivationListener> managedBodyActivationListeners = new ();

        public static NativeHandle<JPH_BodyActivationListener> JPH_BodyActivationListener_Create(JPH_BodyActivationListener_Procs procs)
        {
            return CreateHandle(UnsafeBindings.JPH_BodyActivationListener_Create(&procs, userData: null)); // TODO forward userData param
        }

        public static void JPH_BodyActivationListener_Destroy(NativeHandle<JPH_BodyActivationListener> listener)
        {
            UnsafeBindings.JPH_BodyActivationListener_Destroy(listener.IntoPointer());
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
