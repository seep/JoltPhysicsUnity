using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct Body : IEquatable<Body>
    {
        #region IEquatable
        
        public bool Equals(Body other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is Body other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(Body lhs, Body rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(Body lhs, Body rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_Body
        
        public BodyID GetID() => SafeBindings.JPH_Body_GetID(Handle);
        
        public BodyType GetBodyType() => SafeBindings.JPH_Body_GetBodyType(Handle);
        
        public AABox GetWorldSpaceBounds() => SafeBindings.JPH_Body_GetWorldSpaceBounds(Handle);
        
        public float3 GetWorldSpaceSurfaceNormal(uint subShapeID, rvec3 position) => SafeBindings.JPH_Body_GetWorldSpaceSurfaceNormal(Handle, subShapeID, position);
        
        public bool IsActive() => SafeBindings.JPH_Body_IsActive(Handle);
        
        public bool IsStatic() => SafeBindings.JPH_Body_IsStatic(Handle);
        
        public bool IsKinematic() => SafeBindings.JPH_Body_IsKinematic(Handle);
        
        public bool IsDynamic() => SafeBindings.JPH_Body_IsDynamic(Handle);
        
        public bool IsSensor() => SafeBindings.JPH_Body_IsSensor(Handle);
        
        public void SetIsSensor(bool value) => SafeBindings.JPH_Body_SetIsSensor(Handle, value);
        
        public void SetCollideKinematicVsNonDynamic(bool value) => SafeBindings.JPH_Body_SetCollideKinematicVsNonDynamic(Handle, value);
        
        public bool GetCollideKinematicVsNonDynamic() => SafeBindings.JPH_Body_GetCollideKinematicVsNonDynamic(Handle);
        
        public void SetUseManifoldReduction(bool value) => SafeBindings.JPH_Body_SetUseManifoldReduction(Handle, value);
        
        public bool GetUseManifoldReduction() => SafeBindings.JPH_Body_GetUseManifoldReduction(Handle);
        
        public bool GetUseManifoldReductionWithBody(Body other) => SafeBindings.JPH_Body_GetUseManifoldReductionWithBody(Handle, other.Handle);
        
        public void SetApplyGyroscopicForce(bool value) => SafeBindings.JPH_Body_SetApplyGyroscopicForce(Handle, value);
        
        public bool GetApplyGyroscopicForce() => SafeBindings.JPH_Body_GetApplyGyroscopicForce(Handle);
        
        public MotionProperties GetMotionProperties() => new MotionProperties(SafeBindings.JPH_Body_GetMotionProperties(Handle));
        
        public MotionType GetMotionType() => SafeBindings.JPH_Body_GetMotionType(Handle);
        
        public void SetMotionType(MotionType motion) => SafeBindings.JPH_Body_SetMotionType(Handle, motion);
        
        public bool GetAllowSleeping() => SafeBindings.JPH_Body_GetAllowSleeping(Handle);
        
        public void SetAllowSleeping(bool allowSleeping) => SafeBindings.JPH_Body_SetAllowSleeping(Handle, allowSleeping);
        
        public void ResetSleepTimer() => SafeBindings.JPH_Body_ResetSleepTimer(Handle);
        
        public float GetFriction() => SafeBindings.JPH_Body_GetFriction(Handle);
        
        public void SetFriction(float friction) => SafeBindings.JPH_Body_SetFriction(Handle, friction);
        
        public float GetRestitution() => SafeBindings.JPH_Body_GetRestitution(Handle);
        
        public void SetRestitution(float restitution) => SafeBindings.JPH_Body_SetRestitution(Handle, restitution);
        
        public float3 GetLinearVelocity() => SafeBindings.JPH_Body_GetLinearVelocity(Handle);
        
        public void SetLinearVelocity(float3 velocity) => SafeBindings.JPH_Body_SetLinearVelocity(Handle, velocity);
        
        public float3 GetAngularVelocity() => SafeBindings.JPH_Body_GetAngularVelocity(Handle);
        
        public void SetAngularVelocity(float3 velocity) => SafeBindings.JPH_Body_SetAngularVelocity(Handle, velocity);
        
        public void AddForce(float3 force) => SafeBindings.JPH_Body_AddForce(Handle, force);
        
        public void AddForceAtPosition(float3 force, rvec3 position) => SafeBindings.JPH_Body_AddForceAtPosition(Handle, force, position);
        
        public void AddTorque(float3 force) => SafeBindings.JPH_Body_AddTorque(Handle, force);
        
        public float3 GetAccumulatedForce() => SafeBindings.JPH_Body_GetAccumulatedForce(Handle);
        
        public float3 GetAccumulatedTorque() => SafeBindings.JPH_Body_GetAccumulatedTorque(Handle);
        
        public void AddImpulse(float3 impulse) => SafeBindings.JPH_Body_AddImpulse(Handle, impulse);
        
        public void AddImpulseAtPosition(float3 impulse, rvec3 position) => SafeBindings.JPH_Body_AddImpulseAtPosition(Handle, impulse, position);
        
        public void AddAngularImpulse(float3 angularImpulse) => SafeBindings.JPH_Body_AddAngularImpulse(Handle, angularImpulse);
        
        public rvec3 GetPosition() => SafeBindings.JPH_Body_GetPosition(Handle);
        
        public quaternion GetRotation() => SafeBindings.JPH_Body_GetRotation(Handle);
        
        public rvec3 GetCenterOfMassPosition() => SafeBindings.JPH_Body_GetCenterOfMassPosition(Handle);
        
        public rmatrix4x4 GetWorldTransform() => SafeBindings.JPH_Body_GetWorldTransform(Handle);
        
        public rmatrix4x4 GetCenterOfMassTransform() => SafeBindings.JPH_Body_GetCenterOfMassTransform(Handle);
        
        public void SetUserData(ulong userData) => SafeBindings.JPH_Body_SetUserData(Handle, userData);
        
        public ulong GetUserData() => SafeBindings.JPH_Body_GetUserData(Handle);
        
        #endregion
        
    }
}
