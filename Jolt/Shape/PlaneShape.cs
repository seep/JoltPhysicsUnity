using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_PlaneShape"), GenerateBindings("JPH_PlaneShape", "JPH_Shape")]
    public readonly partial struct PlaneShape
    {
        [OverrideBinding("JPH_PlaneShape_Create")]
        public static PlaneShape Create(Plane plane, float halfExtent)
        {
            return new PlaneShape(JPH_PlaneShape_Create(plane, halfExtent));
        }
    }
}
