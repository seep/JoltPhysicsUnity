using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct BroadPhaseLayerFilter : IEquatable<BroadPhaseLayerFilter>
    {
        #region IEquatable
        
        public bool Equals(BroadPhaseLayerFilter other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BroadPhaseLayerFilter other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BroadPhaseLayerFilter lhs, BroadPhaseLayerFilter rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BroadPhaseLayerFilter lhs, BroadPhaseLayerFilter rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_BroadPhaseLayerFilter
        
        public void SetProcs() => Bindings.JPH_BroadPhaseLayerFilter_SetProcs(Handle);
        
        public void Destroy() => Bindings.JPH_BroadPhaseLayerFilter_Destroy(Handle);
        
        #endregion
        
    }
}
