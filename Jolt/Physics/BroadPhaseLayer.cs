using System;

namespace Jolt
{
    public struct BroadPhaseLayer : IEquatable<BroadPhaseLayer>
    {
        public readonly byte Value;

        public BroadPhaseLayer(byte value)
        {
            Value = value;
        }

        public static implicit operator byte(BroadPhaseLayer layer)
        {
            return layer.Value;
        }

        public static implicit operator BroadPhaseLayer(byte layer)
        {
            return new BroadPhaseLayer(layer);
        }

        #region IEquatable

        public static bool operator ==(BroadPhaseLayer lhs, BroadPhaseLayer rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(BroadPhaseLayer lhs, BroadPhaseLayer rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(BroadPhaseLayer other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is BroadPhaseLayer other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        #endregion
    }
}
