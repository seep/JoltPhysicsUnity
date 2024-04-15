﻿using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

namespace Jolt
{
    public struct PhysicsSystem : IDisposable, IEquatable<PhysicsSystem>
    {
        internal NativeHandle<JPH_PhysicsSystem> Handle;

        public ObjectLayerPairFilter ObjectLayerPairFilter;

        public BroadPhaseLayerInterface BroadPhaseLayerInterface;

        public ObjectVsBroadPhaseLayerFilter ObjectVsBroadPhaseLayerFilter;

        internal NativeHandle<JPH_ContactListener> ContactListenerHandle;

        internal NativeHandle<JPH_BodyActivationListener> BodyActivationListenerHandle;

        public PhysicsSystem(PhysicsSystemSettings settings)
        {
            Handle = JPH_PhysicsSystem_Create(settings, out var h1, out var h2, out var h3);

            ObjectLayerPairFilter = new ObjectLayerPairFilter(h1);

            BroadPhaseLayerInterface = new BroadPhaseLayerInterface(h2);

            ObjectVsBroadPhaseLayerFilter = new ObjectVsBroadPhaseLayerFilter(h3);

            ContactListenerHandle = JPH_ContactListener_Create();

            BodyActivationListenerHandle = JPH_BodyActivationListener_Create();
        }

        public void OptimizeBroadPhase()
        {
            JPH_PhysicsSystem_OptimizeBroadPhase(Handle);
        }

        public BodyInterface GetBodyInterface()
        {
            return new BodyInterface(JPH_PhysicsSystem_GetBodyInterface(Handle));
        }

        public void SetContactListener(IContactListener listener)
        {
            ContactListener.Attach(this, listener);

            JPH_PhysicsSystem_SetContactListener(Handle, ContactListenerHandle);
        }

        public void SetBodyActivationListener(IBodyActivationListener listener)
        {
            BodyActivationListener.Attach(this, listener);

            JPH_PhysicsSystem_SetBodyActivationListener(Handle, BodyActivationListenerHandle);
        }

        /// <summary>
        /// Update the physics system. Returns true if there were no errors.
        /// </summary>
        public bool Step(float deltaTime, int collisionSteps, out PhysicsUpdateError error)
        {
            error = JPH_PhysicsSystem_Step(Handle, deltaTime, collisionSteps);
            return error == PhysicsUpdateError.None;
        }

        public uint GetNumBodies()
        {
            return JPH_PhysicsSystem_GetNumBodies(Handle);
        }

        public uint GetNumActiveBodies(BodyType type)
        {
            return JPH_PhysicsSystem_GetNumActiveBodies(Handle, type);
        }

        public uint GetMaxBodies()
        {
            return JPH_PhysicsSystem_GetMaxBodies(Handle);
        }

        public void SetGravity(float3 gravity)
        {
            JPH_PhysicsSystem_SetGravity(Handle, gravity);
        }

        public float3 GetGravity()
        {
            return JPH_PhysicsSystem_GetGravity(Handle);
        }

        public void Dispose()
        {
            ContactListener.Detach(this);

            BodyActivationListener.Detach(this);

            JPH_PhysicsSystem_Destroy(Handle);

            JPH_ContactListener_Destroy(ContactListenerHandle);

            JPH_BodyActivationListener_Destroy(BodyActivationListenerHandle);
        }

        public bool Equals(PhysicsSystem other)
        {
            return Handle == other.Handle;
        }

        public override bool Equals(object obj)
        {
            return obj is PhysicsSystem other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }
    }
}
