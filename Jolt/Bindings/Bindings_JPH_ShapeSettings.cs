namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_ShapeSettings_Destroy(NativeHandle<JPH_ShapeSettings> settings)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ShapeSettings_Destroy(settings);
            settings.Dispose();
        }

        public static ulong JPH_ShapeSettings_GetUserData(NativeHandle<JPH_ShapeSettings> settings)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ShapeSettings_GetUserData(settings);
        }

        public static void JPH_ShapeSettings_SetUserData(NativeHandle<JPH_ShapeSettings> settings, ulong data)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ShapeSettings_SetUserData(settings, data);
        }
    }
}
