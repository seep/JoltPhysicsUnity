using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_TriangleShape> JPH_TriangleShape_Create(float3 va, float3 vb, float3 vc, float convexRadius)
        {
            return CreateHandle(UnsafeBindings.JPH_TriangleShape_Create(&va, &vb, &vc, convexRadius));
        }

        public static float JPH_TriangleShape_GetConvexRadius(NativeHandle<JPH_TriangleShape> shape)
        {
            return UnsafeBindings.JPH_TriangleShape_GetConvexRadius(shape);
        }

        public static float3 JPH_TriangleShape_GetVertex1(NativeHandle<JPH_TriangleShape> shape)
        {
            float3 result;
            UnsafeBindings.JPH_TriangleShape_GetVertex1(shape, &result);
            return result;
        }

        public static float3 JPH_TriangleShape_GetVertex2(NativeHandle<JPH_TriangleShape> shape)
        {
            float3 result;
            UnsafeBindings.JPH_TriangleShape_GetVertex2(shape, &result);
            return result;
        }

        public static float3 JPH_TriangleShape_GetVertex3(NativeHandle<JPH_TriangleShape> shape)
        {
            float3 result;
            UnsafeBindings.JPH_TriangleShape_GetVertex3(shape, &result);
            return result;
        }
    }
}
