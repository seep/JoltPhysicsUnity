using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct SphereShapeSettings : IEquatable<SphereShapeSettings>
    {
        #region IEquatable
        
        public bool Equals(SphereShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is SphereShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(SphereShapeSettings lhs, SphereShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(SphereShapeSettings lhs, SphereShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle);
        
        #endregion
        
        #region JPH_ConvexShapeSettings
        
        public float GetDensity() => Bindings.JPH_ConvexShapeSettings_GetDensity(Handle);
        
        public void SetDensity(float density) => Bindings.JPH_ConvexShapeSettings_SetDensity(Handle, density);
        
        #endregion
        
        #region JPH_SphereShapeSettings
        
        public float GetRadius() => Bindings.JPH_SphereShapeSettings_GetRadius(Handle);
        
        public void SetRadius(float radius) => Bindings.JPH_SphereShapeSettings_SetRadius(Handle, radius);
        
        #endregion
        
    }
}
