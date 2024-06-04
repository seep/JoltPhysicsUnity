using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct PhysicsSystem : IEquatable<PhysicsSystem>
    {
        #region IEquatable
        
        public bool Equals(PhysicsSystem other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is PhysicsSystem other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(PhysicsSystem lhs, PhysicsSystem rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(PhysicsSystem lhs, PhysicsSystem rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
