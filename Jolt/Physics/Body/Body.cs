using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

namespace Jolt
{
    public struct Body : IEquatable<Body>
    {
        internal NativeHandle<JPH_Body> Handle;

        internal Body(NativeHandle<JPH_Body> handle)
        {
            Handle = handle;
        }

        #region JPH_Body

        public BodyID GetID()
        {
            return JPH_Body_GetID(Handle);
        }

        public BodyType GetBodyType()
        {
            return JPH_Body_GetBodyType(Handle);
        }

        public AABox GetBodyWorldSpaceBounds()
        {
            return JPH_Body_GetWorldSpaceBounds(Handle);
        }

        public float3 GetWorldSpaceSurfaceNormal(uint subShapeID, double3 position)
        {
            return JPH_Body_GetWorldSpaceSurfaceNormal(Handle, subShapeID, position);
        }

        public bool IsActive()
        {
            return JPH_Body_IsActive(Handle);
        }

        public bool IsStatic()
        {
            return JPH_Body_IsStatic(Handle);
        }

        public bool IsKinematic()
        {
            return JPH_Body_IsKinematic(Handle);
        }

        public bool IsDynamic()
        {
            return JPH_Body_IsDynamic(Handle);
        }

        public bool IsSensor()
        {
            return JPH_Body_IsSensor(Handle);
        }

        public void SetIsSensor(bool value)
        {
            JPH_Body_SetIsSensor(Handle, value);
        }

        public void SetCollideKinematicVsNonDynamic(bool value)
        {
            JPH_Body_SetCollideKinematicVsNonDynamic(Handle, value);
        }

        public bool GetCollideKinematicVsNonDynamic()
        {
            return JPH_Body_GetCollideKinematicVsNonDynamic(Handle);
        }

        public void SetUseManifoldReduction(bool value)
        {
            JPH_Body_SetUseManifoldReduction(Handle, value);
        }

        public bool GetUseManifoldReduction()
        {
            return JPH_Body_GetUseManifoldReduction(Handle);
        }

        public bool GetUseManifoldReductionWithBody(Body other)
        {
            return JPH_Body_GetUseManifoldReductionWithBody(Handle, other.Handle);
        }

        public void SetApplyGyroscopicForce(bool value)
        {
            JPH_Body_SetApplyGyroscopicForce(Handle, value);
        }

        public bool GetApplyGyroscopicForce()
        {
            return JPH_Body_GetApplyGyroscopicForce(Handle);
        }

        public MotionProperties GetMotionProperties()
        {
            return new MotionProperties(JPH_Body_GetMotionProperties(Handle));
        }

        public MotionType GetMotionType()
        {
            return JPH_Body_GetMotionType(Handle);
        }

        public void SetMotionType(MotionType motion)
        {
            JPH_Body_SetMotionType(Handle, motion);
        }

        public void SetAllowSleeping(bool allowSleeping)
        {
            JPH_Body_SetAllowSleeping(Handle, allowSleeping);
        }

        public void ResetSleepTimer()
        {
            JPH_Body_ResetSleepTimer(Handle);
        }

        public bool GetAllowSleeping()
        {
            return JPH_Body_GetAllowSleeping(Handle);
        }

        public float GetFriction()
        {
            return JPH_Body_GetFriction(Handle);
        }

        public void SetFriction(float friction)
        {
            JPH_Body_SetFriction(Handle, friction);
        }

        public float GetRestitution()
        {
            return JPH_Body_GetRestitution(Handle);
        }

        public void SetRestitution(float restitution)
        {
            JPH_Body_SetRestitution(Handle, restitution);
        }

        public float3 GetLinearVelocity()
        {
            return JPH_Body_GetLinearVelocity(Handle);
        }

        public void SetLinearVelocity(float3 velocity)
        {
            JPH_Body_SetLinearVelocity(Handle, velocity);
        }

        public float3 GetAngularVelocity()
        {
            return JPH_Body_GetAngularVelocity(Handle);
        }

        public void SetAngularVelocity(float3 velocity)
        {
            JPH_Body_SetAngularVelocity(Handle, velocity);
        }

        public void AddForce(float3 force)
        {
            JPH_Body_AddForce(Handle, force);
        }

        public void AddForceAtPosition(float3 force, double3 position)
        {
            JPH_Body_AddForceAtPosition(Handle, force, position);
        }

        public void AddTorque(float3 force)
        {
            JPH_Body_AddTorque(Handle, force);
        }

        public float3 GetAccumulatedForce()
        {
            return JPH_Body_GetAccumulatedForce(Handle);
        }

        public float3 GetAccumulatedTorque()
        {
            return JPH_Body_GetAccumulatedTorque(Handle);
        }

        public void AddImpulse(float3 impulse)
        {
            JPH_Body_AddImpulse(Handle, impulse);
        }

        public void AddImpulseAtPosition(float3 impulse, double3 position)
        {
            JPH_Body_AddImpulseAtPosition(Handle, impulse, position);
        }

        public void AddAngularImpulse(float3 impulse)
        {
            JPH_Body_AddAngularImpulse(Handle, impulse);
        }

        public double3 GetPosition()
        {
            return JPH_Body_GetPosition(Handle);
        }

        public quaternion GetRotation()
        {
            return JPH_Body_GetRotation(Handle);
        }

        public double3 GetCenterOfMassPosition()
        {
            return JPH_Body_GetCenterOfMassPosition(Handle);
        }

        public rmatrix4x4 GetWorldTransform()
        {
            return JPH_Body_GetWorldTransform(Handle);
        }

        public rmatrix4x4 GetCenterOfMassTransform()
        {
            return JPH_Body_GetCenterOfMassTransform(Handle);
        }

        public void SetUserData(ulong userData)
        {
            JPH_Body_SetUserData(Handle, userData);
        }

        public ulong GetUserData()
        {
            return JPH_Body_GetUserData(Handle);
        }

        #endregion

        #region IEquatable

        public bool Equals(Body other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is Body other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
