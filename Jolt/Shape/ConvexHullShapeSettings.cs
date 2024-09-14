using System;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_ConvexHullShapeSettings"), GenerateBindings("JPH_ConvexHullShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct ConvexHullShapeSettings
    {
        [OverrideBinding("JPH_ConvexHullShapeSettings_Create")]
        public static ConvexHullShapeSettings Create(ReadOnlySpan<float3> points, float maxConvexRadius)
        {
            return new ConvexHullShapeSettings(JPH_ConvexHullShapeSettings_Create(points, maxConvexRadius));
        }
    }
}
