﻿using static Jolt.Bindings;

namespace Jolt
{
    /// <summary>
    /// An ObjectLayerPairFilter that uses bitmasks to test if two bodies can collide based on their object layer.
    /// </summary>
    /// <remarks>
    /// Uses group bits and mask bits. Two layers can collide if e.g. Object1.Group & Object2.Mask is non-zero and Object2.Group & Object1.Mask is non-zero.
    /// </remarks>
    [GenerateHandle("JPH_ObjectLayerPairFilter"), GenerateBindings("JPH_ObjectLayerPairFilter")]
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

        /// <summary>
        /// Implicit reinterpret cast as a base ObjectLayerPairFilter.
        /// </summary>
        public static implicit operator ObjectLayerPairFilter(ObjectLayerPairFilterMask mask)
        {
            return new ObjectLayerPairFilter(mask.Handle);
        }

        [OverrideBinding("JPH_ObjectLayerPairFilter")]
        public static ObjectLayerPairFilterMask Create()
        {
            return new ObjectLayerPairFilterMask(JPH_ObjectLayerPairFilterMask_Create());
        }

        // TODO JPH_ObjectLayerFilterMask_ShouldCollide is missing from bindings but exists on jolt ObjectLayerFilterMask.h
    }
}
