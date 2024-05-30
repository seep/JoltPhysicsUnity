namespace Jolt
{
    [GenerateHandle]
    public readonly partial struct ObjectVsBroadPhaseLayerFilter
    {
        internal readonly NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> Handle;

        internal ObjectVsBroadPhaseLayerFilter(NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> handle)
        {
            Handle = handle;
        }
    }
}
