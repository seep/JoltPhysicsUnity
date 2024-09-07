using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct BoxShapeSettings : IEquatable<BoxShapeSettings>
    {
        internal readonly NativeHandle<JPH_BoxShapeSettings> Handle;
        
        internal BoxShapeSettings(NativeHandle<JPH_BoxShapeSettings> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(BoxShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BoxShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BoxShapeSettings lhs, BoxShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BoxShapeSettings lhs, BoxShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_BoxShapeSettings
        
        public BoxShape CreateShape() => new BoxShape(Bindings.JPH_BoxShapeSettings_CreateShape(Handle));
        
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
