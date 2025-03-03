using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct NarrowPhaseQuery : IEquatable<NarrowPhaseQuery>
    {
        #region IEquatable
        
        public bool Equals(NarrowPhaseQuery other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is NarrowPhaseQuery other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(NarrowPhaseQuery lhs, NarrowPhaseQuery rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(NarrowPhaseQuery lhs, NarrowPhaseQuery rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
