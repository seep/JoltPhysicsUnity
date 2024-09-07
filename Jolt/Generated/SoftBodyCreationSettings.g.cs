using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct SoftBodyCreationSettings : IEquatable<SoftBodyCreationSettings>
    {
        internal readonly NativeHandle<JPH_SoftBodyCreationSettings> Handle;
        
        internal SoftBodyCreationSettings(NativeHandle<JPH_SoftBodyCreationSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(SoftBodyCreationSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is SoftBodyCreationSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(SoftBodyCreationSettings lhs, SoftBodyCreationSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(SoftBodyCreationSettings lhs, SoftBodyCreationSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
