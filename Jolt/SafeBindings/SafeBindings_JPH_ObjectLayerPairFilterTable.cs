namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static NativeHandle<JPH_ObjectLayerPairFilter> JPH_ObjectLayerPairFilterTable_Create(uint numObjectLayers)
        {
            return CreateHandle(Bindings.JPH_ObjectLayerPairFilterTable_Create(numObjectLayers));
        }

        public static void JPH_ObjectLayerPairFilterTable_DisableCollision(NativeHandle<JPH_ObjectLayerPairFilter> filter, ObjectLayer layerA, ObjectLayer layerB)
        {
            Bindings.JPH_ObjectLayerPairFilterTable_DisableCollision(filter, layerA, layerB);
        }

        public static void JPH_ObjectLayerPairFilterTable_EnableCollision(NativeHandle<JPH_ObjectLayerPairFilter> filter, ObjectLayer layerA, ObjectLayer layerB)
        {
            Bindings.JPH_ObjectLayerPairFilterTable_EnableCollision(filter, layerA, layerB);
        }

        public static bool JPH_ObjectLayerPairFilterTable_ShouldCollide(NativeHandle<JPH_ObjectLayerPairFilter> filter, ObjectLayer layerA, ObjectLayer layerB)
        {
            return Bindings.JPH_ObjectLayerPairFilterTable_ShouldCollide(filter, layerA, layerB);
        }
    }
}
