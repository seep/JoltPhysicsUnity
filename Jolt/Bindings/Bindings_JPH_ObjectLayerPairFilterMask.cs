namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_ObjectLayerPairFilter> JPH_ObjectLayerPairFilterMask_Create()
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_ObjectLayerPairFilterMask_Create());
        }

        public static ObjectLayer JPH_ObjectLayerPairFilterMask_GetObjectLayer(uint group, uint mask)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ObjectLayerPairFilterMask_GetObjectLayer(group, mask);
        }

        public static uint JPH_ObjectLayerPairFilterMask_GetGroup(ObjectLayer layer)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ObjectLayerPairFilterMask_GetGroup(layer);
        }

        public static uint JPH_ObjectLayerPairFilterMask_GetMask(ObjectLayer layer)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ObjectLayerPairFilterMask_GetMask(layer);
        }
    }
}
