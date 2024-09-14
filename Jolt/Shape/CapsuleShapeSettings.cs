using System;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_CapsuleShapeSettings"), GenerateBindings("JPH_CapsuleShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct CapsuleShapeSettings
    {
        [OverrideBinding("JPH_CapsuleShapeSettings_Create")]
        public static CapsuleShapeSettings Create(float halfHeightOfCylinder, float radius)
        {
            return new CapsuleShapeSettings(JPH_CapsuleShapeSettings_Create(halfHeightOfCylinder, radius));
        }
    }
}
