using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct CapsuleShapeSettings : IEquatable<CapsuleShapeSettings>
    {
        internal readonly NativeHandle<JPH_CapsuleShapeSettings> Handle;
        
        internal CapsuleShapeSettings(NativeHandle<JPH_CapsuleShapeSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(CapsuleShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is CapsuleShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(CapsuleShapeSettings lhs, CapsuleShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(CapsuleShapeSettings lhs, CapsuleShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_CapsuleShapeSettings
        
        public CapsuleShape CreateShape() => new CapsuleShape(Bindings.JPH_CapsuleShapeSettings_CreateShape(Handle));
        
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
