using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static BodyID JPH_Body_GetID(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetID(GetPointer(body));
        }

        public static BodyType JPH_Body_GetBodyType(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetBodyType(GetPointer(body));
        }

        public static AABox JPH_Body_GetWorldSpaceBounds(NativeHandle<JPH_Body> body)
        {
            AABox result;

            Bindings.JPH_Body_GetWorldSpaceBounds(GetPointer(body), &result);

            return result;
        }

        public static float3 JPH_Body_GetWorldSpaceSurfaceNormal(NativeHandle<JPH_Body> body, uint subShapeID, rvec3 position)
        {
            float3 result;

            Bindings.JPH_Body_GetWorldSpaceSurfaceNormal(GetPointer(body), subShapeID, &position, &result);

            return result;
        }

        public static bool JPH_Body_IsActive(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_IsActive(GetPointer(body));
        }

        public static bool JPH_Body_IsStatic(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_IsStatic(GetPointer(body));
        }

        public static bool JPH_Body_IsKinematic(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_IsKinematic(GetPointer(body));
        }

        public static bool JPH_Body_IsDynamic(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_IsDynamic(GetPointer(body));
        }

        public static bool JPH_Body_IsSensor(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_IsSensor(GetPointer(body));
        }

        public static void JPH_Body_SetIsSensor(NativeHandle<JPH_Body> body, bool value)
        {
            Bindings.JPH_Body_SetIsSensor(GetPointer(body), value);
        }

        public static void JPH_Body_SetCollideKinematicVsNonDynamic(NativeHandle<JPH_Body> body, bool value)
        {
            Bindings.JPH_Body_SetCollideKinematicVsNonDynamic(GetPointer(body), value);
        }

        public static bool JPH_Body_GetCollideKinematicVsNonDynamic(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetCollideKinematicVsNonDynamic(GetPointer(body));
        }

        public static void JPH_Body_SetUseManifoldReduction(NativeHandle<JPH_Body> body, bool value)
        {
            Bindings.JPH_Body_SetUseManifoldReduction(GetPointer(body), value);
        }

        public static bool JPH_Body_GetUseManifoldReduction(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetUseManifoldReduction(GetPointer(body));
        }

        public static bool JPH_Body_GetUseManifoldReductionWithBody(NativeHandle<JPH_Body> body, NativeHandle<JPH_Body> other)
        {
            return Bindings.JPH_Body_GetUseManifoldReductionWithBody(GetPointer(body), GetPointer(body));
        }

        public static void JPH_Body_SetApplyGyroscopicForce(NativeHandle<JPH_Body> body, bool value)
        {
            Bindings.JPH_Body_SetApplyGyroscopicForce(GetPointer(body), value);
        }

        public static bool JPH_Body_GetApplyGyroscopicForce(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetApplyGyroscopicForce(GetPointer(body));
        }

        public static NativeHandle<JPH_MotionProperties> JPH_Body_GetMotionProperties(NativeHandle<JPH_Body> body)
        {
            return CreateOwnedHandle(body, Bindings.JPH_Body_GetMotionProperties(GetPointer(body)));
        }

        public static MotionType JPH_Body_GetMotionType(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetMotionType(GetPointer(body));
        }

        public static void JPH_Body_SetMotionType(NativeHandle<JPH_Body> body, MotionType motion)
        {
            Bindings.JPH_Body_SetMotionType(GetPointer(body), motion);
        }

        public static bool JPH_Body_GetAllowSleeping(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetAllowSleeping(GetPointer(body));
        }

        public static void JPH_Body_SetAllowSleeping(NativeHandle<JPH_Body> body, bool allowSleeping)
        {
            Bindings.JPH_Body_SetAllowSleeping(GetPointer(body), allowSleeping);
        }

        public static void JPH_Body_ResetSleepTimer(NativeHandle<JPH_Body> body)
        {
            Bindings.JPH_Body_ResetSleepTimer(GetPointer(body));
        }

        public static float JPH_Body_GetFriction(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetFriction(GetPointer(body));
        }

        public static void JPH_Body_SetFriction(NativeHandle<JPH_Body> body, float friction)
        {
            Bindings.JPH_Body_SetFriction(GetPointer(body), friction);
        }

        public static float JPH_Body_GetRestitution(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetRestitution(GetPointer(body));
        }

        public static void JPH_Body_SetRestitution(NativeHandle<JPH_Body> body, float restitution)
        {
            Bindings.JPH_Body_SetRestitution(GetPointer(body), restitution);
        }

        public static float3 JPH_Body_GetLinearVelocity(NativeHandle<JPH_Body> body)
        {
            float3 result;

            Bindings.JPH_Body_GetLinearVelocity(GetPointer(body), &result);

            return result;
        }

        public static void JPH_Body_SetLinearVelocity(NativeHandle<JPH_Body> body, float3 velocity)
        {
            Bindings.JPH_Body_SetLinearVelocity(GetPointer(body), &velocity);
        }

        public static float3 JPH_Body_GetAngularVelocity(NativeHandle<JPH_Body> body)
        {
            float3 result;

            Bindings.JPH_Body_GetAngularVelocity(GetPointer(body), &result);

            return result;
        }

        public static void JPH_Body_SetAngularVelocity(NativeHandle<JPH_Body> body, float3 velocity)
        {
            Bindings.JPH_Body_SetAngularVelocity(GetPointer(body), &velocity);
        }

        public static void JPH_Body_AddForce(NativeHandle<JPH_Body> body, float3 force)
        {
            Bindings.JPH_Body_AddForce(GetPointer(body), &force);
        }

        public static void JPH_Body_AddForceAtPosition(NativeHandle<JPH_Body> body, float3 force, rvec3 position)
        {
            Bindings.JPH_Body_AddForceAtPosition(GetPointer(body), &force, &position);
        }

        public static void JPH_Body_AddTorque(NativeHandle<JPH_Body> body, float3 force)
        {
            Bindings.JPH_Body_AddTorque(GetPointer(body), &force);
        }

        public static float3 JPH_Body_GetAccumulatedForce(NativeHandle<JPH_Body> body)
        {
            float3 result;

            Bindings.JPH_Body_GetAccumulatedForce(GetPointer(body), &result);

            return result;
        }

        public static float3 JPH_Body_GetAccumulatedTorque(NativeHandle<JPH_Body> body)
        {
            float3 result;

            Bindings.JPH_Body_GetAccumulatedTorque(GetPointer(body), &result);

            return result;
        }

        public static void JPH_Body_AddImpulse(NativeHandle<JPH_Body> body, float3 impulse)
        {
            Bindings.JPH_Body_AddImpulse(GetPointer(body), &impulse);
        }

        public static void JPH_Body_AddImpulseAtPosition(NativeHandle<JPH_Body> body, float3 impulse, rvec3 position)
        {
            Bindings.JPH_Body_AddImpulseAtPosition(GetPointer(body), &impulse, &position);
        }

        public static void JPH_Body_AddAngularImpulse(NativeHandle<JPH_Body> body, float3 angularImpulse)
        {
            Bindings.JPH_Body_AddAngularImpulse(GetPointer(body), &angularImpulse);
        }

        public static rvec3 JPH_Body_GetPosition(NativeHandle<JPH_Body> body)
        {
            rvec3 result;

            Bindings.JPH_Body_GetPosition(GetPointer(body), &result);

            return result;
        }

        public static quaternion JPH_Body_GetRotation(NativeHandle<JPH_Body> body)
        {
            quaternion result;

            Bindings.JPH_Body_GetRotation(GetPointer(body), &result);

            return result;
        }

        public static rvec3 JPH_Body_GetCenterOfMassPosition(NativeHandle<JPH_Body> body)
        {
            rvec3 result;

            Bindings.JPH_Body_GetCenterOfMassPosition(GetPointer(body), &result);

            return result;
        }

        public static rmatrix4x4 JPH_Body_GetWorldTransform(NativeHandle<JPH_Body> body)
        {
            rmatrix4x4 result;

            Bindings.JPH_Body_GetWorldTransform(GetPointer(body), &result);

            return result;
        }

        public static rmatrix4x4 JPH_Body_GetCenterOfMassTransform(NativeHandle<JPH_Body> body)
        {
            rmatrix4x4 result;

            Bindings.JPH_Body_GetCenterOfMassTransform(GetPointer(body), &result);

            return result;
        }

        public static void JPH_Body_SetUserData(NativeHandle<JPH_Body> body, ulong userData)
        {
            Bindings.JPH_Body_SetUserData(GetPointer(body), userData);
        }

        public static ulong JPH_Body_GetUserData(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetUserData(GetPointer(body));
        }
    }
}
