namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_SwingTwistConstraintSettings_Init(ref SwingTwistConstraintSettings settings)
        {
            AssertInitialized();

            fixed (SwingTwistConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_SwingTwistConstraintSettings_Init((JPH_SwingTwistConstraintSettings*)ptr);
            }
        }
    }
}
