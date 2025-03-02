using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_PlaneShapeSettings", "JPH_ShapeSettings")]
    public partial struct PlaneShapeSettings
    {
        internal NativeHandle<JPH_PlaneShapeSettings> Handle;
        
        public static PlaneShapeSettings Create(Plane plane, float halfExtent)
        {
            return new PlaneShapeSettings { Handle = JPH_PlaneShapeSettings_Create(plane, halfExtent) };
        }
    }
}
