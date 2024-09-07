using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct CompoundShapeSettings : IEquatable<CompoundShapeSettings>
    {
        internal readonly NativeHandle<JPH_CompoundShapeSettings> Handle;
        
        internal CompoundShapeSettings(NativeHandle<JPH_CompoundShapeSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(CompoundShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is CompoundShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(CompoundShapeSettings lhs, CompoundShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(CompoundShapeSettings lhs, CompoundShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        #endregion
        
        #region JPH_CompoundShapeSettings
        
        #endregion
        
    }
}
