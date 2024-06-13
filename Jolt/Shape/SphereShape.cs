using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_SphereShape"), GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_SphereShape")]
    public readonly partial struct SphereShape
    {
        internal readonly NativeHandle<JPH_SphereShape> Handle;

        internal SphereShape(NativeHandle<JPH_SphereShape> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_SphereShape_Create")]
        public static SphereShape Create(float radius)
        {
            return new SphereShape(JPH_SphereShape_Create(radius));
        }
    }
}
