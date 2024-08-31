using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_PlaneShapeSettings"), GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_PlaneShapeSettings")]
    public readonly partial struct PlaneShapeSettings
    {
        internal readonly NativeHandle<JPH_PlaneShapeSettings> Handle;

        internal PlaneShapeSettings(NativeHandle<JPH_PlaneShapeSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_PlaneShapeSettings_Create")]
        public static PlaneShapeSettings Create(Plane plane, float halfExtent)
        {
            return new PlaneShapeSettings(JPH_PlaneShapeSettings_Create(plane, halfExtent));
        }
    }
}
