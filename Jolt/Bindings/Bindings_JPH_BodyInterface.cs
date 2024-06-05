using System;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_BodyInterface_DestroyBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            UnsafeBindings.JPH_BodyInterface_DestroyBody(@interface, bodyID);

            // TODO mark any active body handles for this bodyID as disposed
        }

        public static BodyID JPH_BodyInterface_CreateAndAddBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings, Activation activation)
        {
            return UnsafeBindings.JPH_BodyInterface_CreateAndAddBody(@interface, settings, activation);
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return CreateHandle(UnsafeBindings.JPH_BodyInterface_CreateBody(@interface, settings));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateSoftBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_SoftBodyCreationSettings> settings)
        {
            return CreateHandle(UnsafeBindings.JPH_BodyInterface_CreateSoftBody(@interface, settings));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBodyWithID(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return CreateHandle(UnsafeBindings.JPH_BodyInterface_CreateBodyWithID(@interface, bodyID, settings));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBodyWithoutID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return CreateHandle(UnsafeBindings.JPH_BodyInterface_CreateBodyWithoutID(@interface, settings));
        }

        public static void JPH_BodyInterface_DestroyBodyWithoutID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body)
        {
            UnsafeBindings.JPH_BodyInterface_DestroyBodyWithoutID(@interface, body);
        }

        public static bool JPH_BodyInterface_AssignBodyID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_BodyInterface_AssignBodyID(@interface, body);
        }

        public static bool JPH_BodyInterface_AssignBodyID2(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body, BodyID bodyID)
        {
            return UnsafeBindings.JPH_BodyInterface_AssignBodyID2(@interface, body, bodyID);
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_UnassignBodyID(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            // TODO is CreateHandle correct? Does that create a duplicate pointer to the body?

            // return CreateHandle(UnsafeBindings.JPH_BodyInterface_UnassignBodyID(GetPointer(@interface), bodyID));

            throw new NotImplementedException();
        }

        public static void JPH_BodyInterface_AddBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, Activation activation)
        {
            UnsafeBindings.JPH_BodyInterface_AddBody(@interface, bodyID, activation);
        }

        public static void JPH_BodyInterface_RemoveBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            UnsafeBindings.JPH_BodyInterface_RemoveBody(@interface, bodyID);
        }

        public static bool JPH_BodyInterface_IsActive(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return UnsafeBindings.JPH_BodyInterface_IsActive(@interface, bodyID);
        }

        public static bool JPH_BodyInterface_IsAdded(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return UnsafeBindings.JPH_BodyInterface_IsAdded(@interface, bodyID);
        }

        public static bool JPH_BodyInterface_GetBodyType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return UnsafeBindings.JPH_BodyInterface_IsAdded(@interface, bodyID);
        }

        public static void JPH_BodyInterface_SetLinearVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 velocity)
        {
            UnsafeBindings.JPH_BodyInterface_SetLinearVelocity(@interface, bodyID, &velocity);
        }

        public static float3 JPH_BodyInterface_GetLinearVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            float3 result;

            UnsafeBindings.JPH_BodyInterface_GetLinearVelocity(@interface, bodyID, &result);

            return result;
        }

        public static rvec3 JPH_BodyInterface_GetCenterOfMassPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            rvec3 result;

            UnsafeBindings.JPH_BodyInterface_GetCenterOfMassPosition(@interface, bodyID, &result);

            return result;
        }

        public static MotionType JPH_BodyInterface_GetMotionType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return UnsafeBindings.JPH_BodyInterface_GetMotionType(@interface, bodyID);
        }

        public static void JPH_BodyInterface_SetMotionType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, MotionType motion, Activation activation)
        {
            UnsafeBindings.JPH_BodyInterface_SetMotionType(@interface, bodyID, motion, activation);
        }

        public static float JPH_BodyInterface_GetRestitution(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return UnsafeBindings.JPH_BodyInterface_GetRestitution(@interface, bodyID);
        }

        public static void JPH_BodyInterface_SetRestitution(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float restitution)
        {
            UnsafeBindings.JPH_BodyInterface_SetRestitution(@interface, bodyID, restitution);
        }

        public static float JPH_BodyInterface_GetFriction(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return UnsafeBindings.JPH_BodyInterface_GetFriction(@interface, bodyID);
        }

        public static void JPH_BodyInterface_SetFriction(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float friction)
        {
            UnsafeBindings.JPH_BodyInterface_SetFriction(@interface, bodyID, friction);
        }

        public static void JPH_BodyInterface_SetPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, rvec3 position, Activation activation)
        {
            UnsafeBindings.JPH_BodyInterface_SetPosition(@interface, bodyID, &position, activation);
        }

        public static rvec3 JPH_BodyInterface_GetPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            rvec3 result;

            UnsafeBindings.JPH_BodyInterface_GetPosition(@interface, bodyID, &result);

            return result;
        }

        public static void JPH_BodyInterface_SetRotation(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, quaternion rotation, Activation activation)
        {
            UnsafeBindings.JPH_BodyInterface_SetRotation(@interface, bodyID, &rotation, activation);
        }

        public static quaternion JPH_BodyInterface_GetRotation(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            quaternion result;

            UnsafeBindings.JPH_BodyInterface_GetRotation(@interface, bodyID, &result);

            return result;
        }

        public static rmatrix4x4 JPH_BodyInterface_GetWorldTransform(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            rmatrix4x4 result;

            UnsafeBindings.JPH_BodyInterface_GetWorldTransform(@interface, bodyID, &result);

            return result;
        }
    }
}
