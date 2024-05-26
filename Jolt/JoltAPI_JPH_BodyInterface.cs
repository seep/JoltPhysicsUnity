using System;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static void JPH_BodyInterface_DestroyBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            Bindings.JPH_BodyInterface_DestroyBody(GetPointer(@interface), bodyID);

            // TODO mark any active body handles for this bodyID as disposed
        }

        public static BodyID JPH_BodyInterface_CreateAndAddBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings, Activation activation)
        {
            return Bindings.JPH_BodyInterface_CreateAndAddBody(GetPointer(@interface), GetPointer(settings), activation);
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return CreateHandle(Bindings.JPH_BodyInterface_CreateBody(GetPointer(@interface), GetPointer(settings)));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateSoftBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_SoftBodyCreationSettings> settings)
        {
            return CreateHandle(Bindings.JPH_BodyInterface_CreateSoftBody(GetPointer(@interface), GetPointer(settings)));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBodyWithID(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return CreateHandle(Bindings.JPH_BodyInterface_CreateBodyWithID(GetPointer(@interface), bodyID, GetPointer(settings)));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBodyWithoutID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return CreateHandle(Bindings.JPH_BodyInterface_CreateBodyWithoutID(GetPointer(@interface), GetPointer(settings)));
        }

        public static void JPH_BodyInterface_DestroyBodyWithoutID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body)
        {
            Bindings.JPH_BodyInterface_DestroyBodyWithoutID(GetPointer(@interface), GetPointer(body));
        }

        public static bool JPH_BodyInterface_AssignBodyID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_BodyInterface_AssignBodyID(GetPointer(@interface), GetPointer(body));
        }

        public static bool JPH_BodyInterface_AssignBodyID2(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_AssignBodyID2(GetPointer(@interface), GetPointer(body), bodyID);
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_UnassignBodyID(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            // TODO is CreateHandle correct? Does that create a duplicate pointer to the body?

            // return CreateHandle(Bindings.JPH_BodyInterface_UnassignBodyID(GetPointer(@interface), bodyID));

            throw new NotImplementedException();
        }

        public static void JPH_BodyInterface_AddBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, Activation activation)
        {
            Bindings.JPH_BodyInterface_AddBody(GetPointer(@interface), bodyID, activation);
        }

        public static void JPH_BodyInterface_RemoveBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            Bindings.JPH_BodyInterface_RemoveBody(GetPointer(@interface), bodyID);
        }

        public static bool JPH_BodyInterface_IsActive(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_IsActive(GetPointer(@interface), bodyID);
        }

        public static bool JPH_BodyInterface_IsAdded(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_IsAdded(GetPointer(@interface), bodyID);
        }

        public static bool JPH_BodyInterface_GetBodyType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_IsAdded(GetPointer(@interface), bodyID);
        }

        public static void JPH_BodyInterface_SetLinearVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 velocity)
        {
            Bindings.JPH_BodyInterface_SetLinearVelocity(GetPointer(@interface), bodyID, &velocity);
        }

        public static float3 JPH_BodyInterface_GetLinearVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            float3 result;

            Bindings.JPH_BodyInterface_GetLinearVelocity(GetPointer(@interface), bodyID, &result);

            return result;
        }

        public static rvec3 JPH_BodyInterface_GetCenterOfMassPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            rvec3 result;

            Bindings.JPH_BodyInterface_GetCenterOfMassPosition(GetPointer(@interface), bodyID, &result);

            return result;
        }

        public static MotionType JPH_BodyInterface_GetMotionType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_GetMotionType(GetPointer(@interface), bodyID);
        }

        public static void JPH_BodyInterface_SetMotionType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, MotionType motion, Activation activation)
        {
            Bindings.JPH_BodyInterface_SetMotionType(GetPointer(@interface), bodyID, motion, activation);
        }

        public static float JPH_BodyInterface_GetRestitution(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_GetRestitution(GetPointer(@interface), bodyID);
        }

        public static void JPH_BodyInterface_SetRestitution(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float restitution)
        {
            Bindings.JPH_BodyInterface_SetRestitution(GetPointer(@interface), bodyID, restitution);
        }

        public static float JPH_BodyInterface_GetFriction(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_GetFriction(GetPointer(@interface), bodyID);
        }

        public static void JPH_BodyInterface_SetFriction(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float friction)
        {
            Bindings.JPH_BodyInterface_SetFriction(GetPointer(@interface), bodyID, friction);
        }

        public static void JPH_BodyInterface_SetPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, rvec3 position, Activation activation)
        {
            Bindings.JPH_BodyInterface_SetPosition(GetPointer(@interface), bodyID, &position, activation);
        }

        public static rvec3 JPH_BodyInterface_GetPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            rvec3 result;

            Bindings.JPH_BodyInterface_GetPosition(GetPointer(@interface), bodyID, &result);

            return result;
        }

        public static void JPH_BodyInterface_SetRotation(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, quaternion rotation, Activation activation)
        {
            Bindings.JPH_BodyInterface_SetRotation(GetPointer(@interface), bodyID, &rotation, activation);
        }

        public static quaternion JPH_BodyInterface_GetRotation(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            quaternion result;

            Bindings.JPH_BodyInterface_GetRotation(GetPointer(@interface), bodyID, &result);

            return result;
        }

        public static rmatrix4x4 JPH_BodyInterface_GetWorldTransform(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            rmatrix4x4 result;

            Bindings.JPH_BodyInterface_GetWorldTransform(GetPointer(@interface), bodyID, &result);

            return result;
        }
    }
}
