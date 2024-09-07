using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct MutableCompoundShapeSettings : IEquatable<MutableCompoundShapeSettings>
    {
        internal readonly NativeHandle<JPH_MutableCompoundShapeSettings> Handle;
        
        internal MutableCompoundShapeSettings(NativeHandle<JPH_MutableCompoundShapeSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(MutableCompoundShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is MutableCompoundShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(MutableCompoundShapeSettings lhs, MutableCompoundShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(MutableCompoundShapeSettings lhs, MutableCompoundShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        #endregion
        
        #region JPH_CompoundShapeSettings
        
        #endregion
        
        #region JPH_MutableCompoundShapeSettings
        
        #endregion
        
    }
}
