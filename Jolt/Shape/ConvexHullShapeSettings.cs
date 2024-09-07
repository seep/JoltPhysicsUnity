﻿using System;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_ConvexHullShapeSettings"), GenerateBindings("JPH_ConvexHullShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_ShapeSettings")]
    public readonly partial struct ConvexHullShapeSettings
    {
        [OverrideBinding("JPH_ConvexHullShapeSettings_Create")]
        public static ConvexHullShapeSettings Create(ReadOnlySpan<float3> points, float maxConvexRadius)
        {
            return new ConvexHullShapeSettings(JPH_ConvexHullShapeSettings_Create(points, maxConvexRadius));
        }

        [OverrideBinding("JPH_ConvexHullShapeSettings_CreateShape")]
        public ConvexHullShape CreateShape()
        {
            return new ConvexHullShape(JPH_ConvexHullShapeSettings_CreateShape(Handle));
        }
    }
}
