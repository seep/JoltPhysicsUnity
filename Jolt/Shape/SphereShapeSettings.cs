using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_SphereShapeSettings"), GenerateBindings("JPH_SphereShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_ShapeSettings")]
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

        /// <summary>
        /// Allocate a new native SphereShape from these settings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_SphereShapeSettings_CreateShape")]
        public SphereShape CreateShape()
        {
            return new SphereShape(JPH_SphereShapeSettings_CreateShape(Handle));
        }
    }
}
