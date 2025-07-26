using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_BoxShape", "JPH_ConvexShape", "JPH_Shape")]
    public partial struct BoxShape
    {
        internal NativeHandle<JPH_BoxShape> Handle;

        public BoxShape(float3 halfExtent, float convexRadius = PhysicsSettings.DefaultConvexRadius)
        {
            Handle = JPH_BoxShape_Create(halfExtent, convexRadius);
        }
        
        public static BoxShape Create(float3 halfExtent, float convexRadius = PhysicsSettings.DefaultConvexRadius)
        {
            return new BoxShape { Handle = JPH_BoxShape_Create(halfExtent, convexRadius) };
        }
    }
}
