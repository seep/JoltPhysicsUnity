using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_BoxShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public partial struct BoxShapeSettings
    {
        internal NativeHandle<JPH_BoxShapeSettings> Handle;

        public BoxShapeSettings(float3 halfExtents,float convexRadius = PhysicsSettings.DefaultConvexRadius)
        {
            Handle = JPH_BoxShapeSettings_Create(halfExtents, convexRadius);
        }
        public static BoxShapeSettings Create(float3 halfExtent, float convexRadius = PhysicsSettings.DefaultConvexRadius)
        {
            return new BoxShapeSettings { Handle = JPH_BoxShapeSettings_Create(halfExtent, convexRadius) };
        }
    }
}
