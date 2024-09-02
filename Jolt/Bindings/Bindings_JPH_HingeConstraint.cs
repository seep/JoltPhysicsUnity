using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_HingeConstraintSettings> JPH_HingeConstraint_GetSettings(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return CreateHandle(UnsafeBindings.JPH_HingeConstraint_GetSettings(constraint)); // TODO share safety handle with existing HingeConstraintSettings if able
        }

        public static float JPH_HingeConstraint_GetCurrentAngle(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetCurrentAngle(constraint);
        }

        public static void JPH_HingeConstraint_SetMaxFrictionTorque(NativeHandle<JPH_HingeConstraint> constraint, float frictionTorque)
        {
            UnsafeBindings.JPH_HingeConstraint_SetMaxFrictionTorque(constraint, frictionTorque);
        }

        public static float JPH_HingeConstraint_GetMaxFrictionTorque(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetMaxFrictionTorque(constraint);
        }

        public static void JPH_HingeConstraint_SetMotorSettings(NativeHandle<JPH_HingeConstraint> constraint, MotorSettings settings)
        {
            UnsafeBindings.JPH_HingeConstraint_SetMotorSettings(constraint, &settings);
        }

        public static MotorSettings JPH_HingeConstraint_GetMotorSettings(NativeHandle<JPH_HingeConstraint> constraint)
        {
            MotorSettings result;
            UnsafeBindings.JPH_HingeConstraint_GetMotorSettings(constraint, &result);
            return result;
        }

        public static void JPH_HingeConstraint_SetMotorState(NativeHandle<JPH_HingeConstraint> constraint, MotorState state)
        {
            UnsafeBindings.JPH_HingeConstraint_SetMotorState(constraint, state);
        }

        public static MotorState JPH_HingeConstraint_GetMotorState(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetMotorState(constraint);
        }

        public static void JPH_HingeConstraint_SetTargetAngularVelocity(NativeHandle<JPH_HingeConstraint> constraint, float angularVelocity)
        {
            UnsafeBindings.JPH_HingeConstraint_SetTargetAngularVelocity(constraint, angularVelocity);
        }

        public static float JPH_HingeConstraint_GetTargetAngularVelocity(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetTargetAngularVelocity(constraint);
        }

        public static void JPH_HingeConstraint_SetTargetAngle(NativeHandle<JPH_HingeConstraint> constraint, float angle)
        {
            UnsafeBindings.JPH_HingeConstraint_SetTargetAngle(constraint, angle);
        }

        public static float JPH_HingeConstraint_GetTargetAngle(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetTargetAngle(constraint);
        }

        public static void JPH_HingeConstraint_SetLimits(NativeHandle<JPH_HingeConstraint> constraint, float min, float max)
        {
            UnsafeBindings.JPH_HingeConstraint_SetLimits(constraint, min, max);
        }

        public static float JPH_HingeConstraint_GetLimitsMin(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetLimitsMin(constraint);
        }

        public static float JPH_HingeConstraint_GetLimitsMax(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetLimitsMax(constraint);
        }

        public static bool JPH_HingeConstraint_HasLimits(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_HasLimits(constraint);
        }

        public static SpringSettings JPH_HingeConstraint_GetLimitsSpringSettings(NativeHandle<JPH_HingeConstraint> constraint)
        {
            SpringSettings result;
            UnsafeBindings.JPH_HingeConstraint_GetLimitsSpringSettings(constraint, &result);
            return result;
        }

        public static void JPH_HingeConstraint_SetLimitsSpringSettings(NativeHandle<JPH_HingeConstraint> constraint, SpringSettings settings)
        {
            UnsafeBindings.JPH_HingeConstraint_SetLimitsSpringSettings(constraint, &settings);
        }

        public static float3 JPH_HingeConstraint_GetTotalLambdaPosition(NativeHandle<JPH_HingeConstraint> constraint)
        {
            float3 result;
            UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }

        public static float2 JPH_HingeConstraint_GetTotalLambdaRotation(NativeHandle<JPH_HingeConstraint> constraint)
        {
            float x;
            float y;
            UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaRotation(constraint, &x, &y);
            return new float2(x, y);
        }

        public static float JPH_HingeConstraint_GetTotalLambdaRotationLimits(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaRotationLimits(constraint);
        }

        public static float JPH_HingeConstraint_GetTotalLambdaMotor(NativeHandle<JPH_HingeConstraint> constraint)
        {
            return UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaMotor(constraint);
        }
    }
}