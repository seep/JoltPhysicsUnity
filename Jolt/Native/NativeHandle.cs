using System;

namespace Jolt
{
    /// <summary>
    /// A handle for a native resource.
    /// </summary>
    internal struct NativeHandle : IEquatable<NativeHandle>
    {
        internal uint Index;
        internal uint Version;

        public static NativeHandle Null = new ();

        public static bool operator ==(NativeHandle lhs, NativeHandle rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(NativeHandle lhs, NativeHandle rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(NativeHandle other)
        {
            return Index == other.Index && Version == other.Version;
        }

        public override bool Equals(object obj)
        {
            return obj is NativeHandle other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Index, Version);
        }
    }

    /// <summary>
    /// Typed version of NativeHandle. The generic typing is only for development; typed and untyped handles are considered equal as long as their index and version are equal.
    /// </summary>
    internal struct NativeHandle<T> : IEquatable<NativeHandle<T>>
    {
        internal uint Index;
        internal uint Version;

        public static NativeHandle<T> Null = new ();

        public NativeHandle Untyped()
        {
            return new NativeHandle { Index = Index, Version = Version };
        }

        public readonly NativeHandle<U> Reinterpret<U>()
        {
            return new NativeHandle<U> { Index = Index, Version = Version };
        }

        public bool Equals(NativeHandle other)
        {
            return Index == other.Index && Version == other.Version;
        }

        public bool Equals(NativeHandle<T> other)
        {
            return Index == other.Index && Version == other.Version;
        }

        public override bool Equals(object obj)
        {
            return obj is NativeHandle<T> other && Equals(other);
        }

        public static bool operator ==(NativeHandle<T> lhs, NativeHandle<T> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(NativeHandle<T> lhs, NativeHandle<T> rhs)
        {
            return !lhs.Equals(rhs);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Index, Version);
        }
    }
}
