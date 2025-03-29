namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_ConeConstraintSettings_Init(ref ConeConstraintSettings settings)
        {
            AssertInitialized();

            fixed (ConeConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_ConeConstraintSettings_Init((JPH_ConeConstraintSettings*)ptr);
            }
        }
    }
}
