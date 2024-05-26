namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static NativeHandle<JPH_SoftBodyCreationSettings> JPH_SoftBodyCreationSettings()
        {
            return CreateHandle(Bindings.JPH_SoftBodyCreationSettings_Create());
        }
    }
}
