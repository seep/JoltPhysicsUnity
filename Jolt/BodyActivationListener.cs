using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Jolt
{
    public static unsafe class BodyActivationListener
    {
        private delegate void OnBodyActivated(JPH_BodyActivationListener* listener, BodyID bodyID, ulong bodyUserData);

        private delegate void OnBodyDeactivated(JPH_BodyActivationListener* listener, BodyID bodyID, ulong bodyUserData);

        private static Dictionary<nint, IBodyActivationListener> lookup = new (); // TODO use unmanaged container for Burst compatability

        static BodyActivationListener()
        {
            Bindings.JPH_BodyActivationListener_SetProcs(new JPH_BodyActivationListener_Procs
            {
                OnBodyActivated   = Marshal.GetFunctionPointerForDelegate((OnBodyActivated) OnBodyActivatedCallback),
                OnBodyDeactivated = Marshal.GetFunctionPointerForDelegate((OnBodyDeactivated) OnBodyDeactivatedCallback),
            });
        }

        /// <summary>
        /// Attach a managed body activation listener to the system. If a listener is already attached, throws an exception.
        /// </summary>
        public static void Attach(PhysicsSystem system, IBodyActivationListener listener)
        {
            if (lookup.ContainsKey((nint) system.ContactListenerHandle.Unwrap()))
            {
                throw new Exception("The PhysicsSystem already has an attached body activation listener.");
            }

            lookup.Add((nint) system.BodyActivationListenerHandle.Unwrap(), listener);
        }

        /// <summary>
        /// Detach an existing managed body activation listener from the system.
        /// </summary>
        public static void Detach(PhysicsSystem system)
        {
            lookup.Remove((nint) system.BodyActivationListenerHandle.Unwrap());
        }

        private static void OnBodyActivatedCallback(JPH_BodyActivationListener* listener, BodyID bodyID, ulong bodyUserData)
        {
            if (lookup.TryGetValue((nint)  listener, out var value))
            {
                value.OnBodyActivated(bodyID, bodyUserData);
            }
        }

        private static void OnBodyDeactivatedCallback(JPH_BodyActivationListener* listener, BodyID bodyID, ulong bodyUserData)
        {
            if (lookup.TryGetValue((nint) listener, out var value))
            {
                value.OnBodyDeactivated(bodyID, bodyUserData);
            }
        }
    }
}
