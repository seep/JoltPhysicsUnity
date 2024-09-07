using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct CylinderShapeSettings : IEquatable<CylinderShapeSettings>
    {
        internal readonly NativeHandle<JPH_CylinderShapeSettings> Handle;
        
        internal CylinderShapeSettings(NativeHandle<JPH_CylinderShapeSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(CylinderShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is CylinderShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(CylinderShapeSettings lhs, CylinderShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(CylinderShapeSettings lhs, CylinderShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_CylinderShapeSettings
        
        #endregion
        
        #region JPH_ConvexShapeSettings
        
        public float GetDensity() => Bindings.JPH_ConvexShapeSettings_GetDensity(Handle.Reinterpret<JPH_ConvexShapeSettings>());
        
        public void SetDensity(float density) => Bindings.JPH_ConvexShapeSettings_SetDensity(Handle.Reinterpret<JPH_ConvexShapeSettings>(), density);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        #endregion
        
    }
}
