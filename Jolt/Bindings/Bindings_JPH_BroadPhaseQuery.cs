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
        public static bool JPH_BroadPhaseQuery_CastRay(
            NativeHandle<JPH_BroadPhaseQuery> query, float3 origin, float3 direction, BroadPhaseQuery.CastRayCallback callback,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BroadPhaseQuery_CastRay(
                query, &origin, &direction,
                callback: UnsafeBroadPhaseQueryCallbacks.UnsafeCastRayCallbackPointer,
                userData: GetDelegatePointer(callback),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter)
            );
        }

        public static bool JPH_BroadPhaseQuery_CastRay(
            NativeHandle<JPH_BroadPhaseQuery> query, float3 origin, float3 direction,
            CollisionCollectorType collisionCollectorType, BroadPhaseQuery.CastRayCallback callback,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BroadPhaseQuery_CastRay2(
                query, &origin, &direction, collisionCollectorType,
                callback: UnsafeBroadPhaseQueryCallbacks.UnsafeCastRayCallbackPointer,
                userData: GetDelegatePointer(callback),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter)
            );
        }

        public static bool JPH_BroadPhaseQuery_CollideAABox(
            NativeHandle<JPH_BroadPhaseQuery> query, AABox box, BroadPhaseQuery.CollideCallback callback,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BroadPhaseQuery_CollideAABox(
                query, (JPH_AABox*)&box,
                callback: UnsafeBroadPhaseQueryCallbacks.UnsafeCollideCallbackPointer,
                userData: GetDelegatePointer(callback),
                GetOptionalPointer(broadPhaseLayerFilter),
                GetOptionalPointer(objectLayerFilter)
            );
        }

        public static bool JPH_BroadPhaseQuery_CollideSphere(
            NativeHandle<JPH_BroadPhaseQuery> query, float3 center, float radius, BroadPhaseQuery.CollideCallback callback,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BroadPhaseQuery_CollideSphere(
                query, &center, radius,
                callback: UnsafeBroadPhaseQueryCallbacks.UnsafeCollideCallbackPointer,
                userData: GetDelegatePointer(callback),
                broadPhaseLayerFilter, objectLayerFilter
            );
        }

        public static bool JPH_BroadPhaseQuery_CollidePoint(
            NativeHandle<JPH_BroadPhaseQuery> query, float3 point, BroadPhaseQuery.CollideCallback callback,
            NativeHandle<JPH_BroadPhaseLayerFilter> broadPhaseLayerFilter = default,
            NativeHandle<JPH_ObjectLayerFilter> objectLayerFilter = default
        )
        {
            AssertInitialized();

            return UnsafeBindings.JPH_BroadPhaseQuery_CollidePoint(
                query, &point,
                callback: UnsafeBroadPhaseQueryCallbacks.UnsafeCollideCallbackPointer,
                userData: GetDelegatePointer(callback),
                broadPhaseLayerFilter, objectLayerFilter
            );
        }
    }

    /// <summary>
    /// Static function pointers for JPH_BroadPhaseQuery queries; the individual callback pointers are passed via the user data.
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
