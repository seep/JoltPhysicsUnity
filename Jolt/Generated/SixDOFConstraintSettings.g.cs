using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct SixDOFConstraintSettings : IEquatable<SixDOFConstraintSettings>
    {
        internal readonly NativeHandle<JPH_SixDOFConstraintSettings> Handle;
        
        internal SixDOFConstraintSettings(NativeHandle<JPH_SixDOFConstraintSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(SixDOFConstraintSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is SixDOFConstraintSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(SixDOFConstraintSettings lhs, SixDOFConstraintSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(SixDOFConstraintSettings lhs, SixDOFConstraintSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_SixDOFConstraintSettings
        
        public SixDOFConstraint CreateConstraint(Body bodyA, Body bodyB) => new SixDOFConstraint(Bindings.JPH_SixDOFConstraintSettings_CreateConstraint(Handle, bodyA.Handle, bodyB.Handle));
        
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
