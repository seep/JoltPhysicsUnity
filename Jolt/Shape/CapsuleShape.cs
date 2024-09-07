using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_CapsuleShape"), GenerateBindings("JPH_CapsuleShape", "JPH_ConvexShape", "JPH_Shape")]
    public readonly partial struct CapsuleShape
    {
        [OverrideBinding("JPH_CapsuleShape_Create")]
        public static CapsuleShape Create(float halfHeightOfCylinder, float radius)
        {
            return new CapsuleShape(JPH_CapsuleShape_Create(halfHeightOfCylinder, radius));
        }
    }
}
