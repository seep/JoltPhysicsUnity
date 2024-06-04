using Unity.Mathematics;

using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_BoxShapeSettings")]
    public readonly partial struct BoxShapeSettings : IConvexShapeSettings
    {
        internal readonly NativeHandle<JPH_BoxShapeSettings> Handle;

        internal BoxShapeSettings(NativeHandle<JPH_BoxShapeSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_BoxShapeSettings_Create")]
        public static BoxShapeSettings Create(float3 halfExtent, float convexRadius = PhysicsSettings.DefaultConvexRadius)
        {
            return new BoxShapeSettings(JPH_BoxShapeSettings_Create(halfExtent, convexRadius));
        }
    }
}
