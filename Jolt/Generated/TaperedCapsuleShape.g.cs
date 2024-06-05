using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct TaperedCapsuleShape : IEquatable<TaperedCapsuleShape>
    {
        #region IEquatable
        
        public bool Equals(TaperedCapsuleShape other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is TaperedCapsuleShape other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(TaperedCapsuleShape lhs, TaperedCapsuleShape rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(TaperedCapsuleShape lhs, TaperedCapsuleShape rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_Shape
        
        public void Destroy() => Bindings.JPH_Shape_Destroy(Handle);
        
        public new ShapeType GetType() => Bindings.JPH_Shape_GetType(Handle);
        
        public ShapeSubType GetSubType() => Bindings.JPH_Shape_GetSubType(Handle);
        
        public ulong GetUserData() => Bindings.JPH_Shape_GetUserData(Handle);
        
        public void SetUserData(ulong userData) => Bindings.JPH_Shape_SetUserData(Handle, userData);
        
        public bool MustBeStatic() => Bindings.JPH_Shape_MustBeStatic(Handle);
        
        public float3 GetCenterOfMass() => Bindings.JPH_Shape_GetCenterOfMass(Handle);
        
        public AABox GetLocalBounds() => Bindings.JPH_Shape_GetLocalBounds(Handle);
        
        public AABox GetWorldSpaceBounds(rmatrix4x4 centerOfMassTransform, float3 scale) => Bindings.JPH_Shape_GetWorldSpaceBounds(Handle, centerOfMassTransform, scale);
        
        public float GetInnerRadius() => Bindings.JPH_Shape_GetInnerRadius(Handle);
        
        public MassProperties GetMassProperties() => Bindings.JPH_Shape_GetMassProperties(Handle);
        
        public float3 GetSurfaceNormal(uint subShapeID, float3 localPosition) => Bindings.JPH_Shape_GetSurfaceNormal(Handle, subShapeID, localPosition);
        
        public float GetVolume() => Bindings.JPH_Shape_GetVolume(Handle);
        
        #endregion
        
        #region JPH_ConvexShape
        
        public float GetDensity() => Bindings.JPH_ConvexShape_GetDensity(Handle);
        
        public void SetDensity(float density) => Bindings.JPH_ConvexShape_SetDensity(Handle, density);
        
        #endregion
        
    }
}
