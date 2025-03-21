using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct ContactListener : IEquatable<ContactListener>
    {
        #region IEquatable
        
        public bool Equals(ContactListener other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ContactListener other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ContactListener lhs, ContactListener rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ContactListener lhs, ContactListener rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ContactListener
        
        public void Destroy() => Bindings.JPH_ContactListener_Destroy(Handle);
        
        #endregion
        
    }
}
