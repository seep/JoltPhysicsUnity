using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_SliderConstraintSettings> JPH_SliderConstraint_GetSettings(NativeHandle<JPH_SliderConstraint> constraint)
        {
            return CreateHandle(UnsafeBindings.JPH_SliderConstraint_GetSettings(constraint)); // TODO reuse existing safety handle
        }

        public static float JPH_SliderConstraint_GetCurrentPosition(NativeHandle<JPH_SliderConstraint> constraint) 
        {
            return UnsafeBindings.JPH_SliderConstraint_GetCurrentPosition(constraint);   
        }

        public static void JPH_SliderConstraint_SetMaxFrictionForce(NativeHandle<JPH_SliderConstraint> constraint, float force)
        {
            UnsafeBindings.JPH_SliderConstraint_SetMaxFrictionForce(constraint, force);
        }

        public static float JPH_SliderConstraint_GetMaxFrictionForce(NativeHandle<JPH_SliderConstraint> constraint)
        {
            return UnsafeBindings.JPH_SliderConstraint_GetMaxFrictionForce(constraint);
        }

        public static void JPH_SliderConstraint_SetMotorSettings(NativeHandle<JPH_SliderConstraint> constraint, MotorSettings settings)
        {
            UnsafeBindings.JPH_SliderConstraint_SetMotorSettings(constraint, &settings);
        }

        public static MotorSettings JPH_SliderConstraint_GetMotorSettings(NativeHandle<JPH_SliderConstraint> constraint)
        {
            MotorSettings result;
            UnsafeBindings.JPH_SliderConstraint_GetMotorSettings(constraint, &result);
            return result;
        }

        public static void JPH_SliderConstraint_SetMotorState(NativeHandle<JPH_SliderConstraint> constraint, MotorState state)
        {
            UnsafeBindings.JPH_SliderConstraint_SetMotorState(constraint, state);
        }

        public static MotorState JPH_SliderConstraint_GetMotorState(NativeHandle<JPH_SliderConstraint> constraint)
        {
            return UnsafeBindings.JPH_SliderConstraint_GetMotorState(constraint);
        }

        public static void JPH_SliderConstraint_SetTargetVelocity(NativeHandle<JPH_SliderConstraint> constraint, float velocity) 
        {
            UnsafeBindings.JPH_SliderConstraint_SetTargetVelocity(constraint, velocity);
        }

        public static float JPH_SliderConstraint_GetTargetVelocity(NativeHandle<JPH_SliderConstraint> constraint)
        {
            return UnsafeBindings.JPH_SliderConstraint_GetTargetVelocity(constraint);
        }

        public static void JPH_SliderConstraint_SetTargetPosition(NativeHandle<JPH_SliderConstraint> constraint, float position)
        {
            UnsafeBindings.JPH_SliderConstraint_SetTargetPosition(constraint, position);
        }

        public static float JPH_SliderConstraint_GetTargetPosition(NativeHandle<JPH_SliderConstraint> constraint)
        {
            return UnsafeBindings.JPH_SliderConstraint_GetTargetPosition(constraint);
        }

        public static void JPH_SliderConstraint_SetLimits(NativeHandle<JPH_SliderConstraint> constraint, float min, float max) 
        {
            UnsafeBindings.JPH_SliderConstraint_SetLimits(constraint, min, max);
        }

        public static float JPH_SliderConstraint_GetLimitsMin(NativeHandle<JPH_SliderConstraint> constraint) 
        {
            return UnsafeBindings.JPH_SliderConstraint_GetLimitsMin(constraint);
        }

        public static float JPH_SliderConstraint_GetLimitsMax(NativeHandle<JPH_SliderConstraint> constraint) 
        {
            return UnsafeBindings.JPH_SliderConstraint_GetLimitsMax(constraint);
        }

        public static bool JPH_SliderConstraint_HasLimits(NativeHandle<JPH_SliderConstraint> constraint)
        {
            return UnsafeBindings.JPH_SliderConstraint_HasLimits(constraint);
        }

        public static SpringSettings JPH_SliderConstraint_GetLimitsSpringSettings(NativeHandle<JPH_SliderConstraint> constraint)
        {
            SpringSettings result;
            UnsafeBindings.JPH_SliderConstraint_GetLimitsSpringSettings(constraint, &result);
            return result;
        }

        public static void JPH_SliderConstraint_SetLimitsSpringSettings(NativeHandle<JPH_SliderConstraint> constraint, SpringSettings settings)
        {
            UnsafeBindings.JPH_SliderConstraint_SetLimitsSpringSettings(constraint, &settings);
        }

        public static void JPH_SliderConstraint_GetTotalLambdaPosition(NativeHandle<JPH_SliderConstraint> constraint, out float x, out float y)
        {
            x = default;
            y = default;

            fixed (float* xptr = &x)
            fixed (float* yptr = &y)
            {
                UnsafeBindings.JPH_SliderConstraint_GetTotalLambdaPosition(constraint, xptr, yptr);   
            }
        }

        public static float JPH_SliderConstraint_GetTotalLambdaPositionLimits(NativeHandle<JPH_SliderConstraint> constraint)
        {
            return UnsafeBindings.JPH_SliderConstraint_GetTotalLambdaPositionLimits(constraint);
        }

        public static float3 JPH_SliderConstraint_GetTotalLambdaRotation(NativeHandle<JPH_SliderConstraint> constraint)
        {
            float3 result;
            UnsafeBindings.JPH_SliderConstraint_GetTotalLambdaRotation(constraint, &result);
            return result;
        }

        public static float JPH_SliderConstraint_GetTotalLambdaMotor(NativeHandle<JPH_SliderConstraint> constraint)
        {
            return UnsafeBindings.JPH_SliderConstraint_GetTotalLambdaMotor(constraint);
        }
    }
}