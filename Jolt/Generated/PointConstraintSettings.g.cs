using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct PointConstraintSettings : IEquatable<PointConstraintSettings>
    {
        internal readonly NativeHandle<JPH_PointConstraintSettings> Handle;
        
        internal PointConstraintSettings(NativeHandle<JPH_PointConstraintSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(PointConstraintSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is PointConstraintSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(PointConstraintSettings lhs, PointConstraintSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(PointConstraintSettings lhs, PointConstraintSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_PointConstraintSettings
        
        public ConstraintSpace GetSpace() => Bindings.JPH_PointConstraintSettings_GetSpace(Handle);
        
        public void SetSpace(ConstraintSpace space) => Bindings.JPH_PointConstraintSettings_SetSpace(Handle, space);
        
        public rvec3 GetPoint1() => Bindings.JPH_PointConstraintSettings_GetPoint1(Handle);
        
        public void SetPoint1(rvec3 value) => Bindings.JPH_PointConstraintSettings_SetPoint1(Handle, value);
        
        public rvec3 GetPoint2() => Bindings.JPH_PointConstraintSettings_GetPoint2(Handle);
        
        public void SetPoint2(rvec3 value) => Bindings.JPH_PointConstraintSettings_SetPoint2(Handle, value);
        
        public PointConstraint CreateConstraint(Body bodyA, Body bodyB) => new PointConstraint(Bindings.JPH_PointConstraintSettings_CreateConstraint(Handle, bodyA.Handle, bodyB.Handle));
        
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
