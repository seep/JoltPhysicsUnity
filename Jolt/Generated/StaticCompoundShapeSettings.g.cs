using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct StaticCompoundShapeSettings : IEquatable<StaticCompoundShapeSettings>
    {
        #region IEquatable
        
        public bool Equals(StaticCompoundShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is StaticCompoundShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(StaticCompoundShapeSettings lhs, StaticCompoundShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(StaticCompoundShapeSettings lhs, StaticCompoundShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => SafeBindings.JPH_ShapeSettings_Destroy(Handle);
        
        #endregion
        
        #region JPH_CompoundShapeSettings
        
        #endregion
        
        #region JPH_StaticCompoundShapeSettings
        
        #endregion
        
    }
}
