namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_GearConstraintSettings_Init(ref GearConstraintSettings settings)
        {
            AssertInitialized();

            fixed (GearConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_GearConstraintSettings_Init((JPH_GearConstraintSettings*)ptr);
            }
        }
    }
}
