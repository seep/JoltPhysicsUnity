using System;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt
{
    public partial struct NarrowPhaseQuery
    {
        /// <summary>
        /// Callback signature for CastRay.
        /// </summary>
        public delegate void CastRayCallback(ref RayCastResult result);

        /// <summary>
        /// Callback signature for ...
        /// </summary>
        public delegate void CollidePointCallback(ref CollidePointResult result);

        /// <summary>
        /// Callback signature for ...
        /// </summary>
        public delegate void CollideShapeCallback(ref CollideShapeResult result);
    }

    internal static unsafe partial class Bindings
    {
        public static bool JPH_NarrowPhaseQuery_CastRay(
            NativeHandle<JPH_NarrowPhaseQuery> query,
            // query parameters
            rvec3 origin, float3 direction,
            // result
            out RayCastResult hit,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default,
            NativeHandle<JPH_BodyFilter> bodyFilter = default
        )
        {
            AssertInitialized();

            fixed (RayCastResult* ptr = &hit)
            {
                return UnsafeBindings.JPH_NarrowPhaseQuery_CastRay(
                    query, &origin, &direction, (JPH_RayCastResult*)ptr,
                    GetOptionalPointer(broadPhaseLayerFilter),
                    GetOptionalPointer(objectLayerFilter),
                    GetOptionalPointer(bodyFilter)
                );
            }
        }

        public static bool JPH_NarrowPhaseQuery_CastRay(
            NativeHandle<JPH_NarrowPhaseQuery> query,
            // query parameters
            rvec3 origin, float3 direction, RayCastSettings settings,
            // query results container
            NativeList<RayCastResult> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default,
            NativeHandle<JPH_BodyFilter> bodyFilter = default,
            NativeHandle<JPH_ShapeFilter> shapeFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_NarrowPhaseQuery_CastRay2(
                query, &origin, &direction, (JPH_RayCastSettings*)(&settings),
                callback: UnsafeNarrowPhaseQueryCallbacks.UnsafeCastRayCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter),
                GetOptionalPointer(bodyFilter),
                GetOptionalPointer(shapeFilter)
            );
        }

        public static bool JPH_NarrowPhaseQuery_CastRay(
            NativeHandle<JPH_NarrowPhaseQuery> query,
            // query parameters
            rvec3 origin, float3 direction, RayCastSettings settings, CollisionCollectorType collector,
            // query results container
            NativeList<RayCastResult> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default,
            NativeHandle<JPH_BodyFilter> bodyFilter = default,
            NativeHandle<JPH_ShapeFilter> shapeFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_NarrowPhaseQuery_CastRay3(
                query, &origin, &direction, (JPH_RayCastSettings*)(&settings), collector,
                callback: UnsafeNarrowPhaseQueryCallbacks.UnsafeCastRayCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter),
                GetOptionalPointer(bodyFilter),
                GetOptionalPointer(shapeFilter)
            );
        }

        public static bool JPH_NarrowPhaseQuery_CollidePoint(
            NativeHandle<JPH_NarrowPhaseQuery> query,
            // query parameters
            rvec3 point,
            // query results container
            NativeList<CollidePointResult> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default,
            NativeHandle<JPH_BodyFilter> bodyFilter = default,
            NativeHandle<JPH_ShapeFilter> shapeFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_NarrowPhaseQuery_CollidePoint(
                query, &point,
                callback: UnsafeNarrowPhaseQueryCallbacks.UnsafeCollidePointCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter),
                GetOptionalPointer(bodyFilter),
                GetOptionalPointer(shapeFilter)
            );
        }

        public static bool JPH_NarrowPhaseQuery_CollidePoint2(
            NativeHandle<JPH_NarrowPhaseQuery> query,
            // query parameters
            rvec3 point, CollisionCollectorType collector,
            // query results container
            NativeList<CollidePointResult> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default,
            NativeHandle<JPH_BodyFilter> bodyFilter = default,
            NativeHandle<JPH_ShapeFilter> shapeFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_NarrowPhaseQuery_CollidePoint2(
                query, &point, collector,
                callback: UnsafeNarrowPhaseQueryCallbacks.UnsafeCollidePointCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter),
                GetOptionalPointer(bodyFilter),
                GetOptionalPointer(shapeFilter)
            );
        }

        public static bool JPH_NarrowPhaseQuery_CollideShape(
            NativeHandle<JPH_NarrowPhaseQuery> query,
            // query parameters
            NativeHandle<JPH_Shape> shape, float3 scale, rmatrix4x4 com, CollideShapeSettings settings, rvec3 offset,
            // query results container
            NativeList<CollideShapeResult> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default,
            NativeHandle<JPH_BodyFilter> bodyFilter = default,
            NativeHandle<JPH_ShapeFilter> shapeFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_NarrowPhaseQuery_CollideShape(
                query, shape, &scale, &com, (JPH_CollideShapeSettings*)&settings, &offset,
                callback: UnsafeNarrowPhaseQueryCallbacks.UnsafeCollideShapeCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter),
                GetOptionalPointer(bodyFilter),
                GetOptionalPointer(shapeFilter)
            );
        }

        public static bool JPH_NarrowPhaseQuery_CollideShape(
            NativeHandle<JPH_NarrowPhaseQuery> query,
            // query parameters
            NativeHandle<JPH_Shape> shape, float3 scale, rmatrix4x4 com, CollideShapeSettings settings, rvec3 offset, CollisionCollectorType collector,
            // query results container
            NativeList<CollideShapeResult> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default,
            NativeHandle<JPH_BodyFilter> bodyFilter = default,
            NativeHandle<JPH_ShapeFilter> shapeFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_NarrowPhaseQuery_CollideShape2(
                query, shape, &scale, &com, (JPH_CollideShapeSettings*)&settings, &offset, collector,
                callback: UnsafeNarrowPhaseQueryCallbacks.UnsafeCollideShapeCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter),
                GetOptionalPointer(bodyFilter),
                GetOptionalPointer(shapeFilter)
            );
        }

        public static bool JPH_NarrowPhaseQuery_CastShape(
            NativeHandle<JPH_NarrowPhaseQuery> query,
            // query parameters
            NativeHandle<JPH_Shape> shape, rmatrix4x4 worldTransform, float3 direction, ShapeCastSettings settings, rvec3 baseOffset,
            // query results container
            NativeList<CollideShapeResult> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default,
            NativeHandle<JPH_BodyFilter> bodyFilter = default,
            NativeHandle<JPH_ShapeFilter> shapeFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_NarrowPhaseQuery_CastShape(
                query, shape, &worldTransform, &direction, (JPH_ShapeCastSettings*)&settings, &baseOffset,
                callback: UnsafeNarrowPhaseQueryCallbacks.UnsafeCollideShapeCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter),
                GetOptionalPointer(bodyFilter),
                GetOptionalPointer(shapeFilter)
            );
        }

        public static bool JPH_NarrowPhaseQuery_CastShape(
            NativeHandle<JPH_NarrowPhaseQuery> query, NativeHandle<JPH_Shape> shape,
            // query parameters
            rmatrix4x4 worldTransform, float3 direction, ShapeCastSettings settings, rvec3 baseOffset, CollisionCollectorType collector,
            // query results container
            NativeList<CollideShapeResult> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default,
            NativeHandle<JPH_BodyFilter> bodyFilter = default,
            NativeHandle<JPH_ShapeFilter> shapeFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_NarrowPhaseQuery_CastShape2(
                query, shape, &worldTransform, &direction, (JPH_ShapeCastSettings*)&settings, &baseOffset, collector,
                callback: UnsafeNarrowPhaseQueryCallbacks.UnsafeCollideShapeCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter),
                GetOptionalPointer(bodyFilter),
                GetOptionalPointer(shapeFilter)
            );
        }
    }

    /// <summary>
    /// Static function pointers for JPH_NarrowPhaseQuery queries.
    /// </summary>
    internal static unsafe class UnsafeNarrowPhaseQueryCallbacks
    {
        private delegate void UnsafeCastRayDelegate(nint udata, RayCastResult* result);
        private delegate void UnsafeCollideShapeDelegate(nint udata, CollideShapeResult* result);
        private delegate void UnsafeCollidePointDelegate(nint udata, CollidePointResult* result);

        public static nint UnsafeCastRayCallbackPointer = Marshal.GetFunctionPointerForDelegate(
            (UnsafeCastRayDelegate)UnsafeCastRayCallback
        );

        public static nint UnsafeCollideShapeCallbackPointer = Marshal.GetFunctionPointerForDelegate(
            (UnsafeCollideShapeDelegate)UnsafeCollideShapeCallback
        );

        public static nint UnsafeCollidePointCallbackPointer = Marshal.GetFunctionPointerForDelegate(
            (UnsafeCollidePointDelegate)UnsafeCollidePointCallback
        );

        private static void TryAddNoResize<T>(UnsafeList<T>* list, T value) where T : unmanaged
        {
            // TODO add conditionally compiled error log about too small list
            if (list->Length < list->Capacity) list->AddNoResize(value);
        }

        private static void UnsafeCastRayCallback(nint udata, RayCastResult* result)
        {
            TryAddNoResize((UnsafeList<RayCastResult>*)udata, *result);
        }

        private static void UnsafeCollideShapeCallback(nint udata, CollideShapeResult* result)
        {
            TryAddNoResize((UnsafeList<CollideShapeResult>*)udata, *result);
        }

        private static void UnsafeCollidePointCallback(nint udata, CollidePointResult* result)
        {
            TryAddNoResize((UnsafeList<CollidePointResult>*)udata, *result);
        }
    }
}
