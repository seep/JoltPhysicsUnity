using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct Constraint : IEquatable<Constraint>
    {
        #region IEquatable
        
        public bool Equals(Constraint other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is Constraint other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(Constraint lhs, Constraint rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(Constraint lhs, Constraint rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_Constraint
        
        public void Destroy() => Bindings.JPH_Constraint_Destroy(Handle);
        
        public ConstraintType GetShapeType() => Bindings.JPH_Constraint_GetType(Handle);
        
        public ConstraintSubType GetSubType() => Bindings.JPH_Constraint_GetSubType(Handle);
        
        public uint GetConstraintPriority() => Bindings.JPH_Constraint_GetConstraintPriority(Handle);
        
        public void SetConstraintPriority(uint priority) => Bindings.JPH_Constraint_SetConstraintPriority(Handle, priority);
        
        public uint GetNumVelocityStepsOverride() => Bindings.JPH_Constraint_GetNumVelocityStepsOverride(Handle);
        
        public void SetNumVelocityStepsOverride(uint value) => Bindings.JPH_Constraint_SetNumVelocityStepsOverride(Handle, value);
        
        public uint GetNumPositionStepsOverride() => Bindings.JPH_Constraint_GetNumPositionStepsOverride(Handle);
        
        public void SetNumPositionStepsOverride(uint value) => Bindings.JPH_Constraint_SetNumPositionStepsOverride(Handle, value);
        
        public bool GetEnabled() => Bindings.JPH_Constraint_GetEnabled(Handle);
        
        public void SetEnabled(bool enabled) => Bindings.JPH_Constraint_SetEnabled(Handle, enabled);
        
        public ulong GetUserData() => Bindings.JPH_Constraint_GetUserData(Handle);
        
        public void SetUserData(ulong userData) => Bindings.JPH_Constraint_SetUserData(Handle, userData);
        
        public void NotifyShapeChanged(BodyID bodyID, float3 deltaCOM) => Bindings.JPH_Constraint_NotifyShapeChanged(Handle, bodyID, deltaCOM);
        
        public void ResetWarmStart() => Bindings.JPH_Constraint_ResetWarmStart(Handle);
        
        public bool IsActive() => Bindings.JPH_Constraint_IsActive(Handle);
        
        public void SetupVelocityConstraint(float deltaTime) => Bindings.JPH_Constraint_SetupVelocityConstraint(Handle, deltaTime);
        
        public void WarmStartVelocityConstraint(float warmStartImpulseRatio) => Bindings.JPH_Constraint_WarmStartVelocityConstraint(Handle, warmStartImpulseRatio);
        
        public bool SolveVelocityConstraint(float deltaTime) => Bindings.JPH_Constraint_SolveVelocityConstraint(Handle, deltaTime);
        
        public bool SolvePositionConstraint(float deltaTime, float baumgarte) => Bindings.JPH_Constraint_SolvePositionConstraint(Handle, deltaTime, baumgarte);
        
        #endregion
        
    }
}
