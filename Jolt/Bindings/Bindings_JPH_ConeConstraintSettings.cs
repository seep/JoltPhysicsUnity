using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_ConeConstraintSettings> JPH_ConeConstraintSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_ConeConstraintSettings_Create());
        }

        public static rvec3 JPH_ConeConstraintSettings_GetPoint1(NativeHandle<JPH_ConeConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_ConeConstraintSettings_GetPoint1(settings, &result);
            return result;
        }

        public static void JPH_ConeConstraintSettings_SetPoint1(NativeHandle<JPH_ConeConstraintSettings> settings, rvec3 value)
        {
            UnsafeBindings.JPH_ConeConstraintSettings_SetPoint1(settings, &value);
        }

        public static rvec3 JPH_ConeConstraintSettings_GetPoint2(NativeHandle<JPH_ConeConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_ConeConstraintSettings_GetPoint2(settings, &result);
            return result;
        }

        public static void JPH_ConeConstraintSettings_SetPoint2(NativeHandle<JPH_ConeConstraintSettings> settings, rvec3 value)
        {
            UnsafeBindings.JPH_ConeConstraintSettings_SetPoint1(settings, &value);
        }

        public static void JPH_ConeConstraintSettings_SetTwistAxis1(NativeHandle<JPH_ConeConstraintSettings> settings, float3 value)
        {
            UnsafeBindings.JPH_ConeConstraintSettings_SetTwistAxis1(settings, &value);
        }

        public static float3 JPH_ConeConstraintSettings_GetTwistAxis1(NativeHandle<JPH_ConeConstraintSettings> settings)
        {
            float3 result;
            UnsafeBindings.JPH_ConeConstraintSettings_GetTwistAxis1(settings, &result);
            return result;
        }

        public static void JPH_ConeConstraintSettings_SetTwistAxis2(NativeHandle<JPH_ConeConstraintSettings> settings, float3 value)
        {
            UnsafeBindings.JPH_ConeConstraintSettings_SetTwistAxis2(settings, &value);
        }

        public static float3 JPH_ConeConstraintSettings_GetTwistAxis2(NativeHandle<JPH_ConeConstraintSettings> settings)
        {
            float3 result;
            UnsafeBindings.JPH_ConeConstraintSettings_GetTwistAxis2(settings, &result);
            return result;
        }

        public static void JPH_ConeConstraintSettings_SetHalfConeAngle(NativeHandle<JPH_ConeConstraintSettings> settings, float halfConeAngle)
        {
            UnsafeBindings.JPH_ConeConstraintSettings_SetHalfConeAngle(settings, halfConeAngle);
        }

        public static float JPH_ConeConstraintSettings_GetHalfConeAngle(NativeHandle<JPH_ConeConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_ConeConstraintSettings_GetHalfConeAngle(settings);
        }

        public static NativeHandle<JPH_ConeConstraint> JPH_ConeConstraintSettings_CreateConstraint(NativeHandle<JPH_ConeConstraintSettings> settings, NativeHandle<JPH_Body> bodyA, NativeHandle<JPH_Body> bodyB)
        {
            return CreateHandle(UnsafeBindings.JPH_ConeConstraintSettings_CreateConstraint(settings, bodyA, bodyB));
        }
    }
}