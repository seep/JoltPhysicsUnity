using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct StaticCompoundShapeSettings : IEquatable<StaticCompoundShapeSettings>
    {
        #region IEquatable
        
        public bool Equals(StaticCompoundShapeSettings other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is StaticCompoundShapeSettings other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(StaticCompoundShapeSettings lhs, StaticCompoundShapeSettings rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(StaticCompoundShapeSettings lhs, StaticCompoundShapeSettings rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_StaticCompoundShapeSettings
        
        #endregion
        
        #region JPH_CompoundShapeSettings
        
        public void AddShape(float3 position, quaternion rotation, ShapeSettings settings, uint userData) => Bindings.JPH_CompoundShapeSettings_AddShape(Handle.Reinterpret<JPH_CompoundShapeSettings>(), position, rotation, settings.Handle, userData);
        
        public void AddShape(float3 position, quaternion rotation, Shape shape, uint userData) => Bindings.JPH_CompoundShapeSettings_AddShape(Handle.Reinterpret<JPH_CompoundShapeSettings>(), position, rotation, shape.Handle, userData);
        
        #endregion
        
        #region JPH_ShapeSettings
        
        public void Destroy() => Bindings.JPH_ShapeSettings_Destroy(Handle.Reinterpret<JPH_ShapeSettings>());
        
        public ulong GetUserData() => Bindings.JPH_ShapeSettings_GetUserData(Handle.Reinterpret<JPH_ShapeSettings>());
        
        public void SetUserData(ulong data) => Bindings.JPH_ShapeSettings_SetUserData(Handle.Reinterpret<JPH_ShapeSettings>(), data);
        
        #endregion
        
    }
}
