using System;

namespace Jolt
{
    /// <summary>
    /// A uint with implicit bool casting, providing consistent interop with native "bool" uints.
    /// </summary>
    public struct NativeBool : IEquatable<NativeBool>
    {
        public byte Value;

        public static implicit operator bool(NativeBool value)
        {
            return value.Value != 0;
        }

        public static implicit operator NativeBool(bool value)
        {
            return new NativeBool { Value = value ? (byte)1 : (byte)0 };
        }

        public static bool operator false(NativeBool value) => value.Value == 0;

        public static bool operator true(NativeBool value) => value.Value != 0;

        public static bool operator ==(NativeBool lhs, NativeBool rhs) => lhs.Value == rhs.Value;

        public static bool operator !=(NativeBool lhs, NativeBool rhs) => lhs.Value != rhs.Value;

        #region IEquatable

        public bool Equals(NativeBool other) => Value == other.Value;

        public override bool Equals(object obj) => obj is NativeBool other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        #endregion
    }
}
