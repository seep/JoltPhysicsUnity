namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_CollideShapeSettings_Init(ref CollideShapeSettings settings)
        {
            AssertInitialized();

            fixed (CollideShapeSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_CollideShapeSettings_Init((JPH_CollideShapeSettings*)ptr);
            }
        }
    }
}
