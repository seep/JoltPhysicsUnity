using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct NarrowPhaseQuery : IEquatable<NarrowPhaseQuery>
    {
        #region IEquatable
        
        public bool Equals(NarrowPhaseQuery other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is NarrowPhaseQuery other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(NarrowPhaseQuery lhs, NarrowPhaseQuery rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(NarrowPhaseQuery lhs, NarrowPhaseQuery rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_NarrowPhaseQuery
        
        public bool CastRay(rvec3 origin, float3 direction, out RayCastResult hit, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter) => Bindings.JPH_NarrowPhaseQuery_CastRay(Handle, origin, direction, out hit, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle);
        
        public bool CastRay(rvec3 origin, float3 direction, RayCastSettings settings, NativeList<RayCastResult> results, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter, ShapeFilter shapeFilter) => Bindings.JPH_NarrowPhaseQuery_CastRay(Handle, origin, direction, settings, results, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle, shapeFilter.Handle);
        
        public bool CastRay(rvec3 origin, float3 direction, RayCastSettings settings, CollisionCollectorType collector, NativeList<RayCastResult> results, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter, ShapeFilter shapeFilter) => Bindings.JPH_NarrowPhaseQuery_CastRay(Handle, origin, direction, settings, collector, results, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle, shapeFilter.Handle);
        
        public bool CollidePoint(rvec3 point, NativeList<CollidePointResult> results, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter, ShapeFilter shapeFilter) => Bindings.JPH_NarrowPhaseQuery_CollidePoint(Handle, point, results, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle, shapeFilter.Handle);
        
        public bool CollidePoint2(rvec3 point, CollisionCollectorType collector, NativeList<CollidePointResult> results, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter, ShapeFilter shapeFilter) => Bindings.JPH_NarrowPhaseQuery_CollidePoint2(Handle, point, collector, results, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle, shapeFilter.Handle);
        
        public bool CollideShape(Shape shape, float3 scale, rmatrix4x4 com, CollideShapeSettings settings, rvec3 offset, NativeList<CollideShapeResult> results, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter, ShapeFilter shapeFilter) => Bindings.JPH_NarrowPhaseQuery_CollideShape(Handle, shape.Handle, scale, com, settings, offset, results, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle, shapeFilter.Handle);
        
        public bool CollideShape(Shape shape, float3 scale, rmatrix4x4 com, CollideShapeSettings settings, rvec3 offset, CollisionCollectorType collector, NativeList<CollideShapeResult> results, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter, ShapeFilter shapeFilter) => Bindings.JPH_NarrowPhaseQuery_CollideShape(Handle, shape.Handle, scale, com, settings, offset, collector, results, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle, shapeFilter.Handle);
        
        public bool CastShape(Shape shape, rmatrix4x4 worldTransform, float3 direction, ShapeCastSettings settings, rvec3 baseOffset, NativeList<CollideShapeResult> results, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter, ShapeFilter shapeFilter) => Bindings.JPH_NarrowPhaseQuery_CastShape(Handle, shape.Handle, worldTransform, direction, settings, baseOffset, results, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle, shapeFilter.Handle);
        
        public bool CastShape(Shape shape, rmatrix4x4 worldTransform, float3 direction, ShapeCastSettings settings, rvec3 baseOffset, CollisionCollectorType collector, NativeList<CollideShapeResult> results, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter, BodyFilter bodyFilter, ShapeFilter shapeFilter) => Bindings.JPH_NarrowPhaseQuery_CastShape(Handle, shape.Handle, worldTransform, direction, settings, baseOffset, collector, results, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle, bodyFilter.Handle, shapeFilter.Handle);
        
        #endregion
        
    }
}
