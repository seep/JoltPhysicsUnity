namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static NativeHandle<JPH_BroadPhaseLayerInterface> JPH_BroadPhaseLayerInterfaceTable_Create(uint numObjectLayers, uint numBroadPhaseLayers)
        {
            return CreateHandle(Bindings.JPH_BroadPhaseLayerInterfaceTable_Create(numObjectLayers, numBroadPhaseLayers));
        }

        public static void JPH_BroadPhaseLayerInterfaceTable_MapObjectToBroadPhaseLayer(NativeHandle<JPH_BroadPhaseLayerInterface> @interface, ObjectLayer objectLayer, BroadPhaseLayer broadPhaseLayer)
        {
            Bindings.JPH_BroadPhaseLayerInterfaceTable_MapObjectToBroadPhaseLayer(@interface, objectLayer, broadPhaseLayer);
        }
    }
}
