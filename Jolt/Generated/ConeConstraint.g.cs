using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct ConeConstraint : IEquatable<ConeConstraint>
    {
        internal readonly NativeHandle<JPH_ConeConstraint> Handle;
        
        internal ConeConstraint(NativeHandle<JPH_ConeConstraint> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(ConeConstraint other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ConeConstraint other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ConeConstraint lhs, ConeConstraint rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ConeConstraint lhs, ConeConstraint rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ConeConstraint
        
        public void SetHalfConeAngle(float halfConeAngle) => Bindings.JPH_ConeConstraint_SetHalfConeAngle(Handle, halfConeAngle);
        
        public float GetCosHalfConeAngle() => Bindings.JPH_ConeConstraint_GetCosHalfConeAngle(Handle);
        
        public float3 GetTotalLambdaPosition() => Bindings.JPH_ConeConstraint_GetTotalLambdaPosition(Handle);
        
        public float GetTotalLambdaRotation() => Bindings.JPH_ConeConstraint_GetTotalLambdaRotation(Handle);
        
        #endregion
        
        #region JPH_TwoBodyConstraint
        
        public Body GetBody1() => new Body(Bindings.JPH_TwoBodyConstraint_GetBody1(Handle.Reinterpret<JPH_TwoBodyConstraint>()));
        
        public Body GetBody2() => new Body(Bindings.JPH_TwoBodyConstraint_GetBody2(Handle.Reinterpret<JPH_TwoBodyConstraint>()));
        
        public float4x4 GetConstraintToBody1Matrix() => Bindings.JPH_TwoBodyConstraint_GetConstraintToBody1Matrix(Handle.Reinterpret<JPH_TwoBodyConstraint>());
        
        public float4x4 GetConstraintToBody2Matrix() => Bindings.JPH_TwoBodyConstraint_GetConstraintToBody2Matrix(Handle.Reinterpret<JPH_TwoBodyConstraint>());
        
        #endregion
        
        #region JPH_Constraint
        
        public ConstraintSettings GetConstraintSettings() => new ConstraintSettings(Bindings.JPH_Constraint_GetConstraintSettings(Handle.Reinterpret<JPH_Constraint>()));
        
        public new ConstraintType GetType() => Bindings.JPH_Constraint_GetType(Handle.Reinterpret<JPH_Constraint>());
        
        public ConstraintSubType GetSubType() => Bindings.JPH_Constraint_GetSubType(Handle.Reinterpret<JPH_Constraint>());
        
        public uint GetConstraintPriority() => Bindings.JPH_Constraint_GetConstraintPriority(Handle.Reinterpret<JPH_Constraint>());
        
        public void SetConstraintPriority(uint priority) => Bindings.JPH_Constraint_SetConstraintPriority(Handle.Reinterpret<JPH_Constraint>(), priority);
        
        public bool GetEnabled() => Bindings.JPH_Constraint_GetEnabled(Handle.Reinterpret<JPH_Constraint>());
        
        public void SetEnabled(bool enabled) => Bindings.JPH_Constraint_SetEnabled(Handle.Reinterpret<JPH_Constraint>(), enabled);
        
        public ulong GetUserData() => Bindings.JPH_Constraint_GetUserData(Handle.Reinterpret<JPH_Constraint>());
        
        public void SetUserData(ulong userData) => Bindings.JPH_Constraint_SetUserData(Handle.Reinterpret<JPH_Constraint>(), userData);
        
        public void NotifyShapeChanged(BodyID bodyID, float3 deltaCOM) => Bindings.JPH_Constraint_NotifyShapeChanged(Handle.Reinterpret<JPH_Constraint>(), bodyID, deltaCOM);
        
        public void Destroy() => Bindings.JPH_Constraint_Destroy(Handle.Reinterpret<JPH_Constraint>());
        
        #endregion
        
    }
}
