using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_ConeConstraint> JPH_ConeConstraint_Create(ref ConeConstraintSettings settings, NativeHandle<JPH_Body> body1, NativeHandle<JPH_Body> body2)
        {
            AssertInitialized();

            fixed (ConeConstraintSettings* ptr = &settings)
            {
                return CreateHandle(UnsafeBindings.JPH_ConeConstraint_Create((JPH_ConeConstraintSettings*)ptr, body1, body2));
            }
        }

        public static ConeConstraintSettings JPH_ConeConstraint_GetSettings(NativeHandle<JPH_ConeConstraint> constraint)
        {
            AssertInitialized();

            ConeConstraintSettings result;
            UnsafeBindings.JPH_ConeConstraint_GetSettings(constraint, (JPH_ConeConstraintSettings*)&result);
            return result;
        }

        public static void JPH_ConeConstraint_SetHalfConeAngle(NativeHandle<JPH_ConeConstraint> constraint, float halfConeAngle)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ConeConstraint_SetHalfConeAngle(constraint, halfConeAngle);
        }

        public static float JPH_ConeConstraint_GetCosHalfConeAngle(NativeHandle<JPH_ConeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ConeConstraint_GetCosHalfConeAngle(constraint);
        }

        public static float3 JPH_ConeConstraint_GetTotalLambdaPosition(NativeHandle<JPH_ConeConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_ConeConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }

        public static float JPH_ConeConstraint_GetTotalLambdaRotation(NativeHandle<JPH_ConeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ConeConstraint_GetTotalLambdaRotation(constraint);
        }

    }
}
