using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static float3 JPH_FixedConstraint_GetTotalLambdaPosition(NativeHandle<JPH_FixedConstraint> constraint)
        {
            float3 result;
            UnsafeBindings.JPH_FixedConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }

        public static float3 JPH_FixedConstraint_GetTotalLambdaRotation(NativeHandle<JPH_FixedConstraint> constraint)
        {
            float3 result;
            UnsafeBindings.JPH_FixedConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }
    }
}
