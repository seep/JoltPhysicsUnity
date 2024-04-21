using System;

namespace Jolt
{
    public struct BroadPhaseLayerInterface : IEquatable<BroadPhaseLayerInterface>
    {
        internal NativeHandle<JPH_BroadPhaseLayerInterface> Handle;

        internal BroadPhaseLayerInterface(NativeHandle<JPH_BroadPhaseLayerInterface> handle)
        {
            Handle = handle;
        }

        #region IEquatable

        public static bool operator ==(BroadPhaseLayerInterface lhs, BroadPhaseLayerInterface rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(BroadPhaseLayerInterface lhs, BroadPhaseLayerInterface rhs)
        {
            return !lhs.Equals(rhs);
        }
        public bool Equals(BroadPhaseLayerInterface other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is BroadPhaseLayerInterface other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
