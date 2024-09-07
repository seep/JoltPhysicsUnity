using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct ConstraintSettings : IEquatable<ConstraintSettings>
    {
        internal readonly NativeHandle<JPH_ConstraintSettings> Handle;
        
        internal ConstraintSettings(NativeHandle<JPH_ConstraintSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(ConstraintSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ConstraintSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ConstraintSettings lhs, ConstraintSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ConstraintSettings lhs, ConstraintSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ConstraintSettings
        
        public void Destroy() => Bindings.JPH_ConstraintSettings_Destroy(Handle);
        
        public bool GetEnabled() => Bindings.JPH_ConstraintSettings_GetEnabled(Handle);
        
        public uint GetConstraintPriority() => Bindings.JPH_ConstraintSettings_GetConstraintPriority(Handle);
        
        public uint GetNumVelocityStepsOverride() => Bindings.JPH_ConstraintSettings_GetNumVelocityStepsOverride(Handle);
        
        public void SetNumVelocityStepsOverride(uint value) => Bindings.JPH_ConstraintSettings_SetNumVelocityStepsOverride(Handle, value);
        
        public uint GetNumPositionStepsOverride() => Bindings.JPH_ConstraintSettings_GetNumPositionStepsOverride(Handle);
        
        public void SetNumPositionStepsOverride(uint value) => Bindings.JPH_ConstraintSettings_SetNumPositionStepsOverride(Handle, value);
        
        public float GetDrawConstraintSize() => Bindings.JPH_ConstraintSettings_GetDrawConstraintSize(Handle);
        
        public void SetDrawConstraintSize(float value) => Bindings.JPH_ConstraintSettings_SetDrawConstraintSize(Handle, value);
        
        public ulong GetUserData() => Bindings.JPH_ConstraintSettings_GetUserData(Handle);
        
        public void SetUserData(ulong value) => Bindings.JPH_ConstraintSettings_SetUserData(Handle, value);
        
        #endregion
        
    }
}
