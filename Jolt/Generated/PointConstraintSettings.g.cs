using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct PointConstraintSettings : IEquatable<PointConstraintSettings>
    {
        #region IEquatable
        
        public bool Equals(PointConstraintSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is PointConstraintSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(PointConstraintSettings lhs, PointConstraintSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(PointConstraintSettings lhs, PointConstraintSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ConstraintSettings
        
        public void Destroy() => Bindings.JPH_ConstraintSettings_Destroy(Handle.Reinterpret<JPH_ConstraintSettings>());
        
        public bool GetEnabled() => Bindings.JPH_ConstraintSettings_GetEnabled(Handle.Reinterpret<JPH_ConstraintSettings>());
        
        public uint GetConstraintPriority() => Bindings.JPH_ConstraintSettings_GetConstraintPriority(Handle.Reinterpret<JPH_ConstraintSettings>());
        
        public uint GetNumVelocityStepsOverride() => Bindings.JPH_ConstraintSettings_GetNumVelocityStepsOverride(Handle.Reinterpret<JPH_ConstraintSettings>());
        
        public void SetNumVelocityStepsOverride(uint value) => Bindings.JPH_ConstraintSettings_SetNumVelocityStepsOverride(Handle.Reinterpret<JPH_ConstraintSettings>(), value);
        
        public uint GetNumPositionStepsOverride() => Bindings.JPH_ConstraintSettings_GetNumPositionStepsOverride(Handle.Reinterpret<JPH_ConstraintSettings>());
        
        public void SetNumPositionStepsOverride(uint value) => Bindings.JPH_ConstraintSettings_SetNumPositionStepsOverride(Handle.Reinterpret<JPH_ConstraintSettings>(), value);
        
        public float GetDrawConstraintSize() => Bindings.JPH_ConstraintSettings_GetDrawConstraintSize(Handle.Reinterpret<JPH_ConstraintSettings>());
        
        public void SetDrawConstraintSize(float value) => Bindings.JPH_ConstraintSettings_SetDrawConstraintSize(Handle.Reinterpret<JPH_ConstraintSettings>(), value);
        
        public ulong GetUserData() => Bindings.JPH_ConstraintSettings_GetUserData(Handle.Reinterpret<JPH_ConstraintSettings>());
        
        public void SetUserData(ulong value) => Bindings.JPH_ConstraintSettings_SetUserData(Handle.Reinterpret<JPH_ConstraintSettings>(), value);
        
        #endregion
        
        #region JPH_FixedConstraintSettings
        
        public void SetConstraintPriority(uint value) => Bindings.JPH_FixedConstraintSettings_SetConstraintPriority(Handle.Reinterpret<JPH_ConstraintSettings>(), value);
        
        public ConstraintSpace GetSpace() => Bindings.JPH_FixedConstraintSettings_GetSpace(Handle.Reinterpret<JPH_FixedConstraintSettings>());
        
        public void SetSpace(ConstraintSpace space) => Bindings.JPH_FixedConstraintSettings_SetSpace(Handle.Reinterpret<JPH_FixedConstraintSettings>(), space);
        
        public bool GetAutoDetectPoint() => Bindings.JPH_FixedConstraintSettings_GetAutoDetectPoint(Handle.Reinterpret<JPH_FixedConstraintSettings>());
        
        public void SetAutoDetectPoint(bool value) => Bindings.JPH_FixedConstraintSettings_SetAutoDetectPoint(Handle.Reinterpret<JPH_FixedConstraintSettings>(), value);
        
        public rvec3 GetPoint1() => Bindings.JPH_FixedConstraintSettings_GetPoint1(Handle.Reinterpret<JPH_FixedConstraintSettings>());
        
        public void SetPoint1(rvec3 value) => Bindings.JPH_FixedConstraintSettings_SetPoint1(Handle.Reinterpret<JPH_FixedConstraintSettings>(), value);
        
        public float3 GetAxisX1() => Bindings.JPH_FixedConstraintSettings_GetAxisX1(Handle.Reinterpret<JPH_FixedConstraintSettings>());
        
        public void SetAxisX1(float3 value) => Bindings.JPH_FixedConstraintSettings_SetAxisX1(Handle.Reinterpret<JPH_FixedConstraintSettings>(), value);
        
        public float3 GetAxisY1() => Bindings.JPH_FixedConstraintSettings_GetAxisY1(Handle.Reinterpret<JPH_FixedConstraintSettings>());
        
        public void SetAxisY1(float3 value) => Bindings.JPH_FixedConstraintSettings_SetAxisY1(Handle.Reinterpret<JPH_FixedConstraintSettings>(), value);
        
        public rvec3 GetPoint2() => Bindings.JPH_FixedConstraintSettings_GetPoint2(Handle.Reinterpret<JPH_FixedConstraintSettings>());
        
        public void SetPoint2(rvec3 value) => Bindings.JPH_FixedConstraintSettings_SetPoint2(Handle.Reinterpret<JPH_FixedConstraintSettings>(), value);
        
        public float3 GetAxisX2() => Bindings.JPH_FixedConstraintSettings_GetAxisX2(Handle.Reinterpret<JPH_FixedConstraintSettings>());
        
        public void SetAxisX2(float3 value) => Bindings.JPH_FixedConstraintSettings_SetAxisX2(Handle.Reinterpret<JPH_FixedConstraintSettings>(), value);
        
        public float3 GetAxisY2() => Bindings.JPH_FixedConstraintSettings_GetAxisY2(Handle.Reinterpret<JPH_FixedConstraintSettings>());
        
        public void SetAxisY2(float3 value) => Bindings.JPH_FixedConstraintSettings_SetAxisY2(Handle.Reinterpret<JPH_FixedConstraintSettings>(), value);
        
        public FixedConstraint CreateConstraint(Body bodyA, Body bodyB) => new FixedConstraint(Bindings.JPH_FixedConstraintSettings_CreateConstraint(Handle.Reinterpret<JPH_FixedConstraintSettings>(), bodyA.Handle, bodyB.Handle));
        
        #endregion
        
    }
}
