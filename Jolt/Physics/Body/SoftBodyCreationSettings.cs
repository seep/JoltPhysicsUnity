namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_SoftBodyCreationSettings")]
    public partial struct SoftBodyCreationSettings
    {
        internal NativeHandle<JPH_SoftBodyCreationSettings> Handle;

        internal SoftBodyCreationSettings(NativeHandle<JPH_SoftBodyCreationSettings> handle)
        {
            Handle = handle;
        }
    }
}
