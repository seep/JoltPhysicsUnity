using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct MeshShapeSettings : IEquatable<MeshShapeSettings>
    {
        #region IEquatable
        
        public bool Equals(MeshShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is MeshShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(MeshShapeSettings lhs, MeshShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(MeshShapeSettings lhs, MeshShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => SafeBindings.JPH_ShapeSettings_Destroy(Handle);
        
        #endregion
        
        #region JPH_MeshShapeSettings
        
        public void Sanitize() => SafeBindings.JPH_MeshShapeSettings_Sanitize(Handle);
        
        #endregion
        
    }
}
