namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static float JPH_ConvexShapeSettings_GetDensity<T>(NativeHandle<T> settings) where T : unmanaged, INativeConvexShapeSettings
        {
            return UnsafeBindings.JPH_ConvexShapeSettings_GetDensity(settings.Reinterpret<JPH_ConvexShapeSettings>());
        }

        public static void JPH_ConvexShapeSettings_SetDensity<T>(NativeHandle<T> settings, float density) where T : unmanaged, INativeConvexShapeSettings
        {
            UnsafeBindings.JPH_ConvexShapeSettings_SetDensity(settings.Reinterpret<JPH_ConvexShapeSettings>(), density);
        }
    }
}
