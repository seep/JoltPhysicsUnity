using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct BodyActivationListener : IEquatable<BodyActivationListener>
    {
        #region IEquatable
        
        public bool Equals(BodyActivationListener other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BodyActivationListener other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BodyActivationListener lhs, BodyActivationListener rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BodyActivationListener lhs, BodyActivationListener rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_BodyActivationListener
        
        public void Destroy() => Bindings.JPH_BodyActivationListener_Destroy(Handle);
        
        #endregion
        
    }
}
