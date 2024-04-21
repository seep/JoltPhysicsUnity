using System;
using static Jolt.JoltAPI;

namespace Jolt
{
    public struct ObjectVsBroadPhaseLayerFilterMask : IEquatable<ObjectVsBroadPhaseLayerFilterMask>
    {
        internal NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> Handle;

        internal ObjectVsBroadPhaseLayerFilterMask(NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Implicit reinterpret cast as a base ObjectVsBroadPhaseLayerFilter.
        /// </summary>
        public static implicit operator ObjectVsBroadPhaseLayerFilter(ObjectVsBroadPhaseLayerFilterMask table)
        {
            return new ObjectVsBroadPhaseLayerFilter(table.Handle);
        }

        #region JPH_ObjectVsBroadPhaseLayerFilterMask

        public static ObjectVsBroadPhaseLayerFilterMask Create(BroadPhaseLayerInterface @interface)
        {
            return new ObjectVsBroadPhaseLayerFilterMask(JPH_ObjectVsBroadPhaseLayerFilterMask_Create(@interface.Handle));
        }

        #endregion

        #region IEquatable

        public static bool operator ==(ObjectVsBroadPhaseLayerFilterMask lhs, ObjectVsBroadPhaseLayerFilterMask rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ObjectVsBroadPhaseLayerFilterMask lhs, ObjectVsBroadPhaseLayerFilterMask rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(ObjectVsBroadPhaseLayerFilterMask other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is ObjectVsBroadPhaseLayerFilterMask other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
