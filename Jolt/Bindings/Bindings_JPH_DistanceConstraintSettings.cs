namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_DistanceConstraintSettings> JPH_DistanceConstraintSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_DistanceConstraintSettings_Create());
        }

        public static ConstraintSpace JPH_DistanceConstraintSettings_GetSpace(NativeHandle<JPH_DistanceConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_DistanceConstraintSettings_GetSpace(settings);
        }

        public static void JPH_DistanceConstraintSettings_SetSpace(NativeHandle<JPH_DistanceConstraintSettings> settings, ConstraintSpace space)
        {
            UnsafeBindings.JPH_DistanceConstraintSettings_SetSpace(settings, space);
        }

        public static rvec3 JPH_DistanceConstraintSettings_GetPoint1(NativeHandle<JPH_DistanceConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_DistanceConstraintSettings_GetPoint1(settings, &result);
            return result;
        }

        public static void JPH_DistanceConstraintSettings_SetPoint1(NativeHandle<JPH_DistanceConstraintSettings> settings, rvec3 value)
        {
            UnsafeBindings.JPH_DistanceConstraintSettings_SetPoint1(settings, &value);
        }

        public static rvec3 JPH_DistanceConstraintSettings_GetPoint2(NativeHandle<JPH_DistanceConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_DistanceConstraintSettings_GetPoint2(settings, &result);
            return result;
        }

        public static void JPH_DistanceConstraintSettings_SetPoint2(NativeHandle<JPH_DistanceConstraintSettings> settings, rvec3 value)
        {
            UnsafeBindings.JPH_DistanceConstraintSettings_SetPoint2(settings, &value);
        }

        public static NativeHandle<JPH_DistanceConstraint> JPH_DistanceConstraintSettings_CreateConstraint(NativeHandle<JPH_DistanceConstraintSettings> settings, NativeHandle<JPH_Body> bodyA, NativeHandle<JPH_Body> bodyB)
        {
            return CreateHandle(UnsafeBindings.JPH_DistanceConstraintSettings_CreateConstraint(settings, bodyA, bodyB));
        }
    }
}
