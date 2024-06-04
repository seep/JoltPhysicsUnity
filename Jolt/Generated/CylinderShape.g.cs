using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct CylinderShape : IEquatable<CylinderShape>
    {
        #region IEquatable
        
        public bool Equals(CylinderShape other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is CylinderShape other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(CylinderShape lhs, CylinderShape rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(CylinderShape lhs, CylinderShape rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_Shape
        
        public void Destroy() => SafeBindings.JPH_Shape_Destroy(Handle);
        
        public new ShapeType GetType() => SafeBindings.JPH_Shape_GetType(Handle);
        
        public ShapeSubType GetSubType() => SafeBindings.JPH_Shape_GetSubType(Handle);
        
        public ulong GetUserData() => SafeBindings.JPH_Shape_GetUserData(Handle);
        
        public void SetUserData(ulong userData) => SafeBindings.JPH_Shape_SetUserData(Handle, userData);
        
        public bool MustBeStatic() => SafeBindings.JPH_Shape_MustBeStatic(Handle);
        
        public float3 GetCenterOfMass() => SafeBindings.JPH_Shape_GetCenterOfMass(Handle);
        
        public AABox GetLocalBounds() => SafeBindings.JPH_Shape_GetLocalBounds(Handle);
        
        public AABox GetWorldSpaceBounds(rmatrix4x4 centerOfMassTransform, float3 scale) => SafeBindings.JPH_Shape_GetWorldSpaceBounds(Handle, centerOfMassTransform, scale);
        
        public float GetInnerRadius() => SafeBindings.JPH_Shape_GetInnerRadius(Handle);
        
        public MassProperties GetMassProperties() => SafeBindings.JPH_Shape_GetMassProperties(Handle);
        
        public float3 GetSurfaceNormal(uint subShapeID, float3 localPosition) => SafeBindings.JPH_Shape_GetSurfaceNormal(Handle, subShapeID, localPosition);
        
        public float GetVolume() => SafeBindings.JPH_Shape_GetVolume(Handle);
        
        #endregion
        
        #region JPH_ConvexShape
        
        public float GetDensity() => SafeBindings.JPH_ConvexShape_GetDensity(Handle);
        
        public void SetDensity(float density) => SafeBindings.JPH_ConvexShape_SetDensity(Handle, density);
        
        #endregion
        
        #region JPH_CylinderShape
        
        public float GetRadius() => SafeBindings.JPH_CylinderShape_GetRadius(Handle);
        
        public float GetHalfHeight() => SafeBindings.JPH_CylinderShape_GetHalfHeight(Handle);
        
        #endregion
        
    }
}
