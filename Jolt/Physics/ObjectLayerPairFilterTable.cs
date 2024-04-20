using System;
using static Jolt.JoltAPI;

namespace Jolt
{
    public struct ObjectLayerPairFilterTable : IEquatable<ObjectLayerPairFilterTable>
    {
        internal NativeHandle<JPH_ObjectLayerPairFilter> Handle;

        internal ObjectLayerPairFilterTable(NativeHandle<JPH_ObjectLayerPairFilter> handle)
        {
            Handle = handle;
        }

        public static ObjectLayerPairFilterTable Create(uint numObjectLayers)
        {
            return new ObjectLayerPairFilterTable(JPH_ObjectLayerPairFilterTable_Create(numObjectLayers));
        }

        /// <summary>
        /// Reinterpret the native handle as an ObjectLayerPairFilter.
        /// </summary>
        public ObjectLayerPairFilter AsObjectLayerPairFilter()
        {
            return new ObjectLayerPairFilter(Handle);
        }

        #region JPH_ObjectLayerPairFilterTable

        public void EnableCollision(ushort layerA, ushort layerB)
        {
            JPH_ObjectLayerPairFilterTable_EnableCollision(Handle, layerA, layerB);
        }

        public void DisableCollision(ushort layerA, ushort layerB)
        {
            JPH_ObjectLayerPairFilterTable_DisableCollision(Handle, layerA, layerB);
        }

        public bool ShouldCollide(ushort layerA, ushort layerB)
        {
            return JPH_ObjectLayerPairFilterTable_ShouldCollide(Handle, layerA, layerB);
        }

        #endregion

        #region IEquatable

        public static bool operator ==(ObjectLayerPairFilterTable lhs, ObjectLayerPairFilterTable rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ObjectLayerPairFilterTable lhs, ObjectLayerPairFilterTable rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(ObjectLayerPairFilterTable other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is ObjectLayerPairFilterTable other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
