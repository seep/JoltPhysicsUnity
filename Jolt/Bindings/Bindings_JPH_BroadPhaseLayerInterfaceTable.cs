namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_BroadPhaseLayerInterface> JPH_BroadPhaseLayerInterfaceTable_Create(uint numObjectLayers, uint numBroadPhaseLayers)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_BroadPhaseLayerInterfaceTable_Create(numObjectLayers, numBroadPhaseLayers));
        }

        public static void JPH_BroadPhaseLayerInterfaceTable_MapObjectToBroadPhaseLayer(NativeHandle<JPH_BroadPhaseLayerInterface> @interface, ObjectLayer objectLayer, BroadPhaseLayer broadPhaseLayer)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BroadPhaseLayerInterfaceTable_MapObjectToBroadPhaseLayer(@interface, objectLayer, broadPhaseLayer);
        }
    }
}
