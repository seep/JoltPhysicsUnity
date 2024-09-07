using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct DistanceConstraintSettings : IEquatable<DistanceConstraintSettings>
    {
        internal readonly NativeHandle<JPH_DistanceConstraintSettings> Handle;
        
        internal DistanceConstraintSettings(NativeHandle<JPH_DistanceConstraintSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(DistanceConstraintSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is DistanceConstraintSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(DistanceConstraintSettings lhs, DistanceConstraintSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(DistanceConstraintSettings lhs, DistanceConstraintSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_DistanceConstraintSettings
        
        public ConstraintSpace GetSpace() => Bindings.JPH_DistanceConstraintSettings_GetSpace(Handle);
        
        public void SetSpace(ConstraintSpace space) => Bindings.JPH_DistanceConstraintSettings_SetSpace(Handle, space);
        
        public rvec3 GetPoint1() => Bindings.JPH_DistanceConstraintSettings_GetPoint1(Handle);
        
        public void SetPoint1(rvec3 value) => Bindings.JPH_DistanceConstraintSettings_SetPoint1(Handle, value);
        
        public rvec3 GetPoint2() => Bindings.JPH_DistanceConstraintSettings_GetPoint2(Handle);
        
        public void SetPoint2(rvec3 value) => Bindings.JPH_DistanceConstraintSettings_SetPoint2(Handle, value);
        
        public DistanceConstraint CreateConstraint(Body bodyA, Body bodyB) => new DistanceConstraint(Bindings.JPH_DistanceConstraintSettings_CreateConstraint(Handle, bodyA.Handle, bodyB.Handle));
        
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
