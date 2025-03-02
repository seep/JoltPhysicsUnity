namespace Jolt
{
    public partial struct ObjectVsBroadPhaseLayerFilter
    {
        internal NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> Handle;
        
        public static implicit operator ObjectVsBroadPhaseLayerFilter(ObjectVsBroadPhaseLayerFilterMask table)
        {
            return new ObjectVsBroadPhaseLayerFilter { Handle = table.Handle };
        }
        
        public static implicit operator ObjectVsBroadPhaseLayerFilter(ObjectVsBroadPhaseLayerFilterTable table)
        {
            return new ObjectVsBroadPhaseLayerFilter { Handle = table.Handle };
        }
    }
}
