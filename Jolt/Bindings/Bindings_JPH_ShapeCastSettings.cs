namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_ShapeCastSettings_Init(ref ShapeCastSettings settings)
        {
            AssertInitialized();

            fixed (ShapeCastSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_ShapeCastSettings_Init((JPH_ShapeCastSettings*)ptr);
            }
        }
    }
}
