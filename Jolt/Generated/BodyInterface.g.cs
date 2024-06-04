using System;
using Jolt;
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
        
        public void DestroyBody(BodyID bodyID) => SafeBindings.JPH_BodyInterface_DestroyBody(Handle, bodyID);
        
        public BodyID CreateAndAddBody(BodyCreationSettings settings, Activation activation) => SafeBindings.JPH_BodyInterface_CreateAndAddBody(Handle, settings.Handle, activation);
        
        public Body CreateBody(BodyCreationSettings settings) => new Body(SafeBindings.JPH_BodyInterface_CreateBody(Handle, settings.Handle));
        
        public Body CreateSoftBody(SoftBodyCreationSettings settings) => new Body(SafeBindings.JPH_BodyInterface_CreateSoftBody(Handle, settings.Handle));
        
        public Body CreateBodyWithID(BodyID bodyID, BodyCreationSettings settings) => new Body(SafeBindings.JPH_BodyInterface_CreateBodyWithID(Handle, bodyID, settings.Handle));
        
        public Body CreateBodyWithoutID(BodyCreationSettings settings) => new Body(SafeBindings.JPH_BodyInterface_CreateBodyWithoutID(Handle, settings.Handle));
        
        public void DestroyBodyWithoutID(Body body) => SafeBindings.JPH_BodyInterface_DestroyBodyWithoutID(Handle, body.Handle);
        
        public bool AssignBodyID(Body body) => SafeBindings.JPH_BodyInterface_AssignBodyID(Handle, body.Handle);
        
        public bool AssignBodyID2(Body body, BodyID bodyID) => SafeBindings.JPH_BodyInterface_AssignBodyID2(Handle, body.Handle, bodyID);
        
        public Body UnassignBodyID(BodyID bodyID) => new Body(SafeBindings.JPH_BodyInterface_UnassignBodyID(Handle, bodyID));
        
        public void AddBody(BodyID bodyID, Activation activation) => SafeBindings.JPH_BodyInterface_AddBody(Handle, bodyID, activation);
        
        public void RemoveBody(BodyID bodyID) => SafeBindings.JPH_BodyInterface_RemoveBody(Handle, bodyID);
        
        public bool IsActive(BodyID bodyID) => SafeBindings.JPH_BodyInterface_IsActive(Handle, bodyID);
        
        public bool IsAdded(BodyID bodyID) => SafeBindings.JPH_BodyInterface_IsAdded(Handle, bodyID);
        
        public bool GetBodyType(BodyID bodyID) => SafeBindings.JPH_BodyInterface_GetBodyType(Handle, bodyID);
        
        public void SetLinearVelocity(BodyID bodyID, float3 velocity) => SafeBindings.JPH_BodyInterface_SetLinearVelocity(Handle, bodyID, velocity);
        
        public float3 GetLinearVelocity(BodyID bodyID) => SafeBindings.JPH_BodyInterface_GetLinearVelocity(Handle, bodyID);
        
        public rvec3 GetCenterOfMassPosition(BodyID bodyID) => SafeBindings.JPH_BodyInterface_GetCenterOfMassPosition(Handle, bodyID);
        
        public MotionType GetMotionType(BodyID bodyID) => SafeBindings.JPH_BodyInterface_GetMotionType(Handle, bodyID);
        
        public void SetMotionType(BodyID bodyID, MotionType motion, Activation activation) => SafeBindings.JPH_BodyInterface_SetMotionType(Handle, bodyID, motion, activation);
        
        public float GetRestitution(BodyID bodyID) => SafeBindings.JPH_BodyInterface_GetRestitution(Handle, bodyID);
        
        public void SetRestitution(BodyID bodyID, float restitution) => SafeBindings.JPH_BodyInterface_SetRestitution(Handle, bodyID, restitution);
        
        public float GetFriction(BodyID bodyID) => SafeBindings.JPH_BodyInterface_GetFriction(Handle, bodyID);
        
        public void SetFriction(BodyID bodyID, float friction) => SafeBindings.JPH_BodyInterface_SetFriction(Handle, bodyID, friction);
        
        public void SetPosition(BodyID bodyID, rvec3 position, Activation activation) => SafeBindings.JPH_BodyInterface_SetPosition(Handle, bodyID, position, activation);
        
        public rvec3 GetPosition(BodyID bodyID) => SafeBindings.JPH_BodyInterface_GetPosition(Handle, bodyID);
        
        public void SetRotation(BodyID bodyID, quaternion rotation, Activation activation) => SafeBindings.JPH_BodyInterface_SetRotation(Handle, bodyID, rotation, activation);
        
        public quaternion GetRotation(BodyID bodyID) => SafeBindings.JPH_BodyInterface_GetRotation(Handle, bodyID);
        
        public rmatrix4x4 GetWorldTransform(BodyID bodyID) => SafeBindings.JPH_BodyInterface_GetWorldTransform(Handle, bodyID);
        
        #endregion
        
    }
}
