namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_SoftBodyCreationSettings> JPH_SoftBodyCreationSettings()
        {
            return CreateHandle(UnsafeBindings.JPH_SoftBodyCreationSettings_Create());
        }
    }
}
