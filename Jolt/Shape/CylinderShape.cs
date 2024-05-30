using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_CylinderShape")]
    public readonly partial struct CylinderShape: IConvexShape
    {
        internal readonly NativeHandle<JPH_CylinderShape> Handle;

        internal CylinderShape(NativeHandle<JPH_CylinderShape> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_CylinderShape_Create")]
        public static CylinderShape Create(float halfHeightOfCylinder, float radius)
        {
            return new CylinderShape(JPH_CylinderShape_Create(halfHeightOfCylinder, radius));
        }
    }
}
