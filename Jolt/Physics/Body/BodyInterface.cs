namespace Jolt
{
    [GenerateHandle("JPH_BodyInterface"), GenerateBindings("JPH_BodyInterface")]
    public readonly partial struct BodyInterface
    {
        internal readonly NativeHandle<JPH_BodyInterface> Handle;

        internal BodyInterface(NativeHandle<JPH_BodyInterface> handle)
        {
            Handle = handle;
        }
    }
}
