namespace Jolt
{
    [GenerateHandle]
    public readonly partial struct ObjectLayerPairFilter
    {
        internal readonly NativeHandle<JPH_ObjectLayerPairFilter> Handle;

        internal ObjectLayerPairFilter(NativeHandle<JPH_ObjectLayerPairFilter> handle)
        {
            Handle = handle;
        }
    }
}
