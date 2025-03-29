using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_PointConstraint> JPH_PointConstraint_Create(ref PointConstraintSettings settings, NativeHandle<JPH_Body> body1, NativeHandle<JPH_Body> body2)
        {
            AssertInitialized();

            fixed (PointConstraintSettings* ptr = &settings)
            {
                return CreateHandle(UnsafeBindings.JPH_PointConstraint_Create((JPH_PointConstraintSettings*) ptr, body1, body2));
            }
        }

        public static void JPH_PointConstraint_SetPoint1(NativeHandle<JPH_PointConstraint> constraint, ConstraintSpace space, rvec3 value)
        {
            AssertInitialized();

            UnsafeBindings.JPH_PointConstraint_SetPoint1(constraint, space, &value);
        }

        public static void JPH_PointConstraint_SetPoint2(NativeHandle<JPH_PointConstraint> constraint, ConstraintSpace space, rvec3 value)
        {
            AssertInitialized();

            UnsafeBindings.JPH_PointConstraint_SetPoint2(constraint, space, &value);
        }

        public static float3 JPH_PointConstraint_GetLocalSpacePoint1(NativeHandle<JPH_PointConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_PointConstraint_GetLocalSpacePoint1(constraint, &result);
            return result;
        }

        public static float3 JPH_PointConstraint_GetLocalSpacePoint2(NativeHandle<JPH_PointConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_PointConstraint_GetLocalSpacePoint2(constraint, &result);
            return result;
        }

        public static float3 JPH_PointConstraint_GetTotalLambdaPosition(NativeHandle<JPH_PointConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_PointConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }
    }
}
