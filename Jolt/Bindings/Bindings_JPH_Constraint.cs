using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_Constraint_Destroy(NativeHandle<JPH_Constraint> constraint)
        {
            AssertInitialized();

            UnsafeBindings.JPH_Constraint_Destroy(constraint);
            constraint.Dispose();
        }

        public static ConstraintType JPH_Constraint_GetType(NativeHandle<JPH_Constraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_Constraint_GetType(constraint);
        }

        public static ConstraintSubType JPH_Constraint_GetSubType(NativeHandle<JPH_Constraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_Constraint_GetSubType(constraint);
        }

        public static uint JPH_Constraint_GetConstraintPriority(NativeHandle<JPH_Constraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_Constraint_GetConstraintPriority(constraint);
        }

        public static void JPH_Constraint_SetConstraintPriority(NativeHandle<JPH_Constraint> constraint, uint priority)
        {
            AssertInitialized();

            UnsafeBindings.JPH_Constraint_SetConstraintPriority(constraint, priority);
        }

        public static uint JPH_Constraint_GetNumVelocityStepsOverride(NativeHandle<JPH_Constraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_Constraint_GetNumVelocityStepsOverride(constraint);
        }

        public static void JPH_Constraint_SetNumVelocityStepsOverride(NativeHandle<JPH_Constraint> constraint, uint value)
        {
            AssertInitialized();

            UnsafeBindings.JPH_Constraint_SetNumVelocityStepsOverride(constraint, value);
        }

        public static uint JPH_Constraint_GetNumPositionStepsOverride(NativeHandle<JPH_Constraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_Constraint_GetNumPositionStepsOverride(constraint);
        }

        public static void JPH_Constraint_SetNumPositionStepsOverride(NativeHandle<JPH_Constraint> constraint, uint value)
        {
            AssertInitialized();

            UnsafeBindings.JPH_Constraint_SetNumPositionStepsOverride(constraint, value);
        }

        public static bool JPH_Constraint_GetEnabled(NativeHandle<JPH_Constraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_Constraint_GetEnabled(constraint);
        }

        public static void JPH_Constraint_SetEnabled(NativeHandle<JPH_Constraint> constraint, bool enabled)
        {
            AssertInitialized();

            UnsafeBindings.JPH_Constraint_SetEnabled(constraint, enabled);
        }

        public static ulong JPH_Constraint_GetUserData(NativeHandle<JPH_Constraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_Constraint_GetUserData(constraint);
        }

        public static void JPH_Constraint_SetUserData(NativeHandle<JPH_Constraint> constraint, ulong userData)
        {
            AssertInitialized();

            UnsafeBindings.JPH_Constraint_SetUserData(constraint, userData);
        }

        public static void JPH_Constraint_NotifyShapeChanged(NativeHandle<JPH_Constraint> constraint, BodyID bodyID, float3 deltaCOM)
        {
            AssertInitialized();

            UnsafeBindings.JPH_Constraint_NotifyShapeChanged(constraint, bodyID, &deltaCOM);
        }

        public static void JPH_Constraint_ResetWarmStart(NativeHandle<JPH_Constraint> constraint)
        {
            AssertInitialized();

            UnsafeBindings.JPH_Constraint_ResetWarmStart(constraint);
        }

        public static bool JPH_Constraint_IsActive(NativeHandle<JPH_Constraint> constraint)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_Constraint_IsActive(constraint);
        }

        public static void JPH_Constraint_SetupVelocityConstraint(NativeHandle<JPH_Constraint> constraint, float deltaTime)
        {
            AssertInitialized();

            UnsafeBindings.JPH_Constraint_SetupVelocityConstraint(constraint, deltaTime);
        }

        public static void JPH_Constraint_WarmStartVelocityConstraint(NativeHandle<JPH_Constraint> constraint, float warmStartImpulseRatio)
        {
            AssertInitialized();

            UnsafeBindings.JPH_Constraint_WarmStartVelocityConstraint(constraint, warmStartImpulseRatio);
        }

        public static bool JPH_Constraint_SolveVelocityConstraint(NativeHandle<JPH_Constraint> constraint, float deltaTime)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_Constraint_SolveVelocityConstraint(constraint, deltaTime);
        }

        public static bool JPH_Constraint_SolvePositionConstraint(NativeHandle<JPH_Constraint> constraint, float deltaTime, float baumgarte)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_Constraint_SolvePositionConstraint(constraint, deltaTime, baumgarte);
        }
    }
}
