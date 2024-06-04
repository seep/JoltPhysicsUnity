using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct ObjectLayerPairFilter : IEquatable<ObjectLayerPairFilter>
    {
        #region IEquatable
        
        public bool Equals(ObjectLayerPairFilter other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ObjectLayerPairFilter other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ObjectLayerPairFilter lhs, ObjectLayerPairFilter rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ObjectLayerPairFilter lhs, ObjectLayerPairFilter rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
