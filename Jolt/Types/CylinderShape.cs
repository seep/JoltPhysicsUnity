using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_CylinderShape", "JPH_ConvexShape", "JPH_Shape")]
    public partial struct CylinderShape
    {
        internal NativeHandle<JPH_CylinderShape> Handle;
        
        public static CylinderShape Create(float halfHeightOfCylinder, float radius)
        {
            return new CylinderShape { Handle = JPH_CylinderShape_Create(halfHeightOfCylinder, radius) };
        }
    }
}
