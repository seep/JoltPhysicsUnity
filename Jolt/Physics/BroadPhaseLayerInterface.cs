namespace Jolt
{
    [GenerateHandle]
    public readonly partial struct BroadPhaseLayerInterface
    {
        internal readonly NativeHandle<JPH_BroadPhaseLayerInterface> Handle;

        internal BroadPhaseLayerInterface(NativeHandle<JPH_BroadPhaseLayerInterface> handle)
        {
            Handle = handle;
        }
    }
}
