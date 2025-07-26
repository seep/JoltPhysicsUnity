using System;
using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObjectLayer : IEquatable<ObjectLayer>
    {
        // A distinct type wrapper around uint (or optionally uint, but unsupported). See https://github.com/jrouwe/JoltPhysics/blob/master/Jolt/Physics/Collision/ObjectLayer.h

        /// <summary>
        /// Number of bits in an object layer.
        /// </summary>
        public const int Bits = 32 /*0x20*/;

        public const uint ObjectLayerInvalid = 4294967295 /*0xFFFFFFFF*/;

        /// <summary>
        /// The layer value.
        /// </summary>
        public readonly uint Value;

        public ObjectLayer(uint value)
        {
            Value = value;
        }
        public bool IsValid => this.Value != uint.MaxValue;

        public bool IsInvalid => this.Value == uint.MaxValue;

        public static ObjectLayer Invalid => new ObjectLayer(uint.MaxValue);
        /// <summary>
        /// Implicit cast from uint. The inverse is not available to avoid confusion.
        /// </summary>
        public static implicit operator ObjectLayer(uint layer)
        {
            return new ObjectLayer(layer);
        }
        
        public static implicit operator uint(ObjectLayer layer)
        {
            return layer.Value;
        }

        #region IEquatable

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

        public static bool operator ==(ObjectLayer lhs, ObjectLayer rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ObjectLayer lhs, ObjectLayer rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
