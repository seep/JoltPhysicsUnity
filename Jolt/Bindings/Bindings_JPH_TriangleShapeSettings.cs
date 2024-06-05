using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_TriangleShapeSettings> JPH_TriangleShapeSettings_Create(float3 va, float3 vb, float3 vc, float convexRadius)
        {
            return CreateHandle(UnsafeBindings.JPH_TriangleShapeSettings_Create(&va, &vb, &vc, convexRadius));
        }
    }
}
