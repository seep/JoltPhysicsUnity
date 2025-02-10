using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_SixDOFConstraint> JPH_SixDOFConstraint_Create(ref SixDOFConstraintSettings settings, NativeHandle<JPH_Body> body1, NativeHandle<JPH_Body> body2)
        {
            fixed (SixDOFConstraintSettings* ptr = &settings)
            {
                return CreateHandle(UnsafeBindings.JPH_SixDOFConstraint_Create((JPH_SixDOFConstraintSettings*)ptr, body1, body2));
            }
        }

        public static SixDOFConstraintSettings JPH_SixDOFConstraint_GetSettings(NativeHandle<JPH_SixDOFConstraint> constraint)
        {
            SixDOFConstraintSettings result;
            UnsafeBindings.JPH_SixDOFConstraint_GetSettings(constraint, (JPH_SixDOFConstraintSettings*)&result);
            return result;
        }

        public static float JPH_SixDOFConstraint_GetLimitsMin(NativeHandle<JPH_SixDOFConstraint> constraint, SixDOFConstraintAxis axis)
        {
            return UnsafeBindings.JPH_SixDOFConstraint_GetLimitsMin(constraint, axis);
        }

        public static float JPH_SixDOFConstraint_GetLimitsMax(NativeHandle<JPH_SixDOFConstraint> constraint, SixDOFConstraintAxis axis) 
        {
            return UnsafeBindings.JPH_SixDOFConstraint_GetLimitsMax(constraint, axis);
        }

        public static float3 JPH_SixDOFConstraint_GetTotalLambdaPosition(NativeHandle<JPH_SixDOFConstraint> constraint)
        {
            float3 result;
            UnsafeBindings.JPH_SixDOFConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }

        public static float3 JPH_SixDOFConstraint_GetTotalLambdaRotation(NativeHandle<JPH_SixDOFConstraint> constraint) 
        {
            float3 result;
            UnsafeBindings.JPH_SixDOFConstraint_GetTotalLambdaRotation(constraint, &result);
            return result;
        }

        public static float3 JPH_SixDOFConstraint_GetTotalLambdaMotorTranslation(NativeHandle<JPH_SixDOFConstraint> constraint) 
        {
            float3 result;
            UnsafeBindings.JPH_SixDOFConstraint_GetTotalLambdaMotorTranslation(constraint, &result);
            return result;
        }

        public static float3 JPH_SixDOFConstraint_GetTotalLambdaMotorRotation(NativeHandle<JPH_SixDOFConstraint> constraint) 
        {
            float3 result;
            UnsafeBindings.JPH_SixDOFConstraint_GetTotalLambdaMotorRotation(constraint, &result);
            return result;
        }
    }
}