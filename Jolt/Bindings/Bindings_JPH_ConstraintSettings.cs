namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_ConstraintSettings_Destroy(NativeHandle<JPH_ConstraintSettings> settings)
        {
            UnsafeBindings.JPH_ConstraintSettings_Destroy(settings);
        }

        public static bool JPH_ConstraintSettings_GetEnabled(NativeHandle<JPH_ConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_ConstraintSettings_GetEnabled(settings);
        }

        public static uint JPH_ConstraintSettings_GetConstraintPriority(NativeHandle<JPH_ConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_ConstraintSettings_GetConstraintPriority(settings);
        }

        public static void JPH_FixedConstraintSettings_SetConstraintPriority(NativeHandle<JPH_ConstraintSettings> settings, uint value)
        {
            UnsafeBindings.JPH_FixedConstraintSettings_SetConstraintPriority(settings, value);
        }

        public static uint JPH_ConstraintSettings_GetNumVelocityStepsOverride(NativeHandle<JPH_ConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_ConstraintSettings_GetNumVelocityStepsOverride(settings);
        }

        public static void JPH_ConstraintSettings_SetNumVelocityStepsOverride(NativeHandle<JPH_ConstraintSettings> settings, uint value)
        {
            UnsafeBindings.JPH_ConstraintSettings_SetNumVelocityStepsOverride(settings, value);
        }

        public static uint JPH_ConstraintSettings_GetNumPositionStepsOverride(NativeHandle<JPH_ConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_ConstraintSettings_GetNumPositionStepsOverride(settings);
        }

        public static void JPH_ConstraintSettings_SetNumPositionStepsOverride(NativeHandle<JPH_ConstraintSettings> settings, uint value)
        {
            UnsafeBindings.JPH_ConstraintSettings_SetNumPositionStepsOverride(settings, value);
        }

        public static float JPH_ConstraintSettings_GetDrawConstraintSize(NativeHandle<JPH_ConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_ConstraintSettings_GetDrawConstraintSize(settings);
        }

        public static void JPH_ConstraintSettings_SetDrawConstraintSize(NativeHandle<JPH_ConstraintSettings> settings, float value)
        {
            UnsafeBindings.JPH_ConstraintSettings_SetDrawConstraintSize(settings, value);
        }

        public static ulong JPH_ConstraintSettings_GetUserData(NativeHandle<JPH_ConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_ConstraintSettings_GetUserData(settings);
        }

        public static void JPH_ConstraintSettings_SetUserData(NativeHandle<JPH_ConstraintSettings> settings, ulong value)
        {
            UnsafeBindings.JPH_ConstraintSettings_SetUserData(settings, value);
        }
    }
}
