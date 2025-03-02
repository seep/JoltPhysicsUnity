using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_CylinderShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public partial struct CylinderShapeSettings
    {
        internal NativeHandle<JPH_CylinderShapeSettings> Handle;
        
        /// <summary>
        /// Allocate a new native CylinderShapeSettings and return the handle.
        /// </summary>
        public static CylinderShapeSettings Create(float halfHeight, float radius, float convexRadius)
        {
            // TODO JPH_CylinderShapeSettings_Create takes convex radius but JPH_CylinderShape_Create does not?

            return new CylinderShapeSettings { Handle = JPH_CylinderShapeSettings_Create(halfHeight, radius, convexRadius) };
        }
    }
}
