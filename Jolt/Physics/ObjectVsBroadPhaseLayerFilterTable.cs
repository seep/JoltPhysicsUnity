using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_ObjectVsBroadPhaseLayerFilter")]
    public readonly partial struct ObjectVsBroadPhaseLayerFilterTable
    {
        /// <summary>
        /// Implicit reinterpret cast as a base ObjectVsBroadPhaseLayerFilter.
        /// </summary>
        public static implicit operator ObjectVsBroadPhaseLayerFilter(ObjectVsBroadPhaseLayerFilterTable table)
        {
            return new ObjectVsBroadPhaseLayerFilter(table.Handle);
        }

        #region JPH_ObjectVsBroadPhaseLayerFilterTable

        public static ObjectVsBroadPhaseLayerFilterTable Create(BroadPhaseLayerInterface @interface, uint numBroadPhaseLayers, ObjectLayerPairFilter filter, uint numObjectLayers)
        {
            return new ObjectVsBroadPhaseLayerFilterTable(JPH_ObjectVsBroadPhaseLayerFilterTable_Create(@interface.Handle, numBroadPhaseLayers, filter.Handle, numObjectLayers));
        }

        #endregion
    }
}
