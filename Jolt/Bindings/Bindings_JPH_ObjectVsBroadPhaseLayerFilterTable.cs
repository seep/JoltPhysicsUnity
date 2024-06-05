namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> JPH_ObjectVsBroadPhaseLayerFilterTable_Create(NativeHandle<JPH_BroadPhaseLayerInterface> @interface, uint numBroadPhaseLayers, NativeHandle<JPH_ObjectLayerPairFilter> filter, uint numObjectLayers)
        {
            return CreateHandle(UnsafeBindings.JPH_ObjectVsBroadPhaseLayerFilterTable_Create(@interface, numBroadPhaseLayers, filter, numObjectLayers));
        }
    }
}
