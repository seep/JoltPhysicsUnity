using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct BodyFilter : IEquatable<BodyFilter>
    {
        #region IEquatable
        
        public bool Equals(BodyFilter other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BodyFilter other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BodyFilter lhs, BodyFilter rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BodyFilter lhs, BodyFilter rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_BodyFilter
        
        public void SetProcs() => Bindings.JPH_BodyFilter_SetProcs(Handle);
        
        public void Destroy() => Bindings.JPH_BodyFilter_Destroy(Handle);
        
        #endregion
        
    }
}
