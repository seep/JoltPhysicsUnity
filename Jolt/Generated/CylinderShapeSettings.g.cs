using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct CylinderShapeSettings : IEquatable<CylinderShapeSettings>
    {
        #region IEquatable
        
        public bool Equals(CylinderShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is CylinderShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(CylinderShapeSettings lhs, CylinderShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(CylinderShapeSettings lhs, CylinderShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
