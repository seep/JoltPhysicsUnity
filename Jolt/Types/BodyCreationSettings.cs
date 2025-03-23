using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_BodyCreationSettings")]
    public partial struct BodyCreationSettings
    {
        internal NativeHandle<JPH_BodyCreationSettings> Handle;

        public static BodyCreationSettings Create()
        {
            return new BodyCreationSettings { Handle = JPH_BodyCreationSettings_Create() };
        }

        public static BodyCreationSettings Create(ShapeSettings settings, rvec3 position, quaternion rotation, MotionType motion, ObjectLayer layer)
        {
            return new BodyCreationSettings { Handle = JPH_BodyCreationSettings_Create(settings.Handle, position, rotation, motion, layer) };
        }

        public static BodyCreationSettings Create(Shape shape, rvec3 position, quaternion rotation, MotionType motion, ObjectLayer layer)
        {
            return new BodyCreationSettings { Handle = JPH_BodyCreationSettings_Create(shape.Handle, position, rotation, motion, layer) };
        }
    }
}
