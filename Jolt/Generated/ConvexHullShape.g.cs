using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct ConvexHullShape : IEquatable<ConvexHullShape>
    {
        #region IEquatable
        
        public bool Equals(ConvexHullShape other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is ConvexHullShape other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(ConvexHullShape lhs, ConvexHullShape rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(ConvexHullShape lhs, ConvexHullShape rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_ConvexHullShape
        
        public uint GetNumPoints() => Bindings.JPH_ConvexHullShape_GetNumPoints(Handle);
        
        public float3 GetPoint(uint index) => Bindings.JPH_ConvexHullShape_GetPoint(Handle, index);
        
        public uint GetNumFaces() => Bindings.JPH_ConvexHullShape_GetNumFaces(Handle);
        
        public uint GetNumVerticesInFace(uint faceIndex) => Bindings.JPH_ConvexHullShape_GetNumVerticesInFace(Handle, faceIndex);
        
        public uint GetFaceVertices(uint faceIndex, NativeArray<uint> vertices) => Bindings.JPH_ConvexHullShape_GetFaceVertices(Handle, faceIndex, vertices);
        
        #endregion
        
        #region JPH_ConvexShape
        
        public float GetDensity() => Bindings.JPH_ConvexShape_GetDensity(Handle.Reinterpret<JPH_ConvexShape>());
        
        public void SetDensity(float density) => Bindings.JPH_ConvexShape_SetDensity(Handle.Reinterpret<JPH_ConvexShape>(), density);
        
        #endregion
        
        #region JPH_Shape
        
        public void Destroy() => Bindings.JPH_Shape_Destroy(Handle.Reinterpret<JPH_Shape>());
        
        public ShapeType GetShapeType() => Bindings.JPH_Shape_GetType(Handle.Reinterpret<JPH_Shape>());
        
        public ShapeSubType GetSubType() => Bindings.JPH_Shape_GetSubType(Handle.Reinterpret<JPH_Shape>());
        
        public ulong GetUserData() => Bindings.JPH_Shape_GetUserData(Handle.Reinterpret<JPH_Shape>());
        
        public void SetUserData(ulong userData) => Bindings.JPH_Shape_SetUserData(Handle.Reinterpret<JPH_Shape>(), userData);
        
        public bool MustBeStatic() => Bindings.JPH_Shape_MustBeStatic(Handle.Reinterpret<JPH_Shape>());
        
        public float3 GetCenterOfMass() => Bindings.JPH_Shape_GetCenterOfMass(Handle.Reinterpret<JPH_Shape>());
        
        public AABox GetLocalBounds() => Bindings.JPH_Shape_GetLocalBounds(Handle.Reinterpret<JPH_Shape>());
        
        public uint GetSubShapeIDBitsRecursive() => Bindings.JPH_Shape_GetSubShapeIDBitsRecursive(Handle.Reinterpret<JPH_Shape>());
        
        public AABox GetWorldSpaceBounds(rmatrix4x4 centerOfMassTransform, float3 scale) => Bindings.JPH_Shape_GetWorldSpaceBounds(Handle.Reinterpret<JPH_Shape>(), centerOfMassTransform, scale);
        
        public float GetInnerRadius() => Bindings.JPH_Shape_GetInnerRadius(Handle.Reinterpret<JPH_Shape>());
        
        public MassProperties GetMassProperties() => Bindings.JPH_Shape_GetMassProperties(Handle.Reinterpret<JPH_Shape>());
        
        public PhysicsMaterial GetMaterial(SubShapeID subShapeID) => new PhysicsMaterial { Handle = Bindings.JPH_Shape_GetMaterial(Handle.Reinterpret<JPH_Shape>(), subShapeID) };
        
        public float3 GetSurfaceNormal(SubShapeID subShapeID, float3 localPosition) => Bindings.JPH_Shape_GetSurfaceNormal(Handle.Reinterpret<JPH_Shape>(), subShapeID, localPosition);
        
        public float GetVolume() => Bindings.JPH_Shape_GetVolume(Handle.Reinterpret<JPH_Shape>());
        
        public bool IsValidScale(float3 scale) => Bindings.JPH_Shape_IsValidScale(Handle.Reinterpret<JPH_Shape>(), scale);
        
        public float3 MakeScaleValid(float3 scale) => Bindings.JPH_Shape_MakeScaleValid(Handle.Reinterpret<JPH_Shape>(), scale);
        
        public Shape ScaleShape(float3 scale) => new Shape { Handle = Bindings.JPH_Shape_ScaleShape(Handle.Reinterpret<JPH_Shape>(), scale) };
        
        public bool CastRay(float3 origin, float3 direction, out RayCastResult result) => Bindings.JPH_Shape_CastRay(Handle.Reinterpret<JPH_Shape>(), origin, direction, out result);
        
        #endregion
        
    }
}
