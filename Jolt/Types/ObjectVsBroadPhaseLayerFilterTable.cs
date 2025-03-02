using static Jolt.Bindings;

namespace Jolt
{
    public partial struct ObjectVsBroadPhaseLayerFilterTable
    {
        internal NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> Handle;

        public static ObjectVsBroadPhaseLayerFilterTable Create(BroadPhaseLayerInterface @interface, uint numBroadPhaseLayers, ObjectLayerPairFilter filter, uint numObjectLayers)
        {
            return new ObjectVsBroadPhaseLayerFilterTable { Handle = JPH_ObjectVsBroadPhaseLayerFilterTable_Create(@interface.Handle, numBroadPhaseLayers, filter.Handle, numObjectLayers) };
        }

    }
}
