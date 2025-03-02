using static Jolt.Bindings;

namespace Jolt
{
    public partial struct ObjectLayerPairFilterTable
    {
        internal NativeHandle<JPH_ObjectLayerPairFilter> Handle;

        public static ObjectLayerPairFilterTable Create(uint numObjectLayers)
        {
            return new ObjectLayerPairFilterTable { Handle = JPH_ObjectLayerPairFilterTable_Create(numObjectLayers) };
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
