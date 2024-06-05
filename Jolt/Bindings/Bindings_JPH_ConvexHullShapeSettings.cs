using System;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_ConvexHullShapeSettings> JPH_ConvexHullShapeSettings_Create(ReadOnlySpan<float3> points, float maxConvexRadius)
        {
            fixed (float3* pointsPtr = points)
            {
                return CreateHandle(UnsafeBindings.JPH_ConvexHullShapeSettings_Create(pointsPtr, (uint)points.Length, maxConvexRadius));
            }
        }

        public static NativeHandle<JPH_ConvexHullShape> JPH_ConvexHullShapeSettings_CreateShape(NativeHandle<JPH_ConvexHullShapeSettings> settings)
        {
            return CreateHandle(UnsafeBindings.JPH_ConvexHullShapeSettings_CreateShape(settings));
        }
    }
}
