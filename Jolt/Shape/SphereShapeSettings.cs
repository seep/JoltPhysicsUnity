using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_SphereShapeSettings"), GenerateBindings("JPH_SphereShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct SphereShapeSettings
    {
        /// <summary>
        /// Allocate a new native SphereShapeSettings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_SphereShapeSettings_Create")]
        public static SphereShapeSettings Create(float radius)
        {
            return new SphereShapeSettings(JPH_SphereShapeSettings_Create(radius));
        }
    }
}
