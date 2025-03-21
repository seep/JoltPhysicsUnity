using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct PlaneShapeSettings : IEquatable<PlaneShapeSettings>
    {
        #region IEquatable
        
        public bool Equals(PlaneShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is PlaneShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(PlaneShapeSettings lhs, PlaneShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(PlaneShapeSettings lhs, PlaneShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_PlaneShapeSettings
        
        public PlaneShape CreateShape() => new PlaneShape { Handle = Bindings.JPH_PlaneShapeSettings_CreateShape(Handle) };
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        public ulong GetUserData() => Bindings.JPH_ShapeSettings_GetUserData(Handle.Reinterpret<JPH_ShapeSettings>());
        
        public void SetUserData(ulong data) => Bindings.JPH_ShapeSettings_SetUserData(Handle.Reinterpret<JPH_ShapeSettings>(), data);
        
        #endregion
        
    }
}
