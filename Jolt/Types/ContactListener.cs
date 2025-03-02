using System;
using static Jolt.Bindings;

namespace Jolt
{
    public struct ContactListener : IEquatable<ContactListener>
    {
        internal NativeHandle<JPH_ContactListener> Handle;

        public static ContactListener Create(IContactListener delegates)
        {
            return new ContactListener { Handle = JPH_ContactListener_Create(delegates) };
        }

        public void Destroy()
        {
            JPH_ContactListener_Destroy(Handle);
        }

        #region IEquatable
        
        public bool Equals(ContactListener other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is ContactListener other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(ContactListener left, ContactListener right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ContactListener left, ContactListener right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}