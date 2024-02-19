namespace Jolt
{
    public struct BroadPhaseLayerInterface
    {
        internal NativeOwnedHandle<JPH_BroadPhaseLayerInterface> Handle;

        internal BroadPhaseLayerInterface(NativeOwnedHandle<JPH_BroadPhaseLayerInterface> handle)
        {
            Handle = handle;
        }
    }
}
