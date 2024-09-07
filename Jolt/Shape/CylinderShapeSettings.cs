using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_CylinderShapeSettings"), GenerateBindings("JPH_CylinderShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct CylinderShapeSettings
    {
        /// <summary>
        /// Allocate a new native CylinderShapeSettings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_CylinderShapeSettings_Create")]
        public static CylinderShapeSettings Create(float halfHeight, float radius, float convexRadius)
        {
            // TODO JPH_CylinderShapeSettings_Create takes convex radius but JPH_CylinderShape_Create does not?

            return new CylinderShapeSettings(JPH_CylinderShapeSettings_Create(halfHeight, radius, convexRadius));
        }
    }
}
