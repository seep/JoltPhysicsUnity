using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct ShapeFilter : IEquatable<ShapeFilter>
    {
        #region IEquatable
        
        public bool Equals(ShapeFilter other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ShapeFilter other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ShapeFilter lhs, ShapeFilter rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ShapeFilter lhs, ShapeFilter rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
