using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct BodyCreationSettings : IEquatable<BodyCreationSettings>
    {
        internal readonly NativeHandle<JPH_BodyCreationSettings> Handle;
        
        internal BodyCreationSettings(NativeHandle<JPH_BodyCreationSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(BodyCreationSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BodyCreationSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BodyCreationSettings lhs, BodyCreationSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BodyCreationSettings lhs, BodyCreationSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_BodyCreationSettings
        
        public void Destroy() => Bindings.JPH_BodyCreationSettings_Destroy(Handle);
        
        public rvec3 GetPosition() => Bindings.JPH_BodyCreationSettings_GetPosition(Handle);
        
        public void SetPosition(rvec3 value) => Bindings.JPH_BodyCreationSettings_SetPosition(Handle, value);
        
        public quaternion GetRotation() => Bindings.JPH_BodyCreationSettings_GetRotation(Handle);
        
        public void SetRotation(quaternion value) => Bindings.JPH_BodyCreationSettings_SetRotation(Handle, value);
        
        public float3 GetLinearVelocity() => Bindings.JPH_BodyCreationSettings_GetLinearVelocity(Handle);
        
        public void SetLinearVelocity(float3 velocity) => Bindings.JPH_BodyCreationSettings_SetLinearVelocity(Handle, velocity);
        
        public float3 GetAngularVelocity() => Bindings.JPH_BodyCreationSettings_GetAngularVelocity(Handle);
        
        public void SetAngularVelocity(float3 velocity) => Bindings.JPH_BodyCreationSettings_SetAngularVelocity(Handle, velocity);
        
        public MotionType GetMotionType() => Bindings.JPH_BodyCreationSettings_GetMotionType(Handle);
        
        public void SetMotionType(MotionType value) => Bindings.JPH_BodyCreationSettings_SetMotionType(Handle, value);
        
        public AllowedDOFs GetAllowedDOFs() => Bindings.JPH_BodyCreationSettings_GetAllowedDOFs(Handle);
        
        public void SetAllowedDOFs(AllowedDOFs value) => Bindings.JPH_BodyCreationSettings_SetAllowedDOFs(Handle, value);
        
        #endregion
        
    }
}
