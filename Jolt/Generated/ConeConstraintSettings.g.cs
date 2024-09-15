using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct ConeConstraintSettings : IEquatable<ConeConstraintSettings>
    {
        internal readonly NativeHandle<JPH_ConeConstraintSettings> Handle;
        
        internal ConeConstraintSettings(NativeHandle<JPH_ConeConstraintSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(ConeConstraintSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ConeConstraintSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ConeConstraintSettings lhs, ConeConstraintSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ConeConstraintSettings lhs, ConeConstraintSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ConeConstraintSettings
        
        public rvec3 GetPoint1() => Bindings.JPH_ConeConstraintSettings_GetPoint1(Handle);
        
        public void SetPoint1(rvec3 value) => Bindings.JPH_ConeConstraintSettings_SetPoint1(Handle, value);
        
        public rvec3 GetPoint2() => Bindings.JPH_ConeConstraintSettings_GetPoint2(Handle);
        
        public void SetPoint2(rvec3 value) => Bindings.JPH_ConeConstraintSettings_SetPoint2(Handle, value);
        
        public void SetTwistAxis1(float3 value) => Bindings.JPH_ConeConstraintSettings_SetTwistAxis1(Handle, value);
        
        public float3 GetTwistAxis1() => Bindings.JPH_ConeConstraintSettings_GetTwistAxis1(Handle);
        
        public void SetTwistAxis2(float3 value) => Bindings.JPH_ConeConstraintSettings_SetTwistAxis2(Handle, value);
        
        public float3 GetTwistAxis2() => Bindings.JPH_ConeConstraintSettings_GetTwistAxis2(Handle);
        
        public void SetHalfConeAngle(float halfConeAngle) => Bindings.JPH_ConeConstraintSettings_SetHalfConeAngle(Handle, halfConeAngle);
        
        public float GetHalfConeAngle() => Bindings.JPH_ConeConstraintSettings_GetHalfConeAngle(Handle);
        
        public ConeConstraint CreateConstraint(Body bodyA, Body bodyB) => new ConeConstraint(Bindings.JPH_ConeConstraintSettings_CreateConstraint(Handle, bodyA.Handle, bodyB.Handle));
        
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
        
    }
}
