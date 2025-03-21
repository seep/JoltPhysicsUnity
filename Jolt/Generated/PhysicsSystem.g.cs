using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct PhysicsSystem : IEquatable<PhysicsSystem>
    {
        #region IEquatable
        
        public bool Equals(PhysicsSystem other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is PhysicsSystem other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(PhysicsSystem lhs, PhysicsSystem rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(PhysicsSystem lhs, PhysicsSystem rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_PhysicsSystem
        
        public void Destroy() => Bindings.JPH_PhysicsSystem_Destroy(Handle);
        
        public void SetPhysicsSettings(ref PhysicsSettings settings) => Bindings.JPH_PhysicsSystem_SetPhysicsSettings(Handle, ref settings);
        
        public void GetPhysicsSettings(ref PhysicsSettings settings) => Bindings.JPH_PhysicsSystem_GetPhysicsSettings(Handle, ref settings);
        
        public void OptimizeBroadPhase() => Bindings.JPH_PhysicsSystem_OptimizeBroadPhase(Handle);
        
        public BodyInterface GetBodyInterface() => new BodyInterface { Handle = Bindings.JPH_PhysicsSystem_GetBodyInterface(Handle) };
        
        public BodyInterface GetBodyInterfaceNoLock() => new BodyInterface { Handle = Bindings.JPH_PhysicsSystem_GetBodyInterfaceNoLock(Handle) };
        
        public BodyLockInterface GetBodyLockInterface() => new BodyLockInterface { Handle = Bindings.JPH_PhysicsSystem_GetBodyLockInterface(Handle) };
        
        public BodyLockInterface GetBodyLockInterfaceNoLock() => new BodyLockInterface { Handle = Bindings.JPH_PhysicsSystem_GetBodyLockInterfaceNoLock(Handle) };
        
        public BroadPhaseQuery GetBroadPhaseQuery() => new BroadPhaseQuery { Handle = Bindings.JPH_PhysicsSystem_GetBroadPhaseQuery(Handle) };
        
        public NarrowPhaseQuery GetNarrowPhaseQuery() => new NarrowPhaseQuery { Handle = Bindings.JPH_PhysicsSystem_GetNarrowPhaseQuery(Handle) };
        
        public NarrowPhaseQuery GetNarrowPhaseQueryNoLock() => new NarrowPhaseQuery { Handle = Bindings.JPH_PhysicsSystem_GetNarrowPhaseQueryNoLock(Handle) };
        
        public bool WereBodiesInContact(BodyID a, BodyID b) => Bindings.JPH_PhysicsSystem_WereBodiesInContact(Handle, a, b);
        
        public uint GetNumBodies() => Bindings.JPH_PhysicsSystem_GetNumBodies(Handle);
        
        public uint GetNumActiveBodies(BodyType type) => Bindings.JPH_PhysicsSystem_GetNumActiveBodies(Handle, type);
        
        public uint GetMaxBodies() => Bindings.JPH_PhysicsSystem_GetMaxBodies(Handle);
        
        public uint GetNumConstraints() => Bindings.JPH_PhysicsSystem_GetNumConstraints(Handle);
        
        public void SetGravity(float3 gravity) => Bindings.JPH_PhysicsSystem_SetGravity(Handle, gravity);
        
        public float3 GetGravity() => Bindings.JPH_PhysicsSystem_GetGravity(Handle);
        
        public void AddConstraint(Constraint constraint) => Bindings.JPH_PhysicsSystem_AddConstraint(Handle, constraint.Handle);
        
        public void RemoveConstraint(Constraint constraint) => Bindings.JPH_PhysicsSystem_RemoveConstraint(Handle, constraint.Handle);
        
        #endregion
        
    }
}
