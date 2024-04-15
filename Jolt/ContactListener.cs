using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe class ContactListener
    {
        private delegate void OnContactValidate(JPH_ContactListener* listener, JPH_Body* bodyA, JPH_Body* bodyB, double3* offset, JPH_CollideShapeResult* result);

        private delegate void OnContactAdded(JPH_ContactListener* listener, JPH_Body* bodyA, JPH_Body* bodyB);

        private delegate void OnContactPersisted(JPH_ContactListener* listener, JPH_Body* bodyA, JPH_Body* bodyB);

        private delegate void OnContactRemoved(JPH_ContactListener* listener, JPH_SubShapeIDPair* pair);

        private static Dictionary<nint, IContactListener> lookup = new (); // TODO use unmanaged container for Burst compatability

        static ContactListener()
        {
            Bindings.JPH_ContactListener_SetProcs(new JPH_ContactListener_Procs
            {
                OnContactValidate  = Marshal.GetFunctionPointerForDelegate((OnContactValidate) OnContactValidateCallback),
                OnContactAdded     = Marshal.GetFunctionPointerForDelegate((OnContactAdded) OnContactAddedCallback),
                OnContactPersisted = Marshal.GetFunctionPointerForDelegate((OnContactPersisted) OnContactPersistedCallback),
                OnContactRemoved   = Marshal.GetFunctionPointerForDelegate((OnContactRemoved) OnContactRemovedCallback),
            });
        }

        /// <summary>
        /// Attach a managed contact listener to the system. If a listener is already attached, throws an exception.
        /// </summary>
        public static void Attach(PhysicsSystem system, IContactListener listener)
        {
            if (lookup.ContainsKey((nint) system.ContactListenerHandle.Unwrap()))
            {
                throw new Exception("The PhysicsSystem already has an attached contact listener.");
            }

            lookup.Add((nint) system.ContactListenerHandle.Unwrap(), listener);
        }

        /// <summary>
        /// Detach an existing managed contact listener from the system.
        /// </summary>
        public static void Detach(PhysicsSystem system)
        {
            lookup.Remove((nint) system.ContactListenerHandle.Unwrap());
        }

        private static void OnContactValidateCallback(JPH_ContactListener* listener, JPH_Body* bodyA, JPH_Body* bodyB, double3* offset, JPH_CollideShapeResult* result)
        {
            if (lookup.TryGetValue((nint) listener, out var value))
            {
                value.OnContactValidate(); // TODO add args
            }
        }

        private static void OnContactAddedCallback(JPH_ContactListener* listener, JPH_Body* bodyA, JPH_Body* bodyB)
        {
            if (lookup.TryGetValue((nint) listener, out var value))
            {
                value.OnContactAdded(); // TODO add args
            }
        }

        private static void OnContactPersistedCallback(JPH_ContactListener* listener, JPH_Body* bodyA, JPH_Body* bodyB)
        {
            if (lookup.TryGetValue((nint) listener, out var value))
            {
                value.OnContactPersisted(); // TODO add args
            }
        }

        private static void OnContactRemovedCallback(JPH_ContactListener* listener, JPH_SubShapeIDPair* pair)
        {
            if (lookup.TryGetValue((nint) listener, out var value))
            {
                value.OnContactRemoved(); // TODO add args
            }
        }
    }
}
