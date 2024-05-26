namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static float JPH_ConvexShape_GetDensity<T>(NativeHandle<T> shape) where T : unmanaged, INativeConvexShape
        {
            return Bindings.JPH_ConvexShape_GetDensity((JPH_ConvexShape*)GetPointer(shape));
        }

        public static void JPH_ConvexShape_SetDensity<T>(NativeHandle<T> shape, float density) where T : unmanaged, INativeConvexShape
        {
            Bindings.JPH_ConvexShape_SetDensity((JPH_ConvexShape*)GetPointer(shape), density);
        }
    }
}
