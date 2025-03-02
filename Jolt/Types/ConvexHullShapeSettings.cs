using System;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_ConvexHullShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public partial struct ConvexHullShapeSettings
    {
        internal NativeHandle<JPH_ConvexHullShapeSettings> Handle;
        
        public static ConvexHullShapeSettings Create(ReadOnlySpan<float3> points, float maxConvexRadius)
        {
            return new ConvexHullShapeSettings { Handle = JPH_ConvexHullShapeSettings_Create(points, maxConvexRadius) };
        }
    }
}
