using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct ObjectLayerPairFilterMask : IEquatable<ObjectLayerPairFilterMask>
    {
        internal readonly NativeHandle<JPH_ObjectLayerPairFilter> Handle;
        
        internal ObjectLayerPairFilterMask(NativeHandle<JPH_ObjectLayerPairFilter> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(ObjectLayerPairFilterMask other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ObjectLayerPairFilterMask other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ObjectLayerPairFilterMask lhs, ObjectLayerPairFilterMask rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ObjectLayerPairFilterMask lhs, ObjectLayerPairFilterMask rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
