namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_ShapeSettings_Destroy(NativeHandle<JPH_ShapeSettings> settings)
        {
            UnsafeBindings.JPH_ShapeSettings_Destroy(settings);
            settings.Dispose();
        }
        
        public static ulong JPH_ShapeSettings_GetUserData(NativeHandle<JPH_ShapeSettings> settings)
        {
            return UnsafeBindings.JPH_ShapeSettings_GetUserData(settings);
        }
        
        public static void JPH_ShapeSettings_SetUserData(NativeHandle<JPH_ShapeSettings> settings, ulong data)
        {
            UnsafeBindings.JPH_ShapeSettings_SetUserData(settings, data);
        }
    }
}
