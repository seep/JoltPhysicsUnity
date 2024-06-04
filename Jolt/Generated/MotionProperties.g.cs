using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct MotionProperties : IEquatable<MotionProperties>
    {
        #region IEquatable
        
        public bool Equals(MotionProperties other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is MotionProperties other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(MotionProperties lhs, MotionProperties rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(MotionProperties lhs, MotionProperties rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
