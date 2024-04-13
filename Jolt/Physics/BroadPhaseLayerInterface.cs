namespace Jolt
{
    public struct BroadPhaseLayerInterface
    {
        internal NativeHandle<JPH_BroadPhaseLayerInterface> Handle;

        internal BroadPhaseLayerInterface(NativeHandle<JPH_BroadPhaseLayerInterface> handle)
        {
            Handle = handle;
        }
    }
}
