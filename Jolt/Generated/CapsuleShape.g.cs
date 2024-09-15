using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct CapsuleShape : IEquatable<CapsuleShape>
    {
        internal readonly NativeHandle<JPH_CapsuleShape> Handle;
        
        internal CapsuleShape(NativeHandle<JPH_CapsuleShape> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(CapsuleShape other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is CapsuleShape other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(CapsuleShape lhs, CapsuleShape rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(CapsuleShape lhs, CapsuleShape rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_CapsuleShape
        
        public float GetRadius() => Bindings.JPH_CapsuleShape_GetRadius(Handle);
        
        public float GetHalfHeightOfCylinder() => Bindings.JPH_CapsuleShape_GetHalfHeightOfCylinder(Handle);
        
        #endregion
        
        #region JPH_ConvexShape
        
        public float GetDensity() => Bindings.JPH_ConvexShape_GetDensity(Handle.Reinterpret<JPH_ConvexShape>());
        
        public void SetDensity(float density) => Bindings.JPH_ConvexShape_SetDensity(Handle.Reinterpret<JPH_ConvexShape>(), density);
        
        #endregion
        
        #region JPH_Shape
        
        public void Destroy() => Bindings.JPH_Shape_Destroy(Handle.Reinterpret<JPH_Shape>());
        
        public new ShapeType GetType() => Bindings.JPH_Shape_GetType(Handle.Reinterpret<JPH_Shape>());
        
        public ShapeSubType GetSubType() => Bindings.JPH_Shape_GetSubType(Handle.Reinterpret<JPH_Shape>());
        
        public ulong GetUserData() => Bindings.JPH_Shape_GetUserData(Handle.Reinterpret<JPH_Shape>());
        
        public void SetUserData(ulong userData) => Bindings.JPH_Shape_SetUserData(Handle.Reinterpret<JPH_Shape>(), userData);
        
        public bool MustBeStatic() => Bindings.JPH_Shape_MustBeStatic(Handle.Reinterpret<JPH_Shape>());
        
        public float3 GetCenterOfMass() => Bindings.JPH_Shape_GetCenterOfMass(Handle.Reinterpret<JPH_Shape>());
        
        public AABox GetLocalBounds() => Bindings.JPH_Shape_GetLocalBounds(Handle.Reinterpret<JPH_Shape>());
        
        public AABox GetWorldSpaceBounds(rmatrix4x4 centerOfMassTransform, float3 scale) => Bindings.JPH_Shape_GetWorldSpaceBounds(Handle.Reinterpret<JPH_Shape>(), centerOfMassTransform, scale);
        
        public float GetInnerRadius() => Bindings.JPH_Shape_GetInnerRadius(Handle.Reinterpret<JPH_Shape>());
        
        public MassProperties GetMassProperties() => Bindings.JPH_Shape_GetMassProperties(Handle.Reinterpret<JPH_Shape>());
        
        public float3 GetSurfaceNormal(SubShapeID subShapeID, float3 localPosition) => Bindings.JPH_Shape_GetSurfaceNormal(Handle.Reinterpret<JPH_Shape>(), subShapeID, localPosition);
        
        public float GetVolume() => Bindings.JPH_Shape_GetVolume(Handle.Reinterpret<JPH_Shape>());
        
        public bool CastRay(float3 origin, float3 direction, out RayCastResult result) => Bindings.JPH_Shape_CastRay(Handle.Reinterpret<JPH_Shape>(), origin, direction, out result);
        
        public bool CollidePoint(float3 point) => Bindings.JPH_Shape_CollidePoint(Handle.Reinterpret<JPH_Shape>(), point);
        
        #endregion
        
    }
}
