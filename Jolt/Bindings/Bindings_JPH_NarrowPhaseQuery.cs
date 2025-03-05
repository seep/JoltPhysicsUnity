using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt
{
    public partial struct BroadPhaseQuery
    {
        /// <summary>
        /// Callback signature for CastRay.
        /// </summary>
        public delegate void CastRayCallback(ref BroadPhaseCastResult result);
        
        /// <summary>
        /// Callback signature for CollideAABox, CollideSphere, and CollidePoint.
        /// </summary>
        public delegate void CollideCallback(BodyID result);
    }
    
    internal static unsafe partial class Bindings
    {
        public static bool JPH_NarrowPhaseQuery_CastRay(
            NativeHandle<JPH_NarrowPhaseQuery> query, rvec3 origin, float3 direction, out RayCastResult hit,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter, NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter, NativeHandle<JPH_BodyFilter> bodyFilter
        )
        {
            RayCastResult result;
            
        }

        public static bool JPH_NarrowPhaseQuery_CastRay2(
            NativeHandle<JPH_NarrowPhaseQuery> query, rvec3 origin, float3 direction, NativeHandle<JPH_RayCastSettings> rayCastSettings,
            [NativeTypeName("JPH_CastRayCollectorCallback *")] IntPtr callback, void* userData,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter,
            NativeHandle<JPH_BodyFilter> bodyFilter,
            NativeHandle<JPH_ShapeFilter> shapeFilter
        ) 
        {
            
        }

        public static bool JPH_NarrowPhaseQuery_CastRay3(
            NativeHandle<JPH_NarrowPhaseQuery> query, rvec3 origin, float3 direction, NativeHandle<JPH_RayCastSettings> rayCastSettings,
            [NativeTypeName("JPH_CollisionCollectorType")] CollisionCollectorType collectorType, [NativeTypeName("JPH_CastRayResultCallback *")] IntPtr callback, void* userData,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter, NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter, NativeHandle<JPH_BodyFilter> bodyFilter, NativeHandle<JPH_ShapeFilter> shapeFilter) 
        {
            
        }

        public static bool JPH_NarrowPhaseQuery_CollidePoint(
            NativeHandle<JPH_NarrowPhaseQuery> query, rvec3 point,
            [NativeTypeName("JPH_CollidePointCollectorCallback *")] IntPtr callback, void* userData,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter,
            NativeHandle<JPH_BodyFilter> bodyFilter,
            NativeHandle<JPH_ShapeFilter> shapeFilter) 
        {
            
        }

        public static bool JPH_NarrowPhaseQuery_CollidePoint2(
            NativeHandle<JPH_NarrowPhaseQuery> query, rvec3 point, [NativeTypeName("JPH_CollisionCollectorType")] CollisionCollectorType collectorType,
            [NativeTypeName("JPH_CollidePointResultCallback *")] IntPtr callback, void* userData,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter,
            NativeHandle<JPH_BodyFilter> bodyFilter,
            NativeHandle<JPH_ShapeFilter> shapeFilter
        ) 
        {
            
        }

        public static bool JPH_NarrowPhaseQuery_CollideShape(
            NativeHandle<JPH_NarrowPhaseQuery> query, NativeHandle<JPH_Shape> shape, float3 scale, rmatrix4x4 centerOfMassTransform,
            [NativeTypeName("const JPH_CollideShapeSettings *")] JPH_CollideShapeSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* baseOffset,
            [NativeTypeName("JPH_CollideShapeCollectorCallback *")] IntPtr callback, void* userData,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter,
            NativeHandle<JPH_BodyFilter> bodyFilter,
            NativeHandle<JPH_ShapeFilter> shapeFilter
        ) 
        {
            
        }

        public static bool JPH_NarrowPhaseQuery_CollideShape2(
            NativeHandle<JPH_NarrowPhaseQuery> query,
            NativeHandle<JPH_Shape> shape,
            in float3 scale,
            in rmatrix4x4 centerOfMassTransform,
            in CollideShapeSettings settings,
            in rvec3 baseOffset,
            [NativeTypeName("JPH_CollisionCollectorType")] CollisionCollectorType collectorType,
            [NativeTypeName("JPH_CollideShapeResultCallback *")] IntPtr callback, void* userData,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter,
            NativeHandle<JPH_BodyFilter> bodyFilter,
            NativeHandle<JPH_ShapeFilter> shapeFilter
        )
        {
            
        }

        public static bool JPH_NarrowPhaseQuery_CastShape(
            NativeHandle<JPH_NarrowPhaseQuery> query,
            NativeHandle<JPH_Shape> shape,
            in rmatrix4x4 worldTransform,
            in float3 direction,
            JPH_ShapeCastSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* baseOffset, [NativeTypeName("JPH_CastShapeCollectorCallback *")] IntPtr callback, void* userData, NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter, NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter, NativeHandle<JPH_BodyFilter> bodyFilter, NativeHandle<JPH_ShapeFilter> shapeFilter) 
        {
            
        }

        public static bool JPH_NarrowPhaseQuery_CastShape2(NativeHandle<JPH_NarrowPhaseQuery> query, NativeHandle<JPH_Shape> shape, [NativeTypeName("const JPH_RMatrix4x4 *")] rmatrix4x4* worldTransform, [NativeTypeName("const JPH_Vec3 *")] float3* direction, [NativeTypeName("const JPH_ShapeCastSettings *")] JPH_ShapeCastSettings* settings, [NativeTypeName("JPH_RVec3 *")] rvec3* baseOffset, [NativeTypeName("JPH_CollisionCollectorType")] CollisionCollectorType collectorType, [NativeTypeName("JPH_CastShapeResultCallback *")] IntPtr callback, void* userData, NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter, NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter, NativeHandle<JPH_BodyFilter> bodyFilter, NativeHandle<JPH_ShapeFilter> shapeFilter) 
        {
            
        }
    }

    /// <summary>
    /// Static function pointers for JPH_BroadPhaseQuery queries; the individual callback pointers are passed via the user data.
    /// </summary>
    internal static unsafe class BroadPhaseQueryHandlers
    {
        private delegate void UnsafeCastRayDelegate(nint udata, BroadPhaseCastResult* result);
        private delegate void UnsafeCollideDelegate(nint udata, BodyID result);

        public static nint UnsafeCastRayCallbackPointer;
        public static nint UnsafeCollideCallbackPointer;
        
        static BroadPhaseQueryHandlers()
        {
            UnsafeCastRayCallbackPointer = Marshal.GetFunctionPointerForDelegate(
                (UnsafeCastRayDelegate)UnsafeCastRayCallback
            );
            
            UnsafeCollideCallbackPointer = Marshal.GetFunctionPointerForDelegate(
                (UnsafeCollideDelegate)UnsafeCollideCallback
            );
        }
        
        private static void UnsafeCastRayCallback(nint udata, BroadPhaseCastResult* result)
        {
            try
            {
                Marshal.GetDelegateForFunctionPointer<BroadPhaseQuery.CastRayCallback>(udata).Invoke(ref UnsafeUtility.AsRef<BroadPhaseCastResult>(result));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private static void UnsafeCollideCallback(nint udata, BodyID result)
        {
            try
            {
                Marshal.GetDelegateForFunctionPointer<BroadPhaseQuery.CollideCallback>(udata).Invoke(result);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
