namespace Jolt
{
    [GenerateHandle("JPH_BroadPhaseLayerInterface")]
    public readonly partial struct BroadPhaseLayerInterface
    {
        internal readonly NativeHandle<JPH_BroadPhaseLayerInterface> Handle;

        internal BroadPhaseLayerInterface(NativeHandle<JPH_BroadPhaseLayerInterface> handle)
        {
            Handle = handle;
        }
    }
}
