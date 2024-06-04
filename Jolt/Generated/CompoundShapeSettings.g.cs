using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct CompoundShapeSettings : IEquatable<CompoundShapeSettings>
    {
        #region IEquatable
        
        public bool Equals(CompoundShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is CompoundShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(CompoundShapeSettings lhs, CompoundShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(CompoundShapeSettings lhs, CompoundShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => SafeBindings.JPH_ShapeSettings_Destroy(Handle);
        
        #endregion
        
        #region JPH_CompoundShapeSettings
        
        #endregion
        
    }
}
