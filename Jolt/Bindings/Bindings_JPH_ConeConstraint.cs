using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_ConeConstraint_SetHalfConeAngle(NativeHandle<JPH_ConeConstraint> constraint, float halfConeAngle)
        {
            UnsafeBindings.JPH_ConeConstraint_SetHalfConeAngle(constraint, halfConeAngle);
        }

        public static float JPH_ConeConstraint_GetCosHalfConeAngle(NativeHandle<JPH_ConeConstraint> constraint)
        {
            return UnsafeBindings.JPH_ConeConstraint_GetCosHalfConeAngle(constraint);
        }

        public static float3 JPH_ConeConstraint_GetTotalLambdaPosition(NativeHandle<JPH_ConeConstraint> constraint)
        {
            float3 result;
            UnsafeBindings.JPH_ConeConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }

        public static float JPH_ConeConstraint_GetTotalLambdaRotation(NativeHandle<JPH_ConeConstraint> constraint)
        {
            return UnsafeBindings.JPH_ConeConstraint_GetTotalLambdaRotation(constraint);
        }

    }
}