using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle]
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

        #region JPH_BroadPhaseLayerInterfaceTable

        public static BroadPhaseLayerInterfaceTable Create(uint numObjectLayers, uint numBroadPhaseLayers)
        {
            return new BroadPhaseLayerInterfaceTable(JPH_BroadPhaseLayerInterfaceTable_Create(numObjectLayers, numBroadPhaseLayers));
        }

        public void MapObjectToBroadPhaseLayer(ObjectLayer objectLayer, BroadPhaseLayer broadPhaseLayer)
        {
            JPH_BroadPhaseLayerInterfaceTable_MapObjectToBroadPhaseLayer(Handle, objectLayer, broadPhaseLayer);
        }

        #endregion
    }
}
