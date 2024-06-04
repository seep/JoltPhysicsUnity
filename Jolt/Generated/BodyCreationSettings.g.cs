using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct BodyCreationSettings : IEquatable<BodyCreationSettings>
    {
        #region IEquatable
        
        public bool Equals(BodyCreationSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BodyCreationSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BodyCreationSettings lhs, BodyCreationSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BodyCreationSettings lhs, BodyCreationSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_BodyCreationSettings
        
        public void Destroy() => SafeBindings.JPH_BodyCreationSettings_Destroy(Handle);
        
        public float3 GetLinearVelocity() => SafeBindings.JPH_BodyCreationSettings_GetLinearVelocity(Handle);
        
        public void SetLinearVelocity(float3 velocity) => SafeBindings.JPH_BodyCreationSettings_SetLinearVelocity(Handle, velocity);
        
        public float3 GetAngularVelocity() => SafeBindings.JPH_BodyCreationSettings_GetAngularVelocity(Handle);
        
        public void SetAngularVelocity(float3 velocity) => SafeBindings.JPH_BodyCreationSettings_SetAngularVelocity(Handle, velocity);
        
        public MotionType GetMotionType() => SafeBindings.JPH_BodyCreationSettings_GetMotionType(Handle);
        
        public void SetMotionType(MotionType value) => SafeBindings.JPH_BodyCreationSettings_SetMotionType(Handle, value);
        
        public AllowedDOFs GetAllowedDOFs() => SafeBindings.JPH_BodyCreationSettings_GetAllowedDOFs(Handle);
        
        public void SetAllowedDOFs(AllowedDOFs value) => SafeBindings.JPH_BodyCreationSettings_SetAllowedDOFs(Handle, value);
        
        #endregion
        
    }
}
