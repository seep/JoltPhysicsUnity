using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_CylinderShape"), GenerateBindings("JPH_CylinderShape", "JPH_ConvexShape", "JPH_Shape")]
    public readonly partial struct CylinderShape
    {
        [OverrideBinding("JPH_CylinderShape_Create")]
        public static CylinderShape Create(float halfHeightOfCylinder, float radius)
        {
            return new CylinderShape(JPH_CylinderShape_Create(halfHeightOfCylinder, radius));
        }
    }
}
