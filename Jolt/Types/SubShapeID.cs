using System;

namespace Jolt
{
    public struct SubShapeID : IEquatable<SubShapeID>
    {
        public uint Value;

        #region IEquatable

        public bool Equals(SubShapeID other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is SubShapeID other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (int) Value;
        }

        public static bool operator ==(SubShapeID lhs, SubShapeID rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(SubShapeID lhs, SubShapeID rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}