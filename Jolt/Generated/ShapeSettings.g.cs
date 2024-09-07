using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct ShapeSettings : IEquatable<ShapeSettings>
    {
        internal readonly NativeHandle<JPH_ShapeSettings> Handle;
        
        internal ShapeSettings(NativeHandle<JPH_ShapeSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(ShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ShapeSettings lhs, ShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ShapeSettings lhs, ShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle);
        
        #endregion
        
    }
}
