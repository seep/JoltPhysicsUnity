using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct StaticCompoundShapeSettings : IEquatable<StaticCompoundShapeSettings>
    {
        internal readonly NativeHandle<JPH_StaticCompoundShapeSettings> Handle;
        
        internal StaticCompoundShapeSettings(NativeHandle<JPH_StaticCompoundShapeSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(StaticCompoundShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is StaticCompoundShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(StaticCompoundShapeSettings lhs, StaticCompoundShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(StaticCompoundShapeSettings lhs, StaticCompoundShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        #endregion
        
        #region JPH_CompoundShapeSettings
        
        #endregion
        
        #region JPH_StaticCompoundShapeSettings
        
        #endregion
        
    }
}
