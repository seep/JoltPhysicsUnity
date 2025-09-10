using System;
using System.Runtime.InteropServices;
using AOT;
using Unity.Collections;
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
        public static bool JPH_BroadPhaseQuery_CastRay(
            NativeHandle<JPH_BroadPhaseQuery> query,
            // query parameters
            float3 origin, float3 direction,
            // query results container
            NativeList<BroadPhaseCastResult> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BroadPhaseQuery_CastRay(
                query, &origin, &direction,
                callback: UnsafeBroadPhaseQueryCallbacks.UnsafeCastRayCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter)
            );
        }

        public static bool JPH_BroadPhaseQuery_CastRay(
            NativeHandle<JPH_BroadPhaseQuery> query,
            // query parameters
            float3 origin, float3 direction, CollisionCollectorType collisionCollectorType,
            // query results container
            NativeList<BroadPhaseCastResult> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BroadPhaseQuery_CastRay2(
                query, &origin, &direction, collisionCollectorType,
                callback: UnsafeBroadPhaseQueryCallbacks.UnsafeCastRayCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter)
            );
        }

        public static bool JPH_BroadPhaseQuery_CollideAABox(
            NativeHandle<JPH_BroadPhaseQuery> query,
            // query parameters
            AABox box,
            // query results container
            NativeList<BodyID> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BroadPhaseQuery_CollideAABox(
                query, (JPH_AABox*)&box,
                callback: UnsafeBroadPhaseQueryCallbacks.UnsafeCollideCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter)
            );
        }

        public static bool JPH_BroadPhaseQuery_CollideSphere(
            NativeHandle<JPH_BroadPhaseQuery> query,
            // query parameters
            float3 center, float radius,
            // query results container
            NativeList<BodyID> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BroadPhaseQuery_CollideSphere(
                query, &center, radius,
                callback: UnsafeBroadPhaseQueryCallbacks.UnsafeCollideCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                broadPhaseLayerFilter, objectLayerFilter
            );
        }

        public static bool JPH_BroadPhaseQuery_CollidePoint(
            NativeHandle<JPH_BroadPhaseQuery> query,
            // query parameters
            float3 point,
            // query results container
            NativeList<BodyID> results,
            // optional filters
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BroadPhaseQuery_CollidePoint(
                query, &point,
                callback: UnsafeBroadPhaseQueryCallbacks.UnsafeCollideCallbackPointer,
                userData: (nint)results.GetUnsafeList(),
                broadPhaseLayerFilter, objectLayerFilter
            );
        }
    }

    /// <summary>
    /// Static function pointers for JPH_BroadPhaseQuery queries.
    /// </summary>
    internal static unsafe class UnsafeBroadPhaseQueryCallbacks
    {
        private delegate void UnsafeCastRayDelegate(nint udata, BroadPhaseCastResult* result);
        private delegate void UnsafeCollideDelegate(nint udata, BodyID result);

        public static nint UnsafeCastRayCallbackPointer = Marshal.GetFunctionPointerForDelegate(
            (UnsafeCastRayDelegate)UnsafeCastRayCallback
        );

        public static nint UnsafeCollideCallbackPointer = Marshal.GetFunctionPointerForDelegate(
            (UnsafeCollideDelegate)UnsafeCollideCallback
        );

        private static void TryAddNoResize<T>(UnsafeList<T>* list, T value) where T : unmanaged
        {
            // TODO add conditionally compiled error log about too small list
            if (list->Length < list->Capacity) list->AddNoResize(value);
        }
        
        [MonoPInvokeCallback(typeof(UnsafeCastRayDelegate))]
        private static void UnsafeCastRayCallback(nint udata, BroadPhaseCastResult* result)
        {
            TryAddNoResize((UnsafeList<BroadPhaseCastResult>*)udata, *result);
        }

        [MonoPInvokeCallback(typeof(UnsafeCollideDelegate))]
        private static void UnsafeCollideCallback(nint udata, BodyID result)
        {
            TryAddNoResize((UnsafeList<BodyID>*)udata, result);
        }
    }
}
