using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_BroadPhaseLayerInterfaceMask")]
    public partial struct BroadPhaseLayerInterfaceMask
    {
        internal NativeHandle<JPH_BroadPhaseLayerInterface> Handle;
        
        public static BroadPhaseLayerInterfaceMask Create(uint numBroadPhaseLayers)
        {
            return new BroadPhaseLayerInterfaceMask { Handle = JPH_BroadPhaseLayerInterfaceMask_Create(numBroadPhaseLayers) };
        }
    }
}
