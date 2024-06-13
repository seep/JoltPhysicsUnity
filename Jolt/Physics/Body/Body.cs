namespace Jolt
{
    [GenerateHandle("JPH_Body"), GenerateBindings("JPH_Body")]
    public readonly partial struct Body
    {
        internal readonly NativeHandle<JPH_Body> Handle;

        internal Body(NativeHandle<JPH_Body> handle)
        {
            Handle = handle;
        }
    }
}
