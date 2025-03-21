using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct TriangleShapeSettings : IEquatable<TriangleShapeSettings>
    {
        #region IEquatable
        
        public bool Equals(TriangleShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is TriangleShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(TriangleShapeSettings lhs, TriangleShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(TriangleShapeSettings lhs, TriangleShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_TriangleShapeSettings
        
        public TriangleShape CreateShape() => new TriangleShape { Handle = Bindings.JPH_TriangleShapeSettings_CreateShape(Handle) };
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        public ulong GetUserData() => Bindings.JPH_ShapeSettings_GetUserData(Handle.Reinterpret<JPH_ShapeSettings>());
        
        public void SetUserData(ulong data) => Bindings.JPH_ShapeSettings_SetUserData(Handle.Reinterpret<JPH_ShapeSettings>(), data);
        
        #endregion
        
    }
}
