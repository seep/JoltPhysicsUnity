using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct BodyLockInterface : IEquatable<BodyLockInterface>
    {
        #region IEquatable
        
        public bool Equals(BodyLockInterface other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BodyLockInterface other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BodyLockInterface lhs, BodyLockInterface rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BodyLockInterface lhs, BodyLockInterface rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
