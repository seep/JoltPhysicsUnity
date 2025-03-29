using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_TriangleShapeSettings> JPH_TriangleShapeSettings_Create(float3 va, float3 vb, float3 vc, float convexRadius)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_TriangleShapeSettings_Create(&va, &vb, &vc, convexRadius));
        }

        public static NativeHandle<JPH_TriangleShape> JPH_TriangleShapeSettings_CreateShape(NativeHandle<JPH_TriangleShapeSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_TriangleShapeSettings_CreateShape(settings));
        }
    }
}
