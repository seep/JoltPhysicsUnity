﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_BodyActivationListener> JPH_BodyActivationListener_Create(IBodyActivationListener listener)
        {
            // See Bindings_JPH_ContactListener for comments.
            
            fixed (JPH_BodyActivationListener_Procs* procsptr = &UnsafeBodyActivationListenerProcs)
            {
                var gch = GCHandle.Alloc(listener);

                var gchptr = (void*)GCHandle.ToIntPtr(gch);
                var handle = CreateHandle(UnsafeBindings.JPH_BodyActivationListener_Create(procsptr, gchptr));
                
                ManagedReference.Add(handle, gch);

                return handle;
            }
        }

        public static void JPH_BodyActivationListener_Destroy(NativeHandle<JPH_BodyActivationListener> listener)
        {
            if (ManagedReference.Remove(listener, out var gch))
            {
                gch.Free();
            }
            else
            {
                Debug.LogError("Missing GCHandle for managed body listener!");
            }

            UnsafeBindings.JPH_BodyActivationListener_Destroy(listener);
            
            listener.Dispose();
        }

        /// <summary>
        /// Static procs for marshalling; the lookup from static to instance context happens in each method.
        /// </summary>
        private static readonly JPH_BodyActivationListener_Procs UnsafeBodyActivationListenerProcs = new () {
            OnBodyActivated   = Marshal.GetFunctionPointerForDelegate((UnsafeBodyActivated) UnsafeBodyActivatedCallback),
            OnBodyDeactivated = Marshal.GetFunctionPointerForDelegate((UnsafeBodyDeactivated) UnsafeBodyDeactivatedCallback),
        };

        /// <summary>
        /// Unsafe static delegate for OnBodyActivated.
        /// </summary>
        private delegate void UnsafeBodyActivated(IntPtr udata, BodyID bodyID, ulong bodyUserData);

        /// <summary>
        /// Unsafe static delegate for OnBodyDeactivated.
        /// </summary>
        private delegate void UnsafeBodyDeactivated(IntPtr udata, BodyID bodyID, ulong bodyUserData);

        /// <summary>
        /// Unsafe static implementation for OnBodyActivated.
        /// </summary>
        private static void UnsafeBodyActivatedCallback(IntPtr udata, BodyID bodyID, ulong bodyUserData)
        {
           

            try
            {
                ManagedReference.Deref<IBodyActivationListener>(udata).OnBodyActivated(bodyID, bodyUserData);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// Unsafe static implementation for OnBodyDeactivated.
        /// </summary>
        private static void UnsafeBodyDeactivatedCallback(IntPtr udata, BodyID bodyID, ulong bodyUserData)
        {
            try
            {
                ManagedReference.Deref<IBodyActivationListener>(udata).OnBodyDeactivated(bodyID, bodyUserData);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
