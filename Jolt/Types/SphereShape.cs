using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_SphereShape", "JPH_ConvexShape", "JPH_Shape")]
    public partial struct SphereShape
    {
        internal NativeHandle<JPH_SphereShape> Handle;
        
        public static SphereShape Create(float radius)
        {
            return new SphereShape { Handle = JPH_SphereShape_Create(radius) };
        }
    }
}
