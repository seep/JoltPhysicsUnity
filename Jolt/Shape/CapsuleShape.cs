﻿using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_CapsuleShape"), GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_CapsuleShape")]
    public readonly partial struct CapsuleShape
    {
        [OverrideBinding("JPH_CapsuleShape_Create")]
        public static CapsuleShape Create(float halfHeightOfCylinder, float radius)
        {
            return new CapsuleShape(JPH_CapsuleShape_Create(halfHeightOfCylinder, radius));
        }
    }
}
