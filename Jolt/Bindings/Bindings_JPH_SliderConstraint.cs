using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_SliderConstraint> JPH_SliderConstraint_Create(ref SliderConstraintSettings settings, NativeHandle<JPH_Body> body1, NativeHandle<JPH_Body> body2)
        {
            AssertInitialized();

            fixed (SliderConstraintSettings* ptr = &settings)
            {
                return CreateHandle(UnsafeBindings.JPH_SliderConstraint_Create((JPH_SliderConstraintSettings*)ptr, body1, body2));
            }
        }

        public static SliderConstraintSettings JPH_SliderConstraint_GetSettings(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            SliderConstraintSettings result;
            UnsafeBindings.JPH_SliderConstraint_GetSettings(constraint, (JPH_SliderConstraintSettings*)&result);
            return result;
        }

        public static float JPH_SliderConstraint_GetCurrentPosition(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SliderConstraint_GetCurrentPosition(constraint);
        }

        public static void JPH_SliderConstraint_SetMaxFrictionForce(NativeHandle<JPH_SliderConstraint> constraint, float force)
        {
            AssertInitialized();

            UnsafeBindings.JPH_SliderConstraint_SetMaxFrictionForce(constraint, force);
        }

        public static float JPH_SliderConstraint_GetMaxFrictionForce(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SliderConstraint_GetMaxFrictionForce(constraint);
        }

        public static void JPH_SliderConstraint_SetMotorSettings(NativeHandle<JPH_SliderConstraint> constraint, MotorSettings settings)
        {
            AssertInitialized();

            UnsafeBindings.JPH_SliderConstraint_SetMotorSettings(constraint, (JPH_MotorSettings*)&settings);
        }

        public static MotorSettings JPH_SliderConstraint_GetMotorSettings(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            MotorSettings result;
            UnsafeBindings.JPH_SliderConstraint_GetMotorSettings(constraint, (JPH_MotorSettings*)&result);
            return result;
        }

        public static void JPH_SliderConstraint_SetMotorState(NativeHandle<JPH_SliderConstraint> constraint, MotorState state)
        {
            AssertInitialized();

            UnsafeBindings.JPH_SliderConstraint_SetMotorState(constraint, state);
        }

        public static MotorState JPH_SliderConstraint_GetMotorState(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SliderConstraint_GetMotorState(constraint);
        }

        public static void JPH_SliderConstraint_SetTargetVelocity(NativeHandle<JPH_SliderConstraint> constraint, float velocity)
        {
            AssertInitialized();

            UnsafeBindings.JPH_SliderConstraint_SetTargetVelocity(constraint, velocity);
        }

        public static float JPH_SliderConstraint_GetTargetVelocity(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SliderConstraint_GetTargetVelocity(constraint);
        }

        public static void JPH_SliderConstraint_SetTargetPosition(NativeHandle<JPH_SliderConstraint> constraint, float position)
        {
            AssertInitialized();

            UnsafeBindings.JPH_SliderConstraint_SetTargetPosition(constraint, position);
        }

        public static float JPH_SliderConstraint_GetTargetPosition(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SliderConstraint_GetTargetPosition(constraint);
        }

        public static void JPH_SliderConstraint_SetLimits(NativeHandle<JPH_SliderConstraint> constraint, float min, float max)
        {
            AssertInitialized();

            UnsafeBindings.JPH_SliderConstraint_SetLimits(constraint, min, max);
        }

        public static float JPH_SliderConstraint_GetLimitsMin(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SliderConstraint_GetLimitsMin(constraint);
        }

        public static float JPH_SliderConstraint_GetLimitsMax(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SliderConstraint_GetLimitsMax(constraint);
        }

        public static bool JPH_SliderConstraint_HasLimits(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SliderConstraint_HasLimits(constraint);
        }

        public static SpringSettings JPH_SliderConstraint_GetLimitsSpringSettings(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            SpringSettings result;
            UnsafeBindings.JPH_SliderConstraint_GetLimitsSpringSettings(constraint, (JPH_SpringSettings*)&result);
            return result;
        }

        public static void JPH_SliderConstraint_SetLimitsSpringSettings(NativeHandle<JPH_SliderConstraint> constraint, SpringSettings settings)
        {
            AssertInitialized();

            UnsafeBindings.JPH_SliderConstraint_SetLimitsSpringSettings(constraint, (JPH_SpringSettings*)&settings);
        }

        public static float2 JPH_SliderConstraint_GetTotalLambdaPosition(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            float2 result;
            UnsafeBindings.JPH_SliderConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }

        public static float JPH_SliderConstraint_GetTotalLambdaPositionLimits(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SliderConstraint_GetTotalLambdaPositionLimits(constraint);
        }

        public static float3 JPH_SliderConstraint_GetTotalLambdaRotation(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_SliderConstraint_GetTotalLambdaRotation(constraint, &result);
            return result;
        }

        public static float JPH_SliderConstraint_GetTotalLambdaMotor(NativeHandle<JPH_SliderConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SliderConstraint_GetTotalLambdaMotor(constraint);
        }
    }
}
