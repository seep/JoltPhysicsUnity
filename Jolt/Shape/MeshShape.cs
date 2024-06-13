namespace Jolt
{
    [GenerateHandle("JPH_MeshShape"), GenerateBindings("JPH_Shape"), GenerateBindings("JPH_MeshShape")]
    public readonly partial struct MeshShape
    {
        internal readonly NativeHandle<JPH_MeshShape> Handle;

        internal MeshShape(NativeHandle<JPH_MeshShape> handle)
        {
            Handle = handle;
        }
    }
}
