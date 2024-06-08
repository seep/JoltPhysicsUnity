namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ConstraintSettings")]
    public readonly partial struct ConstraintSettings
    {
        internal readonly NativeHandle<JPH_ConstraintSettings> Handle;

        internal ConstraintSettings(NativeHandle<JPH_ConstraintSettings> handle)
        {
            Handle = handle;
        }
    }
}
