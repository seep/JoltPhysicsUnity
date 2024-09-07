using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_PlaneShapeSettings"), GenerateBindings("JPH_PlaneShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct PlaneShapeSettings
    {
        [OverrideBinding("JPH_PlaneShapeSettings_Create")]
        public static PlaneShapeSettings Create(Plane plane, float halfExtent)
        {
            return new PlaneShapeSettings(JPH_PlaneShapeSettings_Create(plane, halfExtent));
        }
    }
}
