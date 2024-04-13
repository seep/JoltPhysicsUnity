using System;

namespace Jolt
{
    public struct MotionProperties : IEquatable<MotionProperties>
    {
        internal NativeHandle<JPH_MotionProperties> Handle;

        internal MotionProperties(NativeHandle<JPH_MotionProperties> handle)
        {
            Handle = handle;
        }

        #region IEquatable

        public static bool operator ==(MotionProperties lhs, MotionProperties rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(MotionProperties lhs, MotionProperties rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(MotionProperties other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is MotionProperties other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
