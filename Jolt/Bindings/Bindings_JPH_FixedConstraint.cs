using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_FixedConstraint> JPH_FixedConstraint_Create(ref FixedConstraintSettings settings, NativeHandle<JPH_Body> body1, NativeHandle<JPH_Body> body2)
        {
            AssertInitialized();

            fixed (FixedConstraintSettings* ptr = &settings)
            {
                return CreateHandle(UnsafeBindings.JPH_FixedConstraint_Create((JPH_FixedConstraintSettings*)ptr, body1, body2));
            }
        }

        public static void JPH_FixedConstraint_GetSettings(NativeHandle<JPH_FixedConstraint> constraint, ref FixedConstraintSettings settings)
        {
            AssertInitialized();

            fixed (FixedConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_FixedConstraint_GetSettings(constraint, (JPH_FixedConstraintSettings*)ptr);
            }
        }

        public static float3 JPH_FixedConstraint_GetTotalLambdaPosition(NativeHandle<JPH_FixedConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_FixedConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }

        public static float3 JPH_FixedConstraint_GetTotalLambdaRotation(NativeHandle<JPH_FixedConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_FixedConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }
    }
}
