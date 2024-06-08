using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_FixedConstraintSettings> JPH_FixedConstraintSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_FixedConstraintSettings_Create());
        }

        public static ConstraintSpace JPH_FixedConstraintSettings_GetSpace(NativeHandle<JPH_FixedConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_FixedConstraintSettings_GetSpace(settings);
        }

        public static void JPH_FixedConstraintSettings_SetSpace(NativeHandle<JPH_FixedConstraintSettings> settings, ConstraintSpace space)
        {
            UnsafeBindings.JPH_FixedConstraintSettings_SetSpace(settings, space);
        }

        public static bool JPH_FixedConstraintSettings_GetAutoDetectPoint(NativeHandle<JPH_FixedConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_FixedConstraintSettings_GetAutoDetectPoint(settings);
        }

        public static void JPH_FixedConstraintSettings_SetAutoDetectPoint(NativeHandle<JPH_FixedConstraintSettings> settings, bool value)
        {
            UnsafeBindings.JPH_FixedConstraintSettings_SetAutoDetectPoint(settings, value);
        }

        public static rvec3 JPH_FixedConstraintSettings_GetPoint1(NativeHandle<JPH_FixedConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_FixedConstraintSettings_GetPoint1(settings, &result);
            return result;
        }

        public static void JPH_FixedConstraintSettings_SetPoint1(NativeHandle<JPH_FixedConstraintSettings> settings, rvec3 value)
        {
            UnsafeBindings.JPH_FixedConstraintSettings_SetPoint1(settings, &value);
        }

        public static float3 JPH_FixedConstraintSettings_GetAxisX1(NativeHandle<JPH_FixedConstraintSettings> settings)
        {
            float3 result;
            UnsafeBindings.JPH_FixedConstraintSettings_GetAxisX1(settings, &result);
            return result;
        }

        public static void JPH_FixedConstraintSettings_SetAxisX1(NativeHandle<JPH_FixedConstraintSettings> settings, float3 value)
        {
            UnsafeBindings.JPH_FixedConstraintSettings_SetAxisX1(settings, &value);
        }

        public static float3 JPH_FixedConstraintSettings_GetAxisY1(NativeHandle<JPH_FixedConstraintSettings> settings)
        {
            float3 result;
            UnsafeBindings.JPH_FixedConstraintSettings_GetAxisY1(settings, &result);
            return result;
        }

        public static void JPH_FixedConstraintSettings_SetAxisY1(NativeHandle<JPH_FixedConstraintSettings> settings, float3 value)
        {
            UnsafeBindings.JPH_FixedConstraintSettings_SetAxisY1(settings, &value);
        }

        public static rvec3 JPH_FixedConstraintSettings_GetPoint2(NativeHandle<JPH_FixedConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_FixedConstraintSettings_GetPoint2(settings, &result);
            return result;
        }

        public static void JPH_FixedConstraintSettings_SetPoint2(NativeHandle<JPH_FixedConstraintSettings> settings, rvec3 value)
        {
            UnsafeBindings.JPH_FixedConstraintSettings_SetPoint2(settings, &value);
        }

        public static float3 JPH_FixedConstraintSettings_GetAxisX2(NativeHandle<JPH_FixedConstraintSettings> settings)
        {
            float3 result;
            UnsafeBindings.JPH_FixedConstraintSettings_GetAxisX2(settings, &result);
            return result;
        }

        public static void JPH_FixedConstraintSettings_SetAxisX2(NativeHandle<JPH_FixedConstraintSettings> settings, float3 value)
        {
            UnsafeBindings.JPH_FixedConstraintSettings_SetAxisX2(settings, &value);
        }

        public static float3 JPH_FixedConstraintSettings_GetAxisY2(NativeHandle<JPH_FixedConstraintSettings> settings)
        {
            float3 result;
            UnsafeBindings.JPH_FixedConstraintSettings_GetAxisY2(settings, &result);
            return result;
        }

        public static void JPH_FixedConstraintSettings_SetAxisY2(NativeHandle<JPH_FixedConstraintSettings> settings, float3 value)
        {
            UnsafeBindings.JPH_FixedConstraintSettings_SetAxisY2(settings, &value);
        }

        public static NativeHandle<JPH_FixedConstraint> JPH_FixedConstraintSettings_CreateConstraint(NativeHandle<JPH_FixedConstraintSettings> settings, NativeHandle<JPH_Body> bodyA, NativeHandle<JPH_Body> bodyB)
        {
            return CreateHandle(UnsafeBindings.JPH_FixedConstraintSettings_CreateConstraint(settings, bodyA, bodyB));
        }
    }
}
