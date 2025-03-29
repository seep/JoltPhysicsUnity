namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_SixDOFConstraintSettings_Init(ref SixDOFConstraintSettings settings)
        {
            AssertInitialized();

            fixed (SixDOFConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_SixDOFConstraintSettings_Init((JPH_SixDOFConstraintSettings*)ptr);
            }
        }
    }
}
