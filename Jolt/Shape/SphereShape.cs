using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_SphereShape"), GenerateBindings("JPH_SphereShape", "JPH_ConvexShape", "JPH_Shape")]
    public readonly partial struct SphereShape
    {
        [OverrideBinding("JPH_SphereShape_Create")]
        public static SphereShape Create(float radius)
        {
            return new SphereShape(JPH_SphereShape_Create(radius));
        }
    }
}
