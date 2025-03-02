using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_TriangleShapeSettings", "JPH_ShapeSettings")]
    public partial struct TriangleShapeSettings
    {
        internal NativeHandle<JPH_TriangleShapeSettings> Handle;
        
        public static TriangleShapeSettings Create(float3 va, float3 vb, float3 vc, float convexRadius)
        {
            return new TriangleShapeSettings { Handle = JPH_TriangleShapeSettings_Create(va, vb, vc, convexRadius) };
        }
    }
}
