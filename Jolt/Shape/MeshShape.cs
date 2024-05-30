namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_Shape"), GenerateBindings("JPH_MeshShape")]
    public readonly partial struct MeshShape: IShape
    {
        internal readonly NativeHandle<JPH_MeshShape> Handle;

        internal MeshShape(NativeHandle<JPH_MeshShape> handle)
        {
            Handle = handle;
        }
    }
}
