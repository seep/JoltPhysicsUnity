namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_DistanceConstraint> JPH_DistanceConstraint_Create(ref DistanceConstraintSettings settings, NativeHandle<JPH_Body> body1, NativeHandle<JPH_Body> body2)
        {
            AssertInitialized();

            fixed (DistanceConstraintSettings* ptr = &settings)
            {
                return CreateHandle(UnsafeBindings.JPH_DistanceConstraint_Create((JPH_DistanceConstraintSettings*)ptr, body1, body2));
            }
        }

        public static void JPH_DistanceConstraint_GetSettings(NativeHandle<JPH_DistanceConstraint> constraint, ref DistanceConstraintSettings settings)
        {
            AssertInitialized();

            fixed (DistanceConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_DistanceConstraint_GetSettings(constraint, (JPH_DistanceConstraintSettings*)ptr);
            }
        }

        public static void JPH_DistanceConstraint_SetDistance(NativeHandle<JPH_DistanceConstraint> constraint, float minDistance, float maxDistance)
        {
            AssertInitialized();

            UnsafeBindings.JPH_DistanceConstraint_SetDistance(constraint, minDistance, maxDistance);
        }

        public static float JPH_DistanceConstraint_GetMinDistance(NativeHandle<JPH_DistanceConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_DistanceConstraint_GetMinDistance(constraint);
        }

        public static float JPH_DistanceConstraint_GetMaxDistance(NativeHandle<JPH_DistanceConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_DistanceConstraint_GetMaxDistance(constraint);
        }

        public static SpringSettings JPH_DistanceConstraint_GetLimitsSpringSettings(NativeHandle<JPH_DistanceConstraint> constraint)
        {
            AssertInitialized();

            SpringSettings settings;
            UnsafeBindings.JPH_DistanceConstraint_GetLimitsSpringSettings(constraint, (JPH_SpringSettings*)&settings);
            return settings;
        }

        public static void JPH_DistanceConstraint_SetLimitsSpringSettings(NativeHandle<JPH_DistanceConstraint> constraint, SpringSettings settings)
        {
            AssertInitialized();

            UnsafeBindings.JPH_DistanceConstraint_SetLimitsSpringSettings(constraint, (JPH_SpringSettings*)&settings);
        }

        public static float JPH_DistanceConstraint_GetTotalLambdaPosition(NativeHandle<JPH_DistanceConstraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_DistanceConstraint_GetTotalLambdaPosition(constraint);
        }
    }
}
