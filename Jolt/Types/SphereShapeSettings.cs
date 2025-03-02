using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_SphereShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public partial struct SphereShapeSettings
    {
        internal NativeHandle<JPH_SphereShapeSettings> Handle;
        
        /// <summary>
        /// Allocate a new native SphereShapeSettings and return the handle.
        /// </summary>
        public static SphereShapeSettings Create(float radius)
        {
            return new SphereShapeSettings { Handle = JPH_SphereShapeSettings_Create(radius) };
        }
    }
}
