namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static void JPH_ShapeSettings_Destroy<T>(NativeHandle<T> settings) where T : unmanaged, INativeShapeSettings
        {
            Bindings.JPH_ShapeSettings_Destroy((JPH_ShapeSettings*)GetPointer(settings));

            settings.Dispose();
        }
    }
}
