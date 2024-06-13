using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct FixedConstraint : IEquatable<FixedConstraint>
    {
        #region IEquatable
        
        public bool Equals(FixedConstraint other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is FixedConstraint other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(FixedConstraint lhs, FixedConstraint rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(FixedConstraint lhs, FixedConstraint rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_FixedConstraint
        
        public float3 GetTotalLambdaPosition() => Bindings.JPH_FixedConstraint_GetTotalLambdaPosition(Handle);
        
        public float3 GetTotalLambdaRotation() => Bindings.JPH_FixedConstraint_GetTotalLambdaRotation(Handle);
        
        #endregion
        
    }
}
