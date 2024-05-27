namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static float JPH_ConvexShape_GetDensity<T>(NativeHandle<T> shape) where T : unmanaged, INativeConvexShape
        {
            return Bindings.JPH_ConvexShape_GetDensity(shape.Reinterpret<JPH_ConvexShape>());
        }

        public static void JPH_ConvexShape_SetDensity<T>(NativeHandle<T> shape, float density) where T : unmanaged, INativeConvexShape
        {
            Bindings.JPH_ConvexShape_SetDensity(shape.Reinterpret<JPH_ConvexShape>(), density);
        }
    }
}
