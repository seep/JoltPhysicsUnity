namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> JPH_ObjectVsBroadPhaseLayerFilterTable_Create(NativeHandle<JPH_BroadPhaseLayerInterface> @interface, uint numBroadPhaseLayers, NativeHandle<JPH_ObjectLayerPairFilter> filter, uint numObjectLayers)
        {
            return CreateHandle(Bindings.JPH_ObjectVsBroadPhaseLayerFilterTable_Create(GetPointer(@interface), numBroadPhaseLayers, GetPointer(filter), numObjectLayers));
        }
    }
}
