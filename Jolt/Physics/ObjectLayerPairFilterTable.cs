using System;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_ObjectLayerPairFilter")]
    public readonly partial struct ObjectLayerPairFilterTable
    {
        public static ObjectLayerPairFilterTable Create(uint numObjectLayers)
        {
            return new ObjectLayerPairFilterTable(JPH_ObjectLayerPairFilterTable_Create(numObjectLayers));
        }


        /// <summary>
        /// Implicit reinterpret cast as a base ObjectLayerPairFilter.
        /// </summary>
        public static implicit operator ObjectLayerPairFilter(ObjectLayerPairFilterTable table)
        {
            return new ObjectLayerPairFilter(table.Handle);
        }

        #region JPH_ObjectLayerPairFilterTable

        public void EnableCollision(ObjectLayer layerA, ObjectLayer layerB)
        {
            JPH_ObjectLayerPairFilterTable_EnableCollision(Handle, layerA, layerB);
        }

        public void DisableCollision(ObjectLayer layerA, ObjectLayer layerB)
        {
            JPH_ObjectLayerPairFilterTable_DisableCollision(Handle, layerA, layerB);
        }

        public bool ShouldCollide(ObjectLayer layerA, ObjectLayer layerB)
        {
            return JPH_ObjectLayerPairFilterTable_ShouldCollide(Handle, layerA, layerB);
        }

        #endregion
    }
}
