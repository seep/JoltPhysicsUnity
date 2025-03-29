namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static float JPH_ConvexShape_GetDensity(NativeHandle<JPH_ConvexShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ConvexShape_GetDensity(shape);
        }

        public static void JPH_ConvexShape_SetDensity(NativeHandle<JPH_ConvexShape> shape, float density)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ConvexShape_SetDensity(shape, density);
        }
    }
}
