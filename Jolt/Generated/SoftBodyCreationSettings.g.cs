using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct SoftBodyCreationSettings : IEquatable<SoftBodyCreationSettings>
    {
        #region IEquatable
        
        public bool Equals(SoftBodyCreationSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is SoftBodyCreationSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(SoftBodyCreationSettings lhs, SoftBodyCreationSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(SoftBodyCreationSettings lhs, SoftBodyCreationSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
