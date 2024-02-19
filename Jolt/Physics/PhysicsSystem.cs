using System;
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

        public PhysicsSystem(PhysicsSystemSettings settings)
        {
            Handle = JPH_PhysicsSystem_Create(settings, out var h1, out var h2, out var h3);

            ObjectLayerPairFilter = new ObjectLayerPairFilter(h1);

            BroadPhaseLayerInterface = new BroadPhaseLayerInterface(h2);

            ObjectVsBroadPhaseLayerFilter = new ObjectVsBroadPhaseLayerFilter(h3);
        }

        public void OptimizeBroadPhase()
        {
            JPH_PhysicsSystem_OptimizeBroadPhase(Handle);
        }

        public BodyInterface GetBodyInterface()
        {
            return new BodyInterface(JPH_PhysicsSystem_GetBodyInterface(Handle));
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
            JPH_PhysicsSystem_Destroy(Handle);
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
