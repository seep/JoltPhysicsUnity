namespace Jolt
{
    public partial struct ObjectLayerPairFilter
    {
        internal NativeHandle<JPH_ObjectLayerPairFilter> Handle;

        public static implicit operator ObjectLayerPairFilter(ObjectLayerPairFilterMask mask)
        {
            return new ObjectLayerPairFilter { Handle = mask.Handle };
        }
        
        public static implicit operator ObjectLayerPairFilter(ObjectLayerPairFilterTable table)
        {
            return new ObjectLayerPairFilter { Handle = table.Handle };
        }
    }
}
