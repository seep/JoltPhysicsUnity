using System;
using static Jolt.JoltAPI;

namespace Jolt
{
    public struct ObjectLayerPairFilter : IEquatable<ObjectLayerPairFilter>
    {
        internal NativeHandle<JPH_ObjectLayerPairFilter> Handle;

        internal ObjectLayerPairFilter(NativeHandle<JPH_ObjectLayerPairFilter> handle)
        {
            Handle = handle;
        }

        #region IEquatable

        public bool Equals(ObjectLayerPairFilter other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is ObjectLayerPairFilter other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
