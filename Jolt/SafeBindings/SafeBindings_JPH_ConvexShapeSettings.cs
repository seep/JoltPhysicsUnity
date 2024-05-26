namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static float JPH_ConvexShapeSettings_GetDensity<T>(NativeHandle<T> settings) where T : unmanaged, INativeConvexShapeSettings
        {
            return Bindings.JPH_ConvexShapeSettings_GetDensity((JPH_ConvexShapeSettings*)GetPointer(settings));
        }

        public static void JPH_ConvexShapeSettings_SetDensity<T>(NativeHandle<T> settings, float density) where T : unmanaged, INativeConvexShapeSettings
        {
            Bindings.JPH_ConvexShapeSettings_SetDensity((JPH_ConvexShapeSettings*)GetPointer(settings), density);
        }
    }
}
