namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_PointConstraintSettings> JPH_PointConstraintSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_PointConstraintSettings_Create());
        }

        public static ConstraintSpace JPH_PointConstraintSettings_GetSpace(NativeHandle<JPH_PointConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_PointConstraintSettings_GetSpace(settings);
        }

        public static void JPH_PointConstraintSettings_SetSpace(NativeHandle<JPH_PointConstraintSettings> settings, ConstraintSpace space)
        {
            UnsafeBindings.JPH_PointConstraintSettings_SetSpace(settings, space);
        }

        public static rvec3 JPH_PointConstraintSettings_GetPoint1(NativeHandle<JPH_PointConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_PointConstraintSettings_GetPoint1(settings, &result);
            return result;
        }

        public static void JPH_PointConstraintSettings_SetPoint1(NativeHandle<JPH_PointConstraintSettings> settings, rvec3 value)
        {
            UnsafeBindings.JPH_PointConstraintSettings_SetPoint1(settings, &value);
        }

        public static rvec3 JPH_PointConstraintSettings_GetPoint2(NativeHandle<JPH_PointConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_PointConstraintSettings_GetPoint2(settings, &result);
            return result;
        }

        public static void JPH_PointConstraintSettings_SetPoint2(NativeHandle<JPH_PointConstraintSettings> settings, rvec3 value)
        {
            UnsafeBindings.JPH_PointConstraintSettings_SetPoint2(settings, &value);
        }

        public static NativeHandle<JPH_PointConstraint> JPH_PointConstraintSettings_CreateConstraint(NativeHandle<JPH_PointConstraintSettings> settings, NativeHandle<JPH_Body> bodyA, NativeHandle<JPH_Body> bodyB)
        {
            return CreateHandle(UnsafeBindings.JPH_PointConstraintSettings_CreateConstraint(settings, bodyA, bodyB));
        }
    }
}