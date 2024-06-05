namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_ShapeSettings_Destroy<T>(NativeHandle<T> settings) where T : unmanaged, INativeShapeSettings
        {
            UnsafeBindings.JPH_ShapeSettings_Destroy(settings.Reinterpret<JPH_ShapeSettings>());

            settings.Dispose();
        }
    }
}
