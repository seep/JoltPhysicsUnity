using System;
using static Jolt.Bindings;

namespace Jolt
{
    public struct BodyActivationListener : IEquatable<BodyActivationListener>
    {
        internal NativeHandle<JPH_BodyActivationListener> Handle;

        internal BodyActivationListener(NativeHandle<JPH_BodyActivationListener> handle)
        {
            Handle = handle;
        }
        
        public static BodyActivationListener Create(IBodyActivationListener delegates)
        {
            return new BodyActivationListener(JPH_BodyActivationListener_Create(delegates));
        }

        public void Destroy()
        {
            JPH_BodyActivationListener_Destroy(Handle);
        }

        #region IEquatable
        
        public bool Equals(BodyActivationListener other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is BodyActivationListener other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(BodyActivationListener left, BodyActivationListener right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BodyActivationListener left, BodyActivationListener right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}