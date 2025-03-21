using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct BodyInterface : IEquatable<BodyInterface>
    {
        #region IEquatable
        
        public bool Equals(BodyInterface other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BodyInterface other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BodyInterface lhs, BodyInterface rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BodyInterface lhs, BodyInterface rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_BodyInterface
        
        public void DestroyBody(BodyID bodyID) => Bindings.JPH_BodyInterface_DestroyBody(Handle, bodyID);
        
        public BodyID CreateAndAddBody(BodyCreationSettings settings, Activation activation) => Bindings.JPH_BodyInterface_CreateAndAddBody(Handle, settings.Handle, activation);
        
        public Body CreateBody(BodyCreationSettings settings) => new Body { Handle = Bindings.JPH_BodyInterface_CreateBody(Handle, settings.Handle) };
        
        public Body CreateBodyWithID(BodyID bodyID, BodyCreationSettings settings) => new Body { Handle = Bindings.JPH_BodyInterface_CreateBodyWithID(Handle, bodyID, settings.Handle) };
        
        public Body CreateBodyWithoutID(BodyCreationSettings settings) => new Body { Handle = Bindings.JPH_BodyInterface_CreateBodyWithoutID(Handle, settings.Handle) };
        
        public void DestroyBodyWithoutID(Body body) => Bindings.JPH_BodyInterface_DestroyBodyWithoutID(Handle, body.Handle);
        
        public bool AssignBodyID(Body body) => Bindings.JPH_BodyInterface_AssignBodyID(Handle, body.Handle);
        
        public bool AssignBodyID(Body body, BodyID bodyID) => Bindings.JPH_BodyInterface_AssignBodyID(Handle, body.Handle, bodyID);
        
        public Body UnassignBodyID(BodyID bodyID) => new Body { Handle = Bindings.JPH_BodyInterface_UnassignBodyID(Handle, bodyID) };
        
        public Body CreateSoftBody(SoftBodyCreationSettings settings) => new Body { Handle = Bindings.JPH_BodyInterface_CreateSoftBody(Handle, settings.Handle) };
        
        public Body CreateSoftBodyWithID(BodyID bodyID, SoftBodyCreationSettings settings) => new Body { Handle = Bindings.JPH_BodyInterface_CreateSoftBodyWithID(Handle, bodyID, settings.Handle) };
        
        public Body CreateSoftBodyWithoutID(SoftBodyCreationSettings settings) => new Body { Handle = Bindings.JPH_BodyInterface_CreateSoftBodyWithoutID(Handle, settings.Handle) };
        
        public BodyID CreateAndAddSoftBody(SoftBodyCreationSettings settings, Activation activation) => Bindings.JPH_BodyInterface_CreateAndAddSoftBody(Handle, settings.Handle, activation);
        
        public void AddBody(BodyID bodyID, Activation activation) => Bindings.JPH_BodyInterface_AddBody(Handle, bodyID, activation);
        
        public void RemoveBody(BodyID bodyID) => Bindings.JPH_BodyInterface_RemoveBody(Handle, bodyID);
        
        public void RemoveAndDestroyBody(BodyID bodyID) => Bindings.JPH_BodyInterface_RemoveAndDestroyBody(Handle, bodyID);
        
        public bool IsActive(BodyID bodyID) => Bindings.JPH_BodyInterface_IsActive(Handle, bodyID);
        
        public bool IsAdded(BodyID bodyID) => Bindings.JPH_BodyInterface_IsAdded(Handle, bodyID);
        
        public bool GetBodyType(BodyID bodyID) => Bindings.JPH_BodyInterface_GetBodyType(Handle, bodyID);
        
        public void SetLinearVelocity(BodyID bodyID, float3 velocity) => Bindings.JPH_BodyInterface_SetLinearVelocity(Handle, bodyID, velocity);
        
        public float3 GetLinearVelocity(BodyID bodyID) => Bindings.JPH_BodyInterface_GetLinearVelocity(Handle, bodyID);
        
        public rvec3 GetCenterOfMassPosition(BodyID bodyID) => Bindings.JPH_BodyInterface_GetCenterOfMassPosition(Handle, bodyID);
        
        public MotionType GetMotionType(BodyID bodyID) => Bindings.JPH_BodyInterface_GetMotionType(Handle, bodyID);
        
        public void SetMotionType(BodyID bodyID, MotionType motion, Activation activation) => Bindings.JPH_BodyInterface_SetMotionType(Handle, bodyID, motion, activation);
        
        public float GetRestitution(BodyID bodyID) => Bindings.JPH_BodyInterface_GetRestitution(Handle, bodyID);
        
        public void SetRestitution(BodyID bodyID, float restitution) => Bindings.JPH_BodyInterface_SetRestitution(Handle, bodyID, restitution);
        
        public float GetFriction(BodyID bodyID) => Bindings.JPH_BodyInterface_GetFriction(Handle, bodyID);
        
        public void SetFriction(BodyID bodyID, float friction) => Bindings.JPH_BodyInterface_SetFriction(Handle, bodyID, friction);
        
        public void SetPosition(BodyID bodyID, rvec3 position, Activation activation) => Bindings.JPH_BodyInterface_SetPosition(Handle, bodyID, position, activation);
        
        public rvec3 GetPosition(BodyID bodyID) => Bindings.JPH_BodyInterface_GetPosition(Handle, bodyID);
        
        public void SetRotation(BodyID bodyID, quaternion rotation, Activation activation) => Bindings.JPH_BodyInterface_SetRotation(Handle, bodyID, rotation, activation);
        
        public quaternion GetRotation(BodyID bodyID) => Bindings.JPH_BodyInterface_GetRotation(Handle, bodyID);
        
        public void SetPositionAndRotation(BodyID bodyID, rvec3 position, quaternion rotation, Activation activation) => Bindings.JPH_BodyInterface_SetPositionAndRotation(Handle, bodyID, position, rotation, activation);
        
        public void SetPositionAndRotationWhenChanged(BodyID bodyID, rvec3 position, quaternion rotation, Activation activation) => Bindings.JPH_BodyInterface_SetPositionAndRotationWhenChanged(Handle, bodyID, position, rotation, activation);
        
        public void GetPositionAndRotation(BodyID bodyID, out rvec3 position, out quaternion rotation) => Bindings.JPH_BodyInterface_GetPositionAndRotation(Handle, bodyID, out position, out rotation);
        
        public void SetPositionRotationAndVelocity(BodyID bodyID, rvec3 position, quaternion rotation, float3 linearVelocity, float3 angularVelocity) => Bindings.JPH_BodyInterface_SetPositionRotationAndVelocity(Handle, bodyID, position, rotation, linearVelocity, angularVelocity);
        
        public Shape GetShape(BodyID bodyID) => new Shape { Handle = Bindings.JPH_BodyInterface_GetShape(Handle, bodyID) };
        
        public void SetShape(BodyID bodyID, Shape shape, bool updateMassProperties, Activation activation) => Bindings.JPH_BodyInterface_SetShape(Handle, bodyID, shape.Handle, updateMassProperties, activation);
        
        public void NotifyShapeChanged(BodyID bodyID, float3 previousCenterOfMass, bool updateMassProperties, Activation activation) => Bindings.JPH_BodyInterface_NotifyShapeChanged(Handle, bodyID, previousCenterOfMass, updateMassProperties, activation);
        
        public void ActivateBody(BodyID bodyID) => Bindings.JPH_BodyInterface_ActivateBody(Handle, bodyID);
        
        public void DeactivateBody(BodyID bodyID) => Bindings.JPH_BodyInterface_DeactivateBody(Handle, bodyID);
        
        public void SetObjectLayer(BodyID bodyID, ObjectLayer layer) => Bindings.JPH_BodyInterface_SetObjectLayer(Handle, bodyID, layer);
        
        public ObjectLayer GetObjectLayer(BodyID bodyID) => Bindings.JPH_BodyInterface_GetObjectLayer(Handle, bodyID);
        
        public rmatrix4x4 GetWorldTransform(BodyID bodyID) => Bindings.JPH_BodyInterface_GetWorldTransform(Handle, bodyID);
        
        public rmatrix4x4 GetCenterOfMassTransform(BodyID bodyID) => Bindings.JPH_BodyInterface_GetCenterOfMassTransform(Handle, bodyID);
        
        public void MoveKinematic(BodyID bodyID, rvec3 targetPosition, quaternion targetRotation, float deltaTime) => Bindings.JPH_BodyInterface_MoveKinematic(Handle, bodyID, targetPosition, targetRotation, deltaTime);
        
        public bool ApplyBuoyancyImpulse(BodyID bodyID, rvec3 surfacePosition, float3 surfaceNormal, float buoyancy, float linearDrag, float angularDrag, float3 fluidVelocity, float3 gravity, float deltaTime) => Bindings.JPH_BodyInterface_ApplyBuoyancyImpulse(Handle, bodyID, surfacePosition, surfaceNormal, buoyancy, linearDrag, angularDrag, fluidVelocity, gravity, deltaTime);
        
        public void SetLinearAndAngularVelocity(BodyID bodyID, float3 linearVelocity, float3 angularVelocity) => Bindings.JPH_BodyInterface_SetLinearAndAngularVelocity(Handle, bodyID, linearVelocity, angularVelocity);
        
        public void GetLinearAndAngularVelocity(BodyID bodyID, out float3 linearVelocity, out float3 angularVelocity) => Bindings.JPH_BodyInterface_GetLinearAndAngularVelocity(Handle, bodyID, out linearVelocity, out angularVelocity);
        
        public void AddLinearVelocity(BodyID bodyID, float3 linearVelocity) => Bindings.JPH_BodyInterface_AddLinearVelocity(Handle, bodyID, linearVelocity);
        
        public void AddLinearAndAngularVelocity(BodyID bodyID, float3 linearVelocity, float3 angularVelocity) => Bindings.JPH_BodyInterface_AddLinearAndAngularVelocity(Handle, bodyID, linearVelocity, angularVelocity);
        
        public void SetAngularVelocity(BodyID bodyID, float3 angularVelocity) => Bindings.JPH_BodyInterface_SetAngularVelocity(Handle, bodyID, angularVelocity);
        
        public float3 GetAngularVelocity(BodyID bodyID) => Bindings.JPH_BodyInterface_GetAngularVelocity(Handle, bodyID);
        
        public float3 GetPointVelocity(BodyID bodyID, rvec3 point) => Bindings.JPH_BodyInterface_GetPointVelocity(Handle, bodyID, point);
        
        public void AddForce(BodyID bodyID, float3 force) => Bindings.JPH_BodyInterface_AddForce(Handle, bodyID, force);
        
        public void AddForce(BodyID bodyID, float3 force, rvec3 point) => Bindings.JPH_BodyInterface_AddForce(Handle, bodyID, force, point);
        
        public void AddTorque(BodyID bodyID, float3 torque) => Bindings.JPH_BodyInterface_AddTorque(Handle, bodyID, torque);
        
        public void AddForceAndTorque(BodyID bodyID, float3 force, float3 torque) => Bindings.JPH_BodyInterface_AddForceAndTorque(Handle, bodyID, force, torque);
        
        public void AddImpulse(BodyID bodyID, float3 impulse) => Bindings.JPH_BodyInterface_AddImpulse(Handle, bodyID, impulse);
        
        public void AddImpulse(BodyID bodyID, float3 impulse, rvec3 point) => Bindings.JPH_BodyInterface_AddImpulse(Handle, bodyID, impulse, point);
        
        public void AddAngularImpulse(BodyID bodyID, float3 angularImpulse) => Bindings.JPH_BodyInterface_AddAngularImpulse(Handle, bodyID, angularImpulse);
        
        public void SetMotionQuality(BodyID bodyID, MotionQuality quality) => Bindings.JPH_BodyInterface_SetMotionQuality(Handle, bodyID, quality);
        
        public MotionQuality GetMotionQuality(BodyID bodyID) => Bindings.JPH_BodyInterface_GetMotionQuality(Handle, bodyID);
        
        public float4x4 GetInverseInertia(BodyID bodyID) => Bindings.JPH_BodyInterface_GetInverseInertia(Handle, bodyID);
        
        public void SetGravityFactor(BodyID bodyID, float gravityFactor) => Bindings.JPH_BodyInterface_SetGravityFactor(Handle, bodyID, gravityFactor);
        
        public float GetGravityFactor(BodyID bodyID) => Bindings.JPH_BodyInterface_GetGravityFactor(Handle, bodyID);
        
        public void InvalidateContactCache(BodyID bodyID) => Bindings.JPH_BodyInterface_InvalidateContactCache(Handle, bodyID);
        
        public void SetUserData(BodyID bodyID, ulong data) => Bindings.JPH_BodyInterface_SetUserData(Handle, bodyID, data);
        
        public ulong GetUserData(BodyID bodyID) => Bindings.JPH_BodyInterface_GetUserData(Handle, bodyID);
        
        #endregion
        
    }
}
