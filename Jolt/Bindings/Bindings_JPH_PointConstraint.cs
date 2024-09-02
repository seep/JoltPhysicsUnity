using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_PointConstraint_SetPoint1(NativeHandle<JPH_PointConstraint> constraint, ConstraintSpace space, rvec3 value)
        {
            UnsafeBindings.JPH_PointConstraint_SetPoint1(constraint, space, &value);
        }

        public static void JPH_PointConstraint_SetPoint2(NativeHandle<JPH_PointConstraint> constraint, ConstraintSpace space, rvec3 value)
        {
            UnsafeBindings.JPH_PointConstraint_SetPoint2(constraint, space, &value);
        }

        public static float3 JPH_PointConstraint_GetTotalLambdaPosition(NativeHandle<JPH_PointConstraint> constraint)
        {
            float3 result;
            UnsafeBindings.JPH_PointConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }
    }
}