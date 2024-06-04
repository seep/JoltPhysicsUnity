using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct ConstraintSettings : IEquatable<ConstraintSettings>
    {
        #region IEquatable
        
        public bool Equals(ConstraintSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ConstraintSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ConstraintSettings lhs, ConstraintSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ConstraintSettings lhs, ConstraintSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
