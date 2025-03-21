using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct ObjectLayerPairFilterMask : IEquatable<ObjectLayerPairFilterMask>
    {
        #region IEquatable
        
        public bool Equals(ObjectLayerPairFilterMask other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ObjectLayerPairFilterMask other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ObjectLayerPairFilterMask lhs, ObjectLayerPairFilterMask rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ObjectLayerPairFilterMask lhs, ObjectLayerPairFilterMask rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
