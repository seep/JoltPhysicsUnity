using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_ObjectVsBroadPhaseLayerFilter")]
    public readonly partial struct ObjectVsBroadPhaseLayerFilterMask
    {
        /// <summary>
        /// Implicit reinterpret cast as a base ObjectVsBroadPhaseLayerFilter.
        /// </summary>
        public static implicit operator ObjectVsBroadPhaseLayerFilter(ObjectVsBroadPhaseLayerFilterMask table)
        {
            return new ObjectVsBroadPhaseLayerFilter(table.Handle);
        }

        #region JPH_ObjectVsBroadPhaseLayerFilterMask

        public static ObjectVsBroadPhaseLayerFilterMask Create(BroadPhaseLayerInterface @interface)
        {
            return new ObjectVsBroadPhaseLayerFilterMask(JPH_ObjectVsBroadPhaseLayerFilterMask_Create(@interface.Handle));
        }

        #endregion
    }
}
