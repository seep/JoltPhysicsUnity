using System;

namespace Jolt
{
    public readonly struct ObjectLayer : IEquatable<ObjectLayer>
    {
        /// <summary>
        /// Number of bits in an object layer.
        /// </summary>
        public const uint ObjectLayerBits = 16; // TODO can be 32 with compiler flag

        /// <summary>
        /// The invalid ObjectLayer (0).
        /// </summary>
        public static readonly ObjectLayer Invalid = 0;

        /// <summary>
        /// The layer value.
        /// </summary>
        public readonly ushort Value;

        public ObjectLayer(ushort value)
        {
            Value = value;
        }

        public static implicit operator ushort(ObjectLayer layer)
        {
            return layer.Value;
        }

        public static implicit operator ObjectLayer(ushort layer)
        {
            return new ObjectLayer(layer);
        }

        #region IEquatable

        public static bool operator ==(ObjectLayer lhs, ObjectLayer rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ObjectLayer lhs, ObjectLayer rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(ObjectLayer other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is ObjectLayer other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        #endregion
    }
}
