using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_BoxShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public partial struct BoxShapeSettings
    {
        internal NativeHandle<JPH_BoxShapeSettings> Handle;
        
        public static BoxShapeSettings Create(float3 halfExtent, float convexRadius = PhysicsSettings.DefaultConvexRadius)
        {
            return new BoxShapeSettings { Handle = JPH_BoxShapeSettings_Create(halfExtent, convexRadius) };
        }
    }
}
