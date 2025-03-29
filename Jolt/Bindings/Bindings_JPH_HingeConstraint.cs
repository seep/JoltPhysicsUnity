using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_HingeConstraint> JPH_HingeConstraint_Create(ref HingeConstraintSettings settings, NativeHandle<JPH_Body> body1, NativeHandle<JPH_Body> body2)
        {
            AssertInitialized();

            fixed (HingeConstraintSettings* ptr = &settings)
            {
                return CreateHandle(UnsafeBindings.JPH_HingeConstraint_Create((JPH_HingeConstraintSettings*)ptr, body1, body2));
            }
        }

        public static HingeConstraintSettings JPH_HingeConstraint_GetSettings(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            HingeConstraintSettings result;
            UnsafeBindings.JPH_HingeConstraint_GetSettings(constraint, (JPH_HingeConstraintSettings*)&result);
            return result;
        }

        public static float3 JPH_HingeConstraint_GetLocalSpacePoint1(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_HingeConstraint_GetLocalSpacePoint1(constraint, &result);
            return result;
        }

        public static float3 JPH_HingeConstraint_GetLocalSpacePoint2(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_HingeConstraint_GetLocalSpacePoint2(constraint, &result);
            return result;
        }

        public static float3 JPH_HingeConstraint_GetLocalSpaceHingeAxis1(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_HingeConstraint_GetLocalSpaceHingeAxis1(constraint, &result);
            return result;
        }

        public static float3 JPH_HingeConstraint_GetLocalSpaceHingeAxis2(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_HingeConstraint_GetLocalSpaceHingeAxis2(constraint, &result);
            return result;
        }

        public static float3 JPH_HingeConstraint_GetLocalSpaceNormalAxis1(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_HingeConstraint_GetLocalSpaceNormalAxis1(constraint, &result);
            return result;
        }

        public static float3 JPH_HingeConstraint_GetLocalSpaceNormalAxis2(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_HingeConstraint_GetLocalSpaceNormalAxis2(constraint, &result);
            return result;
        }

        public static float JPH_HingeConstraint_GetCurrentAngle(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HingeConstraint_GetCurrentAngle(constraint);
        }

        public static void JPH_HingeConstraint_SetMaxFrictionTorque(NativeHandle<JPH_HingeConstraint> constraint, float frictionTorque)
        {
            AssertInitialized();

            UnsafeBindings.JPH_HingeConstraint_SetMaxFrictionTorque(constraint, frictionTorque);
        }

        public static float JPH_HingeConstraint_GetMaxFrictionTorque(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HingeConstraint_GetMaxFrictionTorque(constraint);
        }

        public static void JPH_HingeConstraint_SetMotorSettings(NativeHandle<JPH_HingeConstraint> constraint, MotorSettings settings)
        {
            AssertInitialized();

            UnsafeBindings.JPH_HingeConstraint_SetMotorSettings(constraint, (JPH_MotorSettings*)&settings);
        }

        public static MotorSettings JPH_HingeConstraint_GetMotorSettings(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            MotorSettings settings;
            UnsafeBindings.JPH_HingeConstraint_GetMotorSettings(constraint, (JPH_MotorSettings*)&settings);
            return settings;
        }

        public static void JPH_HingeConstraint_SetMotorState(NativeHandle<JPH_HingeConstraint> constraint, MotorState state)
        {
            AssertInitialized();

            UnsafeBindings.JPH_HingeConstraint_SetMotorState(constraint, state);
        }

        public static MotorState JPH_HingeConstraint_GetMotorState(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HingeConstraint_GetMotorState(constraint);
        }

        public static void JPH_HingeConstraint_SetTargetAngularVelocity(NativeHandle<JPH_HingeConstraint> constraint, float angularVelocity)
        {
            AssertInitialized();

            UnsafeBindings.JPH_HingeConstraint_SetTargetAngularVelocity(constraint, angularVelocity);
        }

        public static float JPH_HingeConstraint_GetTargetAngularVelocity(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HingeConstraint_GetTargetAngularVelocity(constraint);
        }

        public static void JPH_HingeConstraint_SetTargetAngle(NativeHandle<JPH_HingeConstraint> constraint, float angle)
        {
            AssertInitialized();

            UnsafeBindings.JPH_HingeConstraint_SetTargetAngle(constraint, angle);
        }

        public static float JPH_HingeConstraint_GetTargetAngle(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HingeConstraint_GetTargetAngle(constraint);
        }

        public static void JPH_HingeConstraint_SetLimits(NativeHandle<JPH_HingeConstraint> constraint, float min, float max)
        {
            AssertInitialized();

            UnsafeBindings.JPH_HingeConstraint_SetLimits(constraint, min, max);
        }

        public static float JPH_HingeConstraint_GetLimitsMin(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HingeConstraint_GetLimitsMin(constraint);
        }

        public static float JPH_HingeConstraint_GetLimitsMax(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HingeConstraint_GetLimitsMax(constraint);
        }

        public static bool JPH_HingeConstraint_HasLimits(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HingeConstraint_HasLimits(constraint);
        }

        public static SpringSettings JPH_HingeConstraint_GetLimitsSpringSettings(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            SpringSettings settings;
            UnsafeBindings.JPH_HingeConstraint_GetLimitsSpringSettings(constraint, (JPH_SpringSettings*)&settings);
            return settings;
        }

        public static void JPH_HingeConstraint_SetLimitsSpringSettings(NativeHandle<JPH_HingeConstraint> constraint, SpringSettings settings)
        {
            AssertInitialized();

            UnsafeBindings.JPH_HingeConstraint_SetLimitsSpringSettings(constraint, (JPH_SpringSettings*)&settings);
        }

        public static float3 JPH_HingeConstraint_GetTotalLambdaPosition(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaPosition(constraint, &result);
            return result;
        }

        public static float2 JPH_HingeConstraint_GetTotalLambdaRotation(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            float2 result;
            UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaRotation(constraint, &result);
            return result;
        }

        public static float JPH_HingeConstraint_GetTotalLambdaRotationLimits(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaRotationLimits(constraint);
        }

        public static float JPH_HingeConstraint_GetTotalLambdaMotor(NativeHandle<JPH_HingeConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HingeConstraint_GetTotalLambdaMotor(constraint);
        }
    }
}
