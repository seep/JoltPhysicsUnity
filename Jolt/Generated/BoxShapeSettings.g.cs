using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct BoxShapeSettings : IEquatable<BoxShapeSettings>
    {
        #region IEquatable
        
        public bool Equals(BoxShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BoxShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BoxShapeSettings lhs, BoxShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BoxShapeSettings lhs, BoxShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => SafeBindings.JPH_ShapeSettings_Destroy(Handle);
        
        #endregion
        
        #region JPH_ConvexShapeSettings
        
        public float GetDensity() => SafeBindings.JPH_ConvexShapeSettings_GetDensity(Handle);
        
        public void SetDensity(float density) => SafeBindings.JPH_ConvexShapeSettings_SetDensity(Handle, density);
        
        #endregion
        
        #region JPH_BoxShapeSettings
        
        public BoxShape CreateShape() => new BoxShape(SafeBindings.JPH_BoxShapeSettings_CreateShape(Handle));
        
        #endregion
        
    }
}
