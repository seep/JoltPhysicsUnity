using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct ObjectLayerPairFilterTable : IEquatable<ObjectLayerPairFilterTable>
    {
        internal readonly NativeHandle<JPH_ObjectLayerPairFilter> Handle;
        
        internal ObjectLayerPairFilterTable(NativeHandle<JPH_ObjectLayerPairFilter> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(ObjectLayerPairFilterTable other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ObjectLayerPairFilterTable other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ObjectLayerPairFilterTable lhs, ObjectLayerPairFilterTable rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ObjectLayerPairFilterTable lhs, ObjectLayerPairFilterTable rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
