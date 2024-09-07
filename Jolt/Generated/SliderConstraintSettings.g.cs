using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct SliderConstraintSettings : IEquatable<SliderConstraintSettings>
    {
        internal readonly NativeHandle<JPH_SliderConstraintSettings> Handle;
        
        internal SliderConstraintSettings(NativeHandle<JPH_SliderConstraintSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(SliderConstraintSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is SliderConstraintSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(SliderConstraintSettings lhs, SliderConstraintSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(SliderConstraintSettings lhs, SliderConstraintSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_SliderConstraintSettings
        
        public void SetSliderAxis(float3 axis) => Bindings.JPH_SliderConstraintSettings_SetSliderAxis(Handle, axis);
        
        public bool GetAutoDetectPoint() => Bindings.JPH_SliderConstraintSettings_GetAutoDetectPoint(Handle);
        
        public void SetAutoDetectPoint(bool value) => Bindings.JPH_SliderConstraintSettings_SetAutoDetectPoint(Handle, value);
        
        public rvec3 GetPoint1() => Bindings.JPH_SliderConstraintSettings_GetPoint1(Handle);
        
        public void SetPoint1(rvec3 value) => Bindings.JPH_SliderConstraintSettings_SetPoint1(Handle, value);
        
        public rvec3 GetPoint2() => Bindings.JPH_SliderConstraintSettings_GetPoint2(Handle);
        
        public void SetPoint2(rvec3 value) => Bindings.JPH_SliderConstraintSettings_SetPoint2(Handle, value);
        
        public void SetSliderAxis1(float3 value) => Bindings.JPH_SliderConstraintSettings_SetSliderAxis1(Handle, value);
        
        public float3 GetSliderAxis1() => Bindings.JPH_SliderConstraintSettings_GetSliderAxis1(Handle);
        
        public void SetNormalAxis1(float3 value) => Bindings.JPH_SliderConstraintSettings_SetNormalAxis1(Handle, value);
        
        public float3 GetNormalAxis1() => Bindings.JPH_SliderConstraintSettings_GetNormalAxis1(Handle);
        
        public void SetSliderAxis2(float3 value) => Bindings.JPH_SliderConstraintSettings_SetSliderAxis2(Handle, value);
        
        public float3 GetSliderAxis2() => Bindings.JPH_SliderConstraintSettings_GetSliderAxis2(Handle);
        
        public void SetNormalAxis2(float3 value) => Bindings.JPH_SliderConstraintSettings_SetNormalAxis2(Handle, value);
        
        public float3 GetNormalAxis2() => Bindings.JPH_SliderConstraintSettings_GetNormalAxis2(Handle);
        
        public SliderConstraint CreateConstraint(Body bodyA, Body bodyB) => new SliderConstraint(Bindings.JPH_SliderConstraintSettings_CreateConstraint(Handle, bodyA.Handle, bodyB.Handle));
        
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
