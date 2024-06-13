using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_BroadPhaseLayerInterface"), GenerateBindings("JPH_BroadPhaseLayerInterfaceTable")]
    public readonly partial struct BroadPhaseLayerInterfaceTable
    {
        internal readonly NativeHandle<JPH_BroadPhaseLayerInterface> Handle;

        internal BroadPhaseLayerInterfaceTable(NativeHandle<JPH_BroadPhaseLayerInterface> handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Implicit reinterpret cast as the base class BroadPhaseLayerInterface.
        /// </summary>
        public static implicit operator BroadPhaseLayerInterface(BroadPhaseLayerInterfaceTable table)
        {
            return new BroadPhaseLayerInterface(table.Handle);
        }

        [OverrideBinding("JPH_BroadPhaseLayerInterfaceTable_Create")]
        public static BroadPhaseLayerInterfaceTable Create(uint numObjectLayers, uint numBroadPhaseLayers)
        {
            return new BroadPhaseLayerInterfaceTable(JPH_BroadPhaseLayerInterfaceTable_Create(numObjectLayers, numBroadPhaseLayers));
        }
    }
}
