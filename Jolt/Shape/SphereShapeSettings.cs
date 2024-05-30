using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_SphereShapeSettings")]
    public readonly partial struct SphereShapeSettings : IConvexShapeSettings
    {
        internal readonly NativeHandle<JPH_SphereShapeSettings> Handle;

        internal SphereShapeSettings(NativeHandle<JPH_SphereShapeSettings> handle)
        {
            Handle = handle;
        }

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
