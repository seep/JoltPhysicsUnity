using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct ObjectVsBroadPhaseLayerFilter : IEquatable<ObjectVsBroadPhaseLayerFilter>
    {
        internal readonly NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> Handle;
        
        internal ObjectVsBroadPhaseLayerFilter(NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(ObjectVsBroadPhaseLayerFilter other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ObjectVsBroadPhaseLayerFilter other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ObjectVsBroadPhaseLayerFilter lhs, ObjectVsBroadPhaseLayerFilter rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ObjectVsBroadPhaseLayerFilter lhs, ObjectVsBroadPhaseLayerFilter rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
