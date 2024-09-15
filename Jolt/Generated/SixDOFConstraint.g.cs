using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct SixDOFConstraint : IEquatable<SixDOFConstraint>
    {
        internal readonly NativeHandle<JPH_SixDOFConstraint> Handle;
        
        internal SixDOFConstraint(NativeHandle<JPH_SixDOFConstraint> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(SixDOFConstraint other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is SixDOFConstraint other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(SixDOFConstraint lhs, SixDOFConstraint rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(SixDOFConstraint lhs, SixDOFConstraint rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_SixDOFConstraint
        
        public float GetLimitsMin(SixDOFConstraintAxis axis) => Bindings.JPH_SixDOFConstraint_GetLimitsMin(Handle, axis);
        
        public float GetLimitsMax(SixDOFConstraintAxis axis) => Bindings.JPH_SixDOFConstraint_GetLimitsMax(Handle, axis);
        
        public float3 GetTotalLambdaPosition() => Bindings.JPH_SixDOFConstraint_GetTotalLambdaPosition(Handle);
        
        public float3 GetTotalLambdaRotation() => Bindings.JPH_SixDOFConstraint_GetTotalLambdaRotation(Handle);
        
        public float3 GetTotalLambdaMotorTranslation() => Bindings.JPH_SixDOFConstraint_GetTotalLambdaMotorTranslation(Handle);
        
        public float3 GetTotalLambdaMotorRotation() => Bindings.JPH_SixDOFConstraint_GetTotalLambdaMotorRotation(Handle);
        
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
