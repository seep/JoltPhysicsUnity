using System;
using static Jolt.SafeBindings;

namespace Jolt
{
    public struct ObjectVsBroadPhaseLayerFilterTable : IEquatable<ObjectVsBroadPhaseLayerFilterTable>
    {
        internal NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> Handle;

        internal ObjectVsBroadPhaseLayerFilterTable(NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Implicit reinterpret cast as a base ObjectVsBroadPhaseLayerFilter.
        /// </summary>
        public static implicit operator ObjectVsBroadPhaseLayerFilter(ObjectVsBroadPhaseLayerFilterTable table)
        {
            return new ObjectVsBroadPhaseLayerFilter(table.Handle);
        }

        #region JPH_ObjectVsBroadPhaseLayerFilterTable

        public static ObjectVsBroadPhaseLayerFilterTable Create(BroadPhaseLayerInterface @interface, uint numBroadPhaseLayers, ObjectLayerPairFilter filter, uint numObjectLayers)
        {
            return new ObjectVsBroadPhaseLayerFilterTable(JPH_ObjectVsBroadPhaseLayerFilterTable_Create(@interface.Handle, numBroadPhaseLayers, filter.Handle, numObjectLayers));
        }

        #endregion

        #region IEquatable

        public static bool operator ==(ObjectVsBroadPhaseLayerFilterTable lhs, ObjectVsBroadPhaseLayerFilterTable rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ObjectVsBroadPhaseLayerFilterTable lhs, ObjectVsBroadPhaseLayerFilterTable rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(ObjectVsBroadPhaseLayerFilterTable other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is ObjectVsBroadPhaseLayerFilterTable other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
