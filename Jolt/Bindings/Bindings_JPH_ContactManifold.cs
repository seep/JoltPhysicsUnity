using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static float3 JPH_ContactManifold_GetWorldSpaceNormal(NativeHandle<JPH_ContactManifold> manifold)
        {
            float3 result;
            UnsafeBindings.JPH_ContactManifold_GetWorldSpaceNormal(manifold, &result);
            return result;
        }

        public static float JPH_ContactManifold_GetPenetrationDepth(NativeHandle<JPH_ContactManifold> manifold)
        {
            return UnsafeBindings.JPH_ContactManifold_GetPenetrationDepth(manifold);
        }
        
        public static SubShapeID JPH_ContactManifold_GetSubShapeID1(NativeHandle<JPH_ContactManifold> manifold)
        {
            return UnsafeBindings.JPH_ContactManifold_GetSubShapeID1(manifold);
        }

        public static SubShapeID JPH_ContactManifold_GetSubShapeID2(NativeHandle<JPH_ContactManifold> manifold) 
        {
            return UnsafeBindings.JPH_ContactManifold_GetSubShapeID2(manifold);
        }

        public static uint JPH_ContactManifold_GetPointCount(NativeHandle<JPH_ContactManifold> manifold) 
        {
            return UnsafeBindings.JPH_ContactManifold_GetPointCount(manifold);
        }

        public static rvec3 JPH_ContactManifold_GetWorldSpaceContactPointOn1(NativeHandle<JPH_ContactManifold> manifold, uint index)
        {
            rvec3 result;
            UnsafeBindings.JPH_ContactManifold_GetWorldSpaceContactPointOn1(manifold, index, &result);
            return result;
        }

        public static rvec3 JPH_ContactManifold_GetWorldSpaceContactPointOn2(NativeHandle<JPH_ContactManifold> manifold, uint index) 
        {
            rvec3 result;
            UnsafeBindings.JPH_ContactManifold_GetWorldSpaceContactPointOn1(manifold, index, &result);
            return result;
        }
    }
}
