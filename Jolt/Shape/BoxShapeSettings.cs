using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_BoxShapeSettings"), GenerateBindings("JPH_BoxShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct BoxShapeSettings
    {
        [OverrideBinding("JPH_BoxShapeSettings_Create")]
        public static BoxShapeSettings Create(float3 halfExtent, float convexRadius = PhysicsSettings.DefaultConvexRadius)
        {
            return new BoxShapeSettings(JPH_BoxShapeSettings_Create(halfExtent, convexRadius));
        }
    }
}
