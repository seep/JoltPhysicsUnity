using Unity.Mathematics;

using static Jolt.SafeBindings;

namespace Jolt
{
    public struct BodyInterface
    {
        internal NativeHandle<JPH_BodyInterface> Handle;

        internal BodyInterface(NativeHandle<JPH_BodyInterface> handle)
        {
            Handle = handle;
        }

        public Body CreateBody(BodyCreationSettings settings)
        {
            return new Body(JPH_BodyInterface_CreateBody(Handle, settings.Handle)); // TODO why does this not return a body ID?
        }

        public BodyID CreateAndAddBody(BodyCreationSettings settings, Activation activation)
        {
            return JPH_BodyInterface_CreateAndAddBody(Handle, settings.Handle, activation);
        }

        public void AddBody(BodyID bodyID, Activation activation)
        {
            JPH_BodyInterface_AddBody(Handle, bodyID, activation);
        }

        public void SetLinearVelocity(BodyID bodyID, in float3 velocity)
        {
            JPH_BodyInterface_SetLinearVelocity(Handle, bodyID, velocity);
        }

        public bool IsActive(BodyID bodyID)
        {
            return JPH_BodyInterface_IsActive(Handle, bodyID);
        }

        public rmatrix4x4 GetWorldTransform(BodyID bodyID)
        {
            return JPH_BodyInterface_GetWorldTransform(Handle, bodyID);
        }

        public rvec3 GetCenterOfMassPosition(BodyID bodyID)
        {
            return JPH_BodyInterface_GetCenterOfMassPosition(Handle, bodyID);
        }

        public float3 GetLinearVelocity(BodyID bodyID)
        {
            return JPH_BodyInterface_GetLinearVelocity(Handle, bodyID);
        }

        public void RemoveBody(BodyID bodyID)
        {
            JPH_BodyInterface_RemoveBody(Handle, bodyID);
        }

        public void DestroyBody(BodyID bodyID)
        {
            JPH_BodyInterface_DestroyBody(Handle, bodyID);
        }
    }
}
