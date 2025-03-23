using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct BroadPhaseQuery : IEquatable<BroadPhaseQuery>
    {
        #region IEquatable
        
        public bool Equals(BroadPhaseQuery other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BroadPhaseQuery other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BroadPhaseQuery lhs, BroadPhaseQuery rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BroadPhaseQuery lhs, BroadPhaseQuery rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_BroadPhaseQuery
        
        public bool CastRay(float3 origin, float3 direction, BroadPhaseQuery.CastRayCallback callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter) => Bindings.JPH_BroadPhaseQuery_CastRay(Handle, origin, direction, callback, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle);
        
        public bool CastRay(float3 origin, float3 direction, CollisionCollectorType collisionCollectorType, BroadPhaseQuery.CastRayCallback callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter) => Bindings.JPH_BroadPhaseQuery_CastRay(Handle, origin, direction, collisionCollectorType, callback, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle);
        
        public bool CollideAABox(AABox box, BroadPhaseQuery.CollideCallback callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter) => Bindings.JPH_BroadPhaseQuery_CollideAABox(Handle, box, callback, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle);
        
        public bool CollideSphere(float3 center, float radius, BroadPhaseQuery.CollideCallback callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter) => Bindings.JPH_BroadPhaseQuery_CollideSphere(Handle, center, radius, callback, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle);
        
        public bool CollidePoint(float3 point, BroadPhaseQuery.CollideCallback callback, BroadPhaseLayerFilter broadPhaseLayerFilter, ObjectLayerFilter objectLayerFilter) => Bindings.JPH_BroadPhaseQuery_CollidePoint(Handle, point, callback, broadPhaseLayerFilter.Handle, objectLayerFilter.Handle);
        
        #endregion
        
    }
}
