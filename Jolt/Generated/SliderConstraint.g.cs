using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct SliderConstraint : IEquatable<SliderConstraint>
    {
        internal readonly NativeHandle<JPH_SliderConstraint> Handle;
        
        internal SliderConstraint(NativeHandle<JPH_SliderConstraint> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(SliderConstraint other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is SliderConstraint other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(SliderConstraint lhs, SliderConstraint rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(SliderConstraint lhs, SliderConstraint rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_SliderConstraint
        
        public SliderConstraintSettings GetSettings() => new SliderConstraintSettings(Bindings.JPH_SliderConstraint_GetSettings(Handle));
        
        public float GetCurrentPosition() => Bindings.JPH_SliderConstraint_GetCurrentPosition(Handle);
        
        public void SetMaxFrictionForce(float force) => Bindings.JPH_SliderConstraint_SetMaxFrictionForce(Handle, force);
        
        public float GetMaxFrictionForce() => Bindings.JPH_SliderConstraint_GetMaxFrictionForce(Handle);
        
        public void SetMotorSettings(MotorSettings settings) => Bindings.JPH_SliderConstraint_SetMotorSettings(Handle, settings);
        
        public MotorSettings GetMotorSettings() => Bindings.JPH_SliderConstraint_GetMotorSettings(Handle);
        
        public void SetMotorState(MotorState state) => Bindings.JPH_SliderConstraint_SetMotorState(Handle, state);
        
        public MotorState GetMotorState() => Bindings.JPH_SliderConstraint_GetMotorState(Handle);
        
        public void SetTargetVelocity(float velocity) => Bindings.JPH_SliderConstraint_SetTargetVelocity(Handle, velocity);
        
        public float GetTargetVelocity() => Bindings.JPH_SliderConstraint_GetTargetVelocity(Handle);
        
        public void SetTargetPosition(float position) => Bindings.JPH_SliderConstraint_SetTargetPosition(Handle, position);
        
        public float GetTargetPosition() => Bindings.JPH_SliderConstraint_GetTargetPosition(Handle);
        
        public void SetLimits(float min, float max) => Bindings.JPH_SliderConstraint_SetLimits(Handle, min, max);
        
        public float GetLimitsMin() => Bindings.JPH_SliderConstraint_GetLimitsMin(Handle);
        
        public float GetLimitsMax() => Bindings.JPH_SliderConstraint_GetLimitsMax(Handle);
        
        public bool HasLimits() => Bindings.JPH_SliderConstraint_HasLimits(Handle);
        
        public SpringSettings GetLimitsSpringSettings() => Bindings.JPH_SliderConstraint_GetLimitsSpringSettings(Handle);
        
        public void SetLimitsSpringSettings(SpringSettings settings) => Bindings.JPH_SliderConstraint_SetLimitsSpringSettings(Handle, settings);
        
        public void GetTotalLambdaPosition(out float x, out float y) => Bindings.JPH_SliderConstraint_GetTotalLambdaPosition(Handle, out x, out y);
        
        public float GetTotalLambdaPositionLimits() => Bindings.JPH_SliderConstraint_GetTotalLambdaPositionLimits(Handle);
        
        public float3 GetTotalLambdaRotation() => Bindings.JPH_SliderConstraint_GetTotalLambdaRotation(Handle);
        
        public float GetTotalLambdaMotor() => Bindings.JPH_SliderConstraint_GetTotalLambdaMotor(Handle);
        
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
