using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct HingeConstraintSettings : IEquatable<HingeConstraintSettings>
    {
        internal readonly NativeHandle<JPH_HingeConstraintSettings> Handle;
        
        internal HingeConstraintSettings(NativeHandle<JPH_HingeConstraintSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(HingeConstraintSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is HingeConstraintSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(HingeConstraintSettings lhs, HingeConstraintSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(HingeConstraintSettings lhs, HingeConstraintSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_HingeConstraintSettings
        
        public rvec3 GetPoint1() => Bindings.JPH_HingeConstraintSettings_GetPoint1(Handle);
        
        public void SetPoint1(rvec3 value) => Bindings.JPH_HingeConstraintSettings_SetPoint1(Handle, value);
        
        public rvec3 GetPoint2() => Bindings.JPH_HingeConstraintSettings_GetPoint2(Handle);
        
        public void SetPoint2(rvec3 value) => Bindings.JPH_HingeConstraintSettings_SetPoint2(Handle, value);
        
        public void SetHingeAxis1(float3 value) => Bindings.JPH_HingeConstraintSettings_SetHingeAxis1(Handle, value);
        
        public float3 GetHingeAxis1() => Bindings.JPH_HingeConstraintSettings_GetHingeAxis1(Handle);
        
        public void SetNormalAxis1(float3 value) => Bindings.JPH_HingeConstraintSettings_SetNormalAxis1(Handle, value);
        
        public float3 GetNormalAxis1() => Bindings.JPH_HingeConstraintSettings_GetNormalAxis1(Handle);
        
        public void SetHingeAxis2(float3 value) => Bindings.JPH_HingeConstraintSettings_SetHingeAxis2(Handle, value);
        
        public float3 GetHingeAxis2() => Bindings.JPH_HingeConstraintSettings_GetHingeAxis2(Handle);
        
        public void SetNormalAxis2(float3 value) => Bindings.JPH_HingeConstraintSettings_SetNormalAxis2(Handle, value);
        
        public float3 GetNormalAxis2() => Bindings.JPH_HingeConstraintSettings_GetNormalAxis2(Handle);
        
        public HingeConstraint CreateConstraint(Body bodyA, Body bodyB) => new HingeConstraint(Bindings.JPH_HingeConstraintSettings_CreateConstraint(Handle, bodyA.Handle, bodyB.Handle));
        
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
