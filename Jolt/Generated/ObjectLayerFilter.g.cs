using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct ObjectLayerFilter : IEquatable<ObjectLayerFilter>
    {
        #region IEquatable
        
        public bool Equals(ObjectLayerFilter other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ObjectLayerFilter other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ObjectLayerFilter lhs, ObjectLayerFilter rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ObjectLayerFilter lhs, ObjectLayerFilter rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ObjectLayerFilter
        
        public void SetProcs() => Bindings.JPH_ObjectLayerFilter_SetProcs(Handle);
        
        public void Destroy() => Bindings.JPH_ObjectLayerFilter_Destroy(Handle);
        
        #endregion
        
    }
}
