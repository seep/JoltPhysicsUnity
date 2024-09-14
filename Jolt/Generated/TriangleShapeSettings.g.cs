using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct TriangleShapeSettings : IEquatable<TriangleShapeSettings>
    {
        internal readonly NativeHandle<JPH_TriangleShapeSettings> Handle;
        
        internal TriangleShapeSettings(NativeHandle<JPH_TriangleShapeSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(TriangleShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is TriangleShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(TriangleShapeSettings lhs, TriangleShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(TriangleShapeSettings lhs, TriangleShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_TriangleShapeSettings
        
        public TriangleShape CreateShape() => new TriangleShape(Bindings.JPH_TriangleShapeSettings_CreateShape(Handle));
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        #endregion
        
    }
}
