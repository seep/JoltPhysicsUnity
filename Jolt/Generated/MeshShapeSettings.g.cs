using System;
using Jolt;
using Unity.Collections;
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
        
        #region JPH_MeshShapeSettings
        
        public void Sanitize() => Bindings.JPH_MeshShapeSettings_Sanitize(Handle);
        
        public MeshShape CreateShape() => new MeshShape { Handle = Bindings.JPH_MeshShapeSettings_CreateShape(Handle) };
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        public ulong GetUserData() => Bindings.JPH_ShapeSettings_GetUserData(Handle.Reinterpret<JPH_ShapeSettings>());
        
        public void SetUserData(ulong data) => Bindings.JPH_ShapeSettings_SetUserData(Handle.Reinterpret<JPH_ShapeSettings>(), data);
        
        #endregion
        
    }
}
