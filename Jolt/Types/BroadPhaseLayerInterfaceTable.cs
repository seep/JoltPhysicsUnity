using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_BroadPhaseLayerInterfaceTable")]
    public partial struct BroadPhaseLayerInterfaceTable
    {
        internal NativeHandle<JPH_BroadPhaseLayerInterface> Handle;
        
        public static BroadPhaseLayerInterfaceTable Create(uint numObjectLayers, uint numBroadPhaseLayers)
        {
            return new BroadPhaseLayerInterfaceTable { Handle = JPH_BroadPhaseLayerInterfaceTable_Create(numObjectLayers, numBroadPhaseLayers) };
        }
    }
}
