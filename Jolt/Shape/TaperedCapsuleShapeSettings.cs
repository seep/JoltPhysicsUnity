﻿using System;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_TaperedCapsuleShapeSettings"), GenerateBindings("JPH_TaperedCapsuleShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_ShapeSettings")]
    public readonly partial struct TaperedCapsuleShapeSettings
    {
        [OverrideBinding("JPH_TaperedCapsuleShapeSettings_Create")]
        public static TaperedCapsuleShapeSettings Create(float halfHeightOfCylinder, float topRadius, float bottomRadius)
        {
            return new TaperedCapsuleShapeSettings(JPH_TaperedCapsuleShapeSettings_Create(halfHeightOfCylinder, topRadius, bottomRadius));
        }

        [OverrideBinding("JPH_TaperedCapsuleShapeSettings_CreateShape")]
        public TaperedCapsuleShape CreateShape()
        {
            throw new NotImplementedException(); // TODO JPH_TaperedCapsuleShapeSettings_CreateShape is missing from bindings?
        }
    }
}
