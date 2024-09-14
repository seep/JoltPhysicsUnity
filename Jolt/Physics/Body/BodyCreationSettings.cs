using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_BodyCreationSettings"), GenerateBindings("JPH_BodyCreationSettings")]
    public readonly partial struct BodyCreationSettings
    {
        [OverrideBinding("JPH_BodyCreationSettings_Create")]
        public static BodyCreationSettings Create()
        {
            return new BodyCreationSettings(JPH_BodyCreationSettings_Create());
        }

        [OverrideBinding("JPH_BodyCreationSettings_Create")]
        public static BodyCreationSettings Create(ShapeSettings settings, rvec3 position, quaternion rotation, MotionType motion, ushort layer)
        {
            return new BodyCreationSettings(JPH_BodyCreationSettings_Create(settings.Handle, position, rotation, motion, layer));
        }

        [OverrideBinding("JPH_BodyCreationSettings_Create")]
        public static BodyCreationSettings Create(Shape shape, rvec3 position, quaternion rotation, MotionType motion, ushort layer)
        {
            return new BodyCreationSettings(JPH_BodyCreationSettings_Create(shape.Handle, position, rotation, motion, layer));
        }
    }
}
