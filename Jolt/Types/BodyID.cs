using System;
using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(uint))]
    public struct BodyID : IEquatable<BodyID>
    {
        public uint Value;

        #region IEquatable

        public bool Equals(BodyID other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is BodyID other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (int) Value;
        }

        public static bool operator ==(BodyID lhs, BodyID rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(BodyID lhs, BodyID rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
