namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static NativeHandle<JPH_ObjectLayerPairFilter> JPH_ObjectLayerPairFilterMask_Create()
        {
            return CreateHandle(Bindings.JPH_ObjectLayerPairFilterMask_Create());
        }

        public static ObjectLayer JPH_ObjectLayerPairFilterMask_GetObjectLayer(uint group, uint mask)
        {
            return Bindings.JPH_ObjectLayerPairFilterMask_GetObjectLayer(group, mask);
        }

        public static uint JPH_ObjectLayerPairFilterMask_GetGroup(ObjectLayer layer)
        {
            return Bindings.JPH_ObjectLayerPairFilterMask_GetGroup(layer);
        }

        public static uint JPH_ObjectLayerPairFilterMask_GetMask(ObjectLayer layer)
        {
            return Bindings.JPH_ObjectLayerPairFilterMask_GetMask(layer);
        }
    }
}
