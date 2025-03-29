namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_FixedConstraintSettings_Init(ref FixedConstraintSettings settings)
        {
            AssertInitialized();

            fixed (FixedConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_FixedConstraintSettings_Init((JPH_FixedConstraintSettings*)ptr);
            }
        }
    }
}
