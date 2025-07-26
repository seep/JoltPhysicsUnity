using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_PlaneShape", "JPH_Shape")]
    public partial struct PlaneShape
    {
        internal NativeHandle<JPH_PlaneShape> Handle;

        public PlaneShape(in Plane plane, in float halfExtent)
        {
            Handle = JPH_PlaneShape_Create(plane, halfExtent);
        }
        
        public static PlaneShape Create(Plane plane, float halfExtent)
        {
            return new PlaneShape { Handle = JPH_PlaneShape_Create(plane, halfExtent) };
        }
    }
}
