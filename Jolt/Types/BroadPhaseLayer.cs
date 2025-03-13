using System;
using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(byte))]
    public readonly struct BroadPhaseLayer : IEquatable<BroadPhaseLayer>
    {
        // A distinct type wrapper around a byte. See https://github.com/jrouwe/JoltPhysics/blob/master/Jolt/Physics/Collision/BroadPhase/BroadPhaseLayer.h

        public readonly byte Value;

        public BroadPhaseLayer(byte value)
        {
            Value = value;
        }

        /// <summary>
        /// Implicit cast from byte. The inverse is not available to avoid confusion.
        /// </summary>
        public static implicit operator BroadPhaseLayer(byte layer)
        {
            return new BroadPhaseLayer(layer);
        }

        #region IEquatable

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

        public static bool operator ==(BroadPhaseLayer lhs, BroadPhaseLayer rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(BroadPhaseLayer lhs, BroadPhaseLayer rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
