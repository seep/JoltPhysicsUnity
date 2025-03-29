using System;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_BodyInterface_DestroyBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_DestroyBody(@interface, bodyID);

            // TODO mark any active body handles for this bodyID as disposed
        }

        public static BodyID JPH_BodyInterface_CreateAndAddBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings, Activation activation)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_CreateAndAddBody(@interface, settings, activation);
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_BodyInterface_CreateBody(@interface, settings));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBodyWithID(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_BodyInterface_CreateBodyWithID(@interface, bodyID, settings));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBodyWithoutID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_BodyInterface_CreateBodyWithoutID(@interface, settings));
        }

        public static void JPH_BodyInterface_DestroyBodyWithoutID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_DestroyBodyWithoutID(@interface, body);
        }

        public static bool JPH_BodyInterface_AssignBodyID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_AssignBodyID(@interface, body);
        }

        public static bool JPH_BodyInterface_AssignBodyID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_AssignBodyID2(@interface, body, bodyID);
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_UnassignBodyID(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            // TODO is CreateHandle correct? Does that create a duplicate pointer to the body?

            // return CreateHandle(UnsafeBindings.JPH_BodyInterface_UnassignBodyID(GetPointer(@interface), bodyID));

            throw new NotImplementedException();
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateSoftBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_SoftBodyCreationSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_BodyInterface_CreateSoftBody(@interface, settings));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateSoftBodyWithID(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, NativeHandle<JPH_SoftBodyCreationSettings> settings)
        {
            return CreateHandle(UnsafeBindings.JPH_BodyInterface_CreateSoftBodyWithID(@interface, bodyID, settings));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateSoftBodyWithoutID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_SoftBodyCreationSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_BodyInterface_CreateSoftBodyWithoutID(@interface, settings));
        }

        public static BodyID JPH_BodyInterface_CreateAndAddSoftBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_SoftBodyCreationSettings> settings, Activation activation)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_CreateAndAddSoftBody(@interface, settings, activation);
        }

        public static void JPH_BodyInterface_AddBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, Activation activation)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_AddBody(@interface, bodyID, activation);
        }

        public static void JPH_BodyInterface_RemoveBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_RemoveBody(@interface, bodyID);
        }

        public static void JPH_BodyInterface_RemoveAndDestroyBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_RemoveAndDestroyBody(@interface, bodyID);
        }

        public static bool JPH_BodyInterface_IsActive(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_IsActive(@interface, bodyID);
        }

        public static bool JPH_BodyInterface_IsAdded(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_IsAdded(@interface, bodyID);
        }

        public static bool JPH_BodyInterface_GetBodyType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_IsAdded(@interface, bodyID);
        }

        public static void JPH_BodyInterface_SetLinearVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 velocity)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetLinearVelocity(@interface, bodyID, &velocity);
        }

        public static float3 JPH_BodyInterface_GetLinearVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_BodyInterface_GetLinearVelocity(@interface, bodyID, &result);
            return result;
        }

        public static rvec3 JPH_BodyInterface_GetCenterOfMassPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            rvec3 result;
            UnsafeBindings.JPH_BodyInterface_GetCenterOfMassPosition(@interface, bodyID, &result);
            return result;
        }

        public static MotionType JPH_BodyInterface_GetMotionType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_GetMotionType(@interface, bodyID);
        }

        public static void JPH_BodyInterface_SetMotionType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, MotionType motion, Activation activation)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetMotionType(@interface, bodyID, motion, activation);
        }

        public static float JPH_BodyInterface_GetRestitution(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_GetRestitution(@interface, bodyID);
        }

        public static void JPH_BodyInterface_SetRestitution(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float restitution)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetRestitution(@interface, bodyID, restitution);
        }

        public static float JPH_BodyInterface_GetFriction(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_GetFriction(@interface, bodyID);
        }

        public static void JPH_BodyInterface_SetFriction(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float friction)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetFriction(@interface, bodyID, friction);
        }

        public static void JPH_BodyInterface_SetPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, rvec3 position, Activation activation)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetPosition(@interface, bodyID, &position, activation);
        }

        public static rvec3 JPH_BodyInterface_GetPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            rvec3 result;
            UnsafeBindings.JPH_BodyInterface_GetPosition(@interface, bodyID, &result);
            return result;
        }

        public static void JPH_BodyInterface_SetRotation(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, quaternion rotation, Activation activation)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetRotation(@interface, bodyID, &rotation, activation);
        }

        public static quaternion JPH_BodyInterface_GetRotation(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            quaternion result;
            UnsafeBindings.JPH_BodyInterface_GetRotation(@interface, bodyID, &result);
            return result;
        }

        public static void JPH_BodyInterface_SetPositionAndRotation(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, rvec3 position, quaternion rotation, Activation activation)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetPositionAndRotation(@interface, bodyID, &position, &rotation, activation);
        }

        public static void JPH_BodyInterface_SetPositionAndRotationWhenChanged(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, rvec3 position, quaternion rotation, Activation activation)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetPositionAndRotationWhenChanged(@interface, bodyID, &position, &rotation, activation);
        }

        public static void JPH_BodyInterface_GetPositionAndRotation(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, out rvec3 position, out quaternion rotation)
        {
            AssertInitialized();

            position = default;
            rotation = default;

            fixed (rvec3* positionPtr = &position)
            fixed (quaternion* rotationPtr = &rotation)
            {
                UnsafeBindings.JPH_BodyInterface_GetPositionAndRotation(@interface, bodyID, positionPtr, rotationPtr);
            }
        }

        public static void JPH_BodyInterface_SetPositionRotationAndVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, rvec3 position, quaternion rotation, float3 linearVelocity, float3 angularVelocity)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetPositionRotationAndVelocity(@interface, bodyID, &position, &rotation, &linearVelocity, &angularVelocity);
        }

        public static NativeHandle<JPH_Shape> JPH_BodyInterface_GetShape(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_BodyInterface_GetShape(@interface, bodyID)); // TODO reuse existing shape handle
        }

        public static void JPH_BodyInterface_SetShape(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, NativeHandle<JPH_Shape> shape, bool updateMassProperties, Activation activation)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetShape(@interface, bodyID, shape, updateMassProperties, activation);
        }

        public static void JPH_BodyInterface_NotifyShapeChanged(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 previousCenterOfMass, bool updateMassProperties, Activation activation)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_NotifyShapeChanged(@interface, bodyID, &previousCenterOfMass, updateMassProperties, activation);
        }

        public static void JPH_BodyInterface_ActivateBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_ActivateBody(@interface, bodyID);
        }

        public static void JPH_BodyInterface_DeactivateBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_DeactivateBody(@interface, bodyID);
        }

        public static void JPH_BodyInterface_SetObjectLayer(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, ObjectLayer layer)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetObjectLayer(@interface, bodyID, layer);
        }

        public static ObjectLayer JPH_BodyInterface_GetObjectLayer(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_GetObjectLayer(@interface, bodyID);
        }

        public static rmatrix4x4 JPH_BodyInterface_GetWorldTransform(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            rmatrix4x4 result;
            UnsafeBindings.JPH_BodyInterface_GetWorldTransform(@interface, bodyID, &result);
            return result;
        }

        public static rmatrix4x4 JPH_BodyInterface_GetCenterOfMassTransform(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            rmatrix4x4 result;
            UnsafeBindings.JPH_BodyInterface_GetCenterOfMassTransform(@interface, bodyID, &result);
            return result;
        }

        public static void JPH_BodyInterface_MoveKinematic(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, rvec3 targetPosition, quaternion targetRotation, float deltaTime)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_MoveKinematic(@interface, bodyID, &targetPosition, &targetRotation, deltaTime);
        }

        public static bool JPH_BodyInterface_ApplyBuoyancyImpulse(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, rvec3 surfacePosition, float3 surfaceNormal, float buoyancy, float linearDrag, float angularDrag, float3 fluidVelocity, float3 gravity, float deltaTime)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_ApplyBuoyancyImpulse(@interface, bodyID, &surfacePosition, &surfaceNormal, buoyancy, linearDrag, angularDrag, &fluidVelocity, &gravity, deltaTime);
        }

        public static void JPH_BodyInterface_SetLinearAndAngularVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 linearVelocity, float3 angularVelocity)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetLinearAndAngularVelocity(@interface, bodyID, &linearVelocity, &angularVelocity);
        }

        public static void JPH_BodyInterface_GetLinearAndAngularVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, out float3 linearVelocity, out float3 angularVelocity)
        {
            AssertInitialized();

            linearVelocity = default;
            angularVelocity = default;

            fixed (float3* linearVelocityPtr = &linearVelocity)
            fixed (float3* angularVelocityPtr = &angularVelocity)
            {
                UnsafeBindings.JPH_BodyInterface_GetLinearAndAngularVelocity(@interface, bodyID, linearVelocityPtr, angularVelocityPtr);
            }
        }

        public static void JPH_BodyInterface_AddLinearVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 linearVelocity)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_AddLinearVelocity(@interface, bodyID, &linearVelocity);
        }

        public static void JPH_BodyInterface_AddLinearAndAngularVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 linearVelocity, float3 angularVelocity)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_AddLinearAndAngularVelocity(@interface, bodyID, &linearVelocity, &angularVelocity);
        }

        public static void JPH_BodyInterface_SetAngularVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 angularVelocity)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetAngularVelocity(@interface, bodyID, &angularVelocity);
        }

        public static float3 JPH_BodyInterface_GetAngularVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_BodyInterface_GetAngularVelocity(@interface, bodyID, &result);
            return result;
        }

        public static float3 JPH_BodyInterface_GetPointVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, rvec3 point)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_BodyInterface_GetPointVelocity(@interface, bodyID, &point, &result);
            return result;
        }

        public static void JPH_BodyInterface_AddForce(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 force)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_AddForce(@interface, bodyID, &force);
        }

        public static void JPH_BodyInterface_AddForce(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 force, rvec3 point)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_AddForce2(@interface, bodyID, &force, &point);
        }

        public static void JPH_BodyInterface_AddTorque(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 torque)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_AddTorque(@interface, bodyID, &torque);
        }

        public static void JPH_BodyInterface_AddForceAndTorque(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 force, float3 torque)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_AddForceAndTorque(@interface, bodyID, &force, &torque);
        }

        public static void JPH_BodyInterface_AddImpulse(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 impulse)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_AddImpulse(@interface, bodyID, &impulse);
        }

        public static void JPH_BodyInterface_AddImpulse(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 impulse, rvec3 point)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_AddImpulse2(@interface, bodyID, &impulse, &point);
        }

        public static void JPH_BodyInterface_AddAngularImpulse(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 angularImpulse)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_AddAngularImpulse(@interface, bodyID, &angularImpulse);
        }

        public static void JPH_BodyInterface_SetMotionQuality(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, MotionQuality quality)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetMotionQuality(@interface, bodyID, quality);
        }

        public static MotionQuality JPH_BodyInterface_GetMotionQuality(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_GetMotionQuality(@interface, bodyID);
        }

        public static float4x4 JPH_BodyInterface_GetInverseInertia(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            float4x4 result;
            UnsafeBindings.JPH_BodyInterface_GetInverseInertia(@interface, bodyID, &result);
            return result;
        }

        public static void JPH_BodyInterface_SetGravityFactor(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float gravityFactor)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetGravityFactor(@interface, bodyID, gravityFactor);
        }

        public static float JPH_BodyInterface_GetGravityFactor(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_GetGravityFactor(@interface, bodyID);
        }

        public static void JPH_BodyInterface_InvalidateContactCache(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_InvalidateContactCache(@interface, bodyID);
        }

        public static void JPH_BodyInterface_SetUserData(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, ulong data)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BodyInterface_SetUserData(@interface, bodyID, data);
        }

        public static ulong JPH_BodyInterface_GetUserData(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BodyInterface_GetUserData(@interface, bodyID);
        }
    }
}
