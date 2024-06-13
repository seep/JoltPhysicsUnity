using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_CapsuleShape"), GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_CapsuleShape")]
    public readonly partial struct CapsuleShape
    {
        internal readonly NativeHandle<JPH_CapsuleShape> Handle;

        internal CapsuleShape(NativeHandle<JPH_CapsuleShape> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_CapsuleShape_Create")]
        public static CapsuleShape Create(float halfHeightOfCylinder, float radius)
        {
            return new CapsuleShape(JPH_CapsuleShape_Create(halfHeightOfCylinder, radius));
        }
    }
}
