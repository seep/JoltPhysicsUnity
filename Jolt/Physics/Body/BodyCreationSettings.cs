using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_BodyCreationSettings"), GenerateBindings("JPH_BodyCreationSettings")]
    public readonly partial struct BodyCreationSettings
    {
        internal readonly NativeHandle<JPH_BodyCreationSettings> Handle;

        internal BodyCreationSettings(NativeHandle<JPH_BodyCreationSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_BodyCreationSettings_Create")]
        public static BodyCreationSettings Create()
        {
            return new BodyCreationSettings(JPH_BodyCreationSettings_Create());
        }

        [OverrideBinding("JPH_BodyCreationSettings_Create2")]
        public static BodyCreationSettings FromShapeSettings(ShapeSettings settings, rvec3 position, quaternion rotation, MotionType motion, ushort layer)
        {
            return new BodyCreationSettings(JPH_BodyCreationSettings_Create2(settings.Handle, position, rotation, motion, layer));
        }

        [OverrideBinding("JPH_BodyCreationSettings_Create3")]
        public static BodyCreationSettings FromShape(Shape shape, rvec3 position, quaternion rotation, MotionType motion, ushort layer)
        {
            return new BodyCreationSettings(JPH_BodyCreationSettings_Create3(shape.Handle, position, rotation, motion, layer));
        }
    }
}
