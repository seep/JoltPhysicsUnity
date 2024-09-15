using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static float JPH_SwingTwistConstraint_GetNormalHalfConeAngle(NativeHandle<JPH_SwingTwistConstraint> constraint)
        {
            return UnsafeBindings.JPH_SwingTwistConstraint_GetNormalHalfConeAngle(constraint);
        }

        public static float3 JPH_SwingTwistConstraint_GetTotalLambdaPosition(NativeHandle<JPH_SwingTwistConstraint> constraint)
        {
            float3 result;
            UnsafeBindings.JPH_SwingTwistConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }

        public static float JPH_SwingTwistConstraint_GetTotalLambdaTwist(NativeHandle<JPH_SwingTwistConstraint> constraint)
        {
            return UnsafeBindings.JPH_SwingTwistConstraint_GetTotalLambdaTwist(constraint);
        }

        public static float JPH_SwingTwistConstraint_GetTotalLambdaSwingY(NativeHandle<JPH_SwingTwistConstraint> constraint) 
        {
            return UnsafeBindings.JPH_SwingTwistConstraint_GetTotalLambdaSwingY(constraint);
        }

        public static float JPH_SwingTwistConstraint_GetTotalLambdaSwingZ(NativeHandle<JPH_SwingTwistConstraint> constraint) 
        {
            return UnsafeBindings.JPH_SwingTwistConstraint_GetTotalLambdaSwingZ(constraint);
        }

        public static float3 JPH_SwingTwistConstraint_GetTotalLambdaMotor(NativeHandle<JPH_SwingTwistConstraint> constraint) 
        {
            float3 result;
            UnsafeBindings.JPH_SwingTwistConstraint_GetTotalLambdaMotor(constraint, &result);
            return result;
        }
    }
}