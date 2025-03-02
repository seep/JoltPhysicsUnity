using System;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    public partial struct PhysicsSystem : IEquatable<PhysicsSystem>, IDisposable
    {
        internal readonly NativeHandle<JPH_PhysicsSystem> Handle;

        /// <summary>
        /// The ObjectLayerPairFilter of the system.
        /// </summary>
        public ObjectLayerPairFilter ObjectLayerPairFilter;

        /// <summary>
        /// The BroadPhaseLayerInterface of the system.
        /// </summary>
        public BroadPhaseLayerInterface BroadPhaseLayerInterface;

        /// <summary>
        /// The ObjectVsBroadPhaseLayerFilter of the system.
        /// </summary>
        public ObjectVsBroadPhaseLayerFilter ObjectVsBroadPhaseLayerFilter;

        public PhysicsSystem(PhysicsSystemSettings settings)
        {
            Handle = JPH_PhysicsSystem_Create(settings);

            ObjectLayerPairFilter = settings.ObjectLayerPairFilter;
            BroadPhaseLayerInterface = settings.BroadPhaseLayerInterface;
            ObjectVsBroadPhaseLayerFilter = settings.ObjectVsBroadPhaseLayerFilter;
        }

        public void OptimizeBroadPhase()
        {
            JPH_PhysicsSystem_OptimizeBroadPhase(Handle);
        }

        /// <summary>
        /// Get the body interface, which allows creating and removing bodies and changing their properties.
        /// </summary>
        public BodyInterface GetBodyInterface()
        {
            return new BodyInterface { Handle = JPH_PhysicsSystem_GetBodyInterface(Handle) };
        }

        /// <summary>
        /// Get a non-locking version of the body interface. Use with great care!
        /// </summary>
        public BodyInterface GetBodyInterfaceNoLock()
        {
            return new BodyInterface { Handle = JPH_PhysicsSystem_GetBodyInterfaceNoLock(Handle) };
        }

        public void SetContactListener(ContactListener listener)
        {
            JPH_PhysicsSystem_SetContactListener(Handle, listener.Handle);
        }

        public void SetBodyActivationListener(BodyActivationListener listener)
        {
            JPH_PhysicsSystem_SetBodyActivationListener(Handle, listener.Handle);
        }

        /// <summary>
        /// Update the physics system. Returns true if there were no errors.
        /// </summary>
        /// <remarks>
        /// The out parameter will contain the error if any.
        /// </remarks>
        public bool Update(float deltaTime, int collisionSteps, JobSystem jobSystem, out PhysicsUpdateError error)
        {
            return (error = JPH_PhysicsSystem_Update(Handle, deltaTime, collisionSteps, jobSystem.Handle)) == PhysicsUpdateError.None;
        }

        public bool WereBodiesInContact(BodyID a, BodyID b)
        {
            return JPH_PhysicsSystem_WereBodiesInContact(Handle, a, b);
        }
        
        /// <summary>
        /// Get the current number of bodies in the body manager.
        /// </summary>
        public uint GetNumBodies()
        {
            return JPH_PhysicsSystem_GetNumBodies(Handle);
        }

        /// <summary>
        /// Get the current number of active bodies in the body manager.
        /// </summary>
        public uint GetNumActiveBodies(BodyType type)
        {
            return JPH_PhysicsSystem_GetNumActiveBodies(Handle, type);
        }

        /// <summary>
        /// Get the maximum number of bodies that this system supports.
        /// </summary>
        public uint GetMaxBodies()
        {
            return JPH_PhysicsSystem_GetMaxBodies(Handle);
        }

        public uint GetNumConstraints()
        {
            return JPH_PhysicsSystem_GetNumConstraints(Handle);
        }

        public void SetGravity(float3 gravity)
        {
            JPH_PhysicsSystem_SetGravity(Handle, gravity);
        }

        public float3 GetGravity()
        {
            return JPH_PhysicsSystem_GetGravity(Handle);
        }

        public void AddConstraint(Constraint constraint)
        {
            JPH_PhysicsSystem_AddConstraint(Handle, constraint.Handle);
        }

        public void RemoveConstraint(Constraint constraint)
        {
            JPH_PhysicsSystem_RemoveConstraint(Handle, constraint.Handle);
        }

        public void Dispose()
        {
            JPH_PhysicsSystem_Destroy(Handle);
        }

        #region IEquatable

        public bool Equals(PhysicsSystem other) => Handle.Equals(other.Handle);

        public override bool Equals(object obj) => obj is PhysicsSystem other && Equals(other);

        public override int GetHashCode() => Handle.GetHashCode();

        public static bool operator ==(PhysicsSystem lhs, PhysicsSystem rhs) => lhs.Equals(rhs);

        public static bool operator !=(PhysicsSystem lhs, PhysicsSystem rhs) => !lhs.Equals(rhs);

        #endregion
    }
}
