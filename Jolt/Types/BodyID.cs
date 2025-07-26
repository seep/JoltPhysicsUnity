using System;
using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(uint))]
    public struct BodyID : IEquatable<BodyID>
    {
        /// <summary>
        /// The value for an invalid body ID
        /// </summary>
        public const uint InvalidBodyID = 0xffffffff;
        
        public uint Value;

        public uint ID => Value;

        public BodyID(uint value)
        {
            Value = value;
        }
        
        public static implicit operator uint(BodyID id)
        {
            return id.Value;
        }

        public static implicit operator BodyID(uint id)
        {
            return new BodyID { Value = id };
        }

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
