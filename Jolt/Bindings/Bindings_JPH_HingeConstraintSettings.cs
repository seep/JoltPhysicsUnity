namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_HingeConstraintSettings_Init(ref HingeConstraintSettings settings)
        {
            AssertInitialized();

            fixed (HingeConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_HingeConstraintSettings_Init((JPH_HingeConstraintSettings*)ptr);
            }
        }
    }
}
