using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static BodyID JPH_Body_GetID(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_GetID(body);
        }

        public static BodyType JPH_Body_GetBodyType(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_GetBodyType(body);
        }

        public static AABox JPH_Body_GetWorldSpaceBounds(NativeHandle<JPH_Body> body)
        {
            AABox result;
            UnsafeBindings.JPH_Body_GetWorldSpaceBounds(body, &result);
            return result;
        }

        public static float3 JPH_Body_GetWorldSpaceSurfaceNormal(NativeHandle<JPH_Body> body, SubShapeID subShapeID, rvec3 position)
        {
            float3 result;
            UnsafeBindings.JPH_Body_GetWorldSpaceSurfaceNormal(body, subShapeID, &position, &result);
            return result;
        }

        public static bool JPH_Body_IsActive(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_IsActive(body);
        }

        public static bool JPH_Body_IsStatic(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_IsStatic(body);
        }

        public static bool JPH_Body_IsKinematic(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_IsKinematic(body);
        }

        public static bool JPH_Body_IsDynamic(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_IsDynamic(body);
        }

        public static bool JPH_Body_IsSensor(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_IsSensor(body);
        }

        public static void JPH_Body_SetIsSensor(NativeHandle<JPH_Body> body, bool value)
        {
            UnsafeBindings.JPH_Body_SetIsSensor(body, value);
        }

        public static void JPH_Body_SetCollideKinematicVsNonDynamic(NativeHandle<JPH_Body> body, bool value)
        {
            UnsafeBindings.JPH_Body_SetCollideKinematicVsNonDynamic(body, value);
        }

        public static bool JPH_Body_GetCollideKinematicVsNonDynamic(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_GetCollideKinematicVsNonDynamic(body);
        }

        public static void JPH_Body_SetUseManifoldReduction(NativeHandle<JPH_Body> body, bool value)
        {
            UnsafeBindings.JPH_Body_SetUseManifoldReduction(body, value);
        }

        public static bool JPH_Body_GetUseManifoldReduction(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_GetUseManifoldReduction(body);
        }

        public static bool JPH_Body_GetUseManifoldReductionWithBody(NativeHandle<JPH_Body> body, NativeHandle<JPH_Body> other)
        {
            return UnsafeBindings.JPH_Body_GetUseManifoldReductionWithBody(body, other);
        }

        public static void JPH_Body_SetApplyGyroscopicForce(NativeHandle<JPH_Body> body, bool value)
        {
            UnsafeBindings.JPH_Body_SetApplyGyroscopicForce(body, value);
        }

        public static bool JPH_Body_GetApplyGyroscopicForce(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_GetApplyGyroscopicForce(body);
        }

        public static NativeHandle<JPH_MotionProperties> JPH_Body_GetMotionProperties(NativeHandle<JPH_Body> body)
        {
            return CreateOwnedHandle(body, UnsafeBindings.JPH_Body_GetMotionProperties(body));
        }

        public static MotionType JPH_Body_GetMotionType(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_GetMotionType(body);
        }

        public static void JPH_Body_SetMotionType(NativeHandle<JPH_Body> body, MotionType motion)
        {
            UnsafeBindings.JPH_Body_SetMotionType(body, motion);
        }

        public static bool JPH_Body_GetAllowSleeping(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_GetAllowSleeping(body);
        }

        public static void JPH_Body_SetAllowSleeping(NativeHandle<JPH_Body> body, bool allowSleeping)
        {
            UnsafeBindings.JPH_Body_SetAllowSleeping(body, allowSleeping);
        }

        public static void JPH_Body_ResetSleepTimer(NativeHandle<JPH_Body> body)
        {
            UnsafeBindings.JPH_Body_ResetSleepTimer(body);
        }

        public static float JPH_Body_GetFriction(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_GetFriction(body);
        }

        public static void JPH_Body_SetFriction(NativeHandle<JPH_Body> body, float friction)
        {
            UnsafeBindings.JPH_Body_SetFriction(body, friction);
        }

        public static float JPH_Body_GetRestitution(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_GetRestitution(body);
        }

        public static void JPH_Body_SetRestitution(NativeHandle<JPH_Body> body, float restitution)
        {
            UnsafeBindings.JPH_Body_SetRestitution(body, restitution);
        }

        public static float3 JPH_Body_GetLinearVelocity(NativeHandle<JPH_Body> body)
        {
            float3 result;
            UnsafeBindings.JPH_Body_GetLinearVelocity(body, &result);
            return result;
        }

        public static void JPH_Body_SetLinearVelocity(NativeHandle<JPH_Body> body, float3 velocity)
        {
            UnsafeBindings.JPH_Body_SetLinearVelocity(body, &velocity);
        }

        public static float3 JPH_Body_GetAngularVelocity(NativeHandle<JPH_Body> body)
        {
            float3 result;
            UnsafeBindings.JPH_Body_GetAngularVelocity(body, &result);
            return result;
        }

        public static void JPH_Body_SetAngularVelocity(NativeHandle<JPH_Body> body, float3 velocity)
        {
            UnsafeBindings.JPH_Body_SetAngularVelocity(body, &velocity);
        }

        public static void JPH_Body_AddForce(NativeHandle<JPH_Body> body, float3 force)
        {
            UnsafeBindings.JPH_Body_AddForce(body, &force);
        }

        public static void JPH_Body_AddForceAtPosition(NativeHandle<JPH_Body> body, float3 force, rvec3 position)
        {
            UnsafeBindings.JPH_Body_AddForceAtPosition(body, &force, &position);
        }

        public static void JPH_Body_AddTorque(NativeHandle<JPH_Body> body, float3 force)
        {
            UnsafeBindings.JPH_Body_AddTorque(body, &force);
        }

        public static float3 JPH_Body_GetAccumulatedForce(NativeHandle<JPH_Body> body)
        {
            float3 result;
            UnsafeBindings.JPH_Body_GetAccumulatedForce(body, &result);
            return result;
        }

        public static float3 JPH_Body_GetAccumulatedTorque(NativeHandle<JPH_Body> body)
        {
            float3 result;
            UnsafeBindings.JPH_Body_GetAccumulatedTorque(body, &result);
            return result;
        }

        public static void JPH_Body_AddImpulse(NativeHandle<JPH_Body> body, float3 impulse)
        {
            UnsafeBindings.JPH_Body_AddImpulse(body, &impulse);
        }

        public static void JPH_Body_AddImpulseAtPosition(NativeHandle<JPH_Body> body, float3 impulse, rvec3 position)
        {
            UnsafeBindings.JPH_Body_AddImpulseAtPosition(body, &impulse, &position);
        }

        public static void JPH_Body_AddAngularImpulse(NativeHandle<JPH_Body> body, float3 angularImpulse)
        {
            UnsafeBindings.JPH_Body_AddAngularImpulse(body, &angularImpulse);
        }

        public static rvec3 JPH_Body_GetPosition(NativeHandle<JPH_Body> body)
        {
            rvec3 result;
            UnsafeBindings.JPH_Body_GetPosition(body, &result);
            return result;
        }

        public static quaternion JPH_Body_GetRotation(NativeHandle<JPH_Body> body)
        {
            quaternion result;
            UnsafeBindings.JPH_Body_GetRotation(body, &result);
            return result;
        }

        public static rvec3 JPH_Body_GetCenterOfMassPosition(NativeHandle<JPH_Body> body)
        {
            rvec3 result;
            UnsafeBindings.JPH_Body_GetCenterOfMassPosition(body, &result);
            return result;
        }

        public static rmatrix4x4 JPH_Body_GetWorldTransform(NativeHandle<JPH_Body> body)
        {
            rmatrix4x4 result;
            UnsafeBindings.JPH_Body_GetWorldTransform(body, &result);
            return result;
        }

        public static rmatrix4x4 JPH_Body_GetCenterOfMassTransform(NativeHandle<JPH_Body> body)
        {
            rmatrix4x4 result;
            UnsafeBindings.JPH_Body_GetCenterOfMassTransform(body, &result);
            return result;
        }

        public static void JPH_Body_SetUserData(NativeHandle<JPH_Body> body, ulong userData)
        {
            UnsafeBindings.JPH_Body_SetUserData(body, userData);
        }

        public static ulong JPH_Body_GetUserData(NativeHandle<JPH_Body> body)
        {
            return UnsafeBindings.JPH_Body_GetUserData(body);
        }

        public static NativeHandle<JPH_Body> JPH_Body_GetFixedToWorldBody()
        {
            return CreateHandle(UnsafeBindings.JPH_Body_GetFixedToWorldBody()); // TODO use single static safety handle?
        }
    }
}
