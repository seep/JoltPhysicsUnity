using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct SwingTwistConstraintSettings : IEquatable<SwingTwistConstraintSettings>
    {
        internal readonly NativeHandle<JPH_SwingTwistConstraintSettings> Handle;
        
        internal SwingTwistConstraintSettings(NativeHandle<JPH_SwingTwistConstraintSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(SwingTwistConstraintSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is SwingTwistConstraintSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(SwingTwistConstraintSettings lhs, SwingTwistConstraintSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(SwingTwistConstraintSettings lhs, SwingTwistConstraintSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_SwingTwistConstraintSettings
        
        public SwingTwistConstraint CreateConstraint(Body bodyA, Body bodyB) => new SwingTwistConstraint(Bindings.JPH_SwingTwistConstraintSettings_CreateConstraint(Handle, bodyA.Handle, bodyB.Handle));
        
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
