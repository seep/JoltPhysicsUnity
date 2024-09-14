using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_TriangleShapeSettings"), GenerateBindings("JPH_TriangleShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct TriangleShapeSettings
    {
        [OverrideBinding("JPH_TriangleShapeSettings_Create")]
        public static TriangleShapeSettings Create(float3 va, float3 vb, float3 vc, float convexRadius)
        {
            return new TriangleShapeSettings(JPH_TriangleShapeSettings_Create(va, vb, vc, convexRadius));
        }
    }
}
