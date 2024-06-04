using static Jolt.SafeBindings;

namespace Jolt
{
    /// <summary>
    /// An ObjectLayerPairFilter that uses bitmasks to test if two bodies can collide based on their object layer.
    /// </summary>
    /// <remarks>
    /// Uses group bits and mask bits. Two layers can collide if e.g. Object1.Group & Object2.Mask is non-zero and Object2.Group & Object1.Mask is non-zero.
    /// </remarks>
    [GenerateHandle, GenerateBindings("")]
    public readonly partial struct ObjectLayerPairFilterMask
    {
        /// <summary>
        /// The number of bits in a group.
        /// </summary>
        private const uint NumBits = ObjectLayer.ObjectLayerBits / 2;

        /// <summary>
        /// The mask bits.
        /// </summary>
        private const uint Mask = (1U << (int) NumBits) - 1U;

        internal readonly NativeHandle<JPH_ObjectLayerPairFilter> Handle;

        internal ObjectLayerPairFilterMask(NativeHandle<JPH_ObjectLayerPairFilter> handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Implicit reinterpret cast as a base ObjectLayerPairFilter.
        /// </summary>
        public static implicit operator ObjectLayerPairFilter(ObjectLayerPairFilterMask mask)
        {
            return new ObjectLayerPairFilter(mask.Handle);
        }

        #region JPH_ObjectLayerPairFilter

        public static ObjectLayerPairFilterMask Create()
        {
            return new ObjectLayerPairFilterMask(JPH_ObjectLayerPairFilterMask_Create());
        }

        /// <summary>
        /// Get the object layer value given a group and mask value.
        /// </summary>
        /// <remarks>
        /// The group and mask must each fit within half the corresponding ObjectLayer size. Meaning, if an ObjectLayer is 16 bits, the group and mask must be less than 8 bits.
        /// </remarks>
        public static ObjectLayer GetObjectLayer(uint group, uint mask = Mask)
        {
            // TODO maybe diverge from jolt types here, define ObjectLayerPart as a byte (or ushort if JPH_OBJECT_LAYER_BITS = 32), taking uints is misleading

            return JPH_ObjectLayerPairFilterMask_GetObjectLayer(group, mask);
        }

        /// <summary>
        /// Get the group value of an object layer.
        /// </summary>
        public static uint GetGroup(ObjectLayer layer)
        {
            return JPH_ObjectLayerPairFilterMask_GetGroup(layer);
        }

        /// <summary>
        /// Get the mask value of an object layer.
        /// </summary>
        public static uint GetMask(ObjectLayer layer)
        {
            return JPH_ObjectLayerPairFilterMask_GetMask(layer);
        }

        // TODO JPH_ObjectLayerFilterMask_ShouldCollide is missing from bindings but exists on jolt ObjectLayerFilterMask.h

        #endregion
    }
}
