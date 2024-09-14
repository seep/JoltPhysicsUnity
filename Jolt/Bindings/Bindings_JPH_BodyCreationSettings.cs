using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_BodyCreationSettings_Create());
        }

        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create(NativeHandle<JPH_ShapeSettings> settings, rvec3 position, quaternion rotation, MotionType motion, ushort layer)
        {
            return CreateHandle(UnsafeBindings.JPH_BodyCreationSettings_Create2(settings, &position, &rotation, motion, layer));
        }

        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create(NativeHandle<JPH_Shape> shape, rvec3 position, quaternion rotation, MotionType motion, ushort layer)
        {
            return CreateHandle(UnsafeBindings.JPH_BodyCreationSettings_Create3(shape, &position, &rotation, motion, layer));
        }

        public static void JPH_BodyCreationSettings_Destroy(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            UnsafeBindings.JPH_BodyCreationSettings_Destroy(settings);

            settings.Dispose();
        }

        public static rvec3 JPH_BodyCreationSettings_GetPosition(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_BodyCreationSettings_GetPosition(settings, &result);
            return result;
        }

        public static void JPH_BodyCreationSettings_SetPosition(NativeHandle<JPH_BodyCreationSettings> settings, rvec3 value)
        {
            UnsafeBindings.JPH_BodyCreationSettings_SetPosition(settings, &value);
        }

        public static quaternion JPH_BodyCreationSettings_GetRotation(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            quaternion result;
            UnsafeBindings.JPH_BodyCreationSettings_GetRotation(settings, &result);
            return result;
        }

        public static void JPH_BodyCreationSettings_SetRotation(NativeHandle<JPH_BodyCreationSettings> settings, quaternion value)
        {
            UnsafeBindings.JPH_BodyCreationSettings_SetRotation(settings, &value);
        }

        public static float3 JPH_BodyCreationSettings_GetLinearVelocity(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            float3 result;
            UnsafeBindings.JPH_BodyCreationSettings_GetLinearVelocity(settings, &result);
            return result;
        }

        public static void JPH_BodyCreationSettings_SetLinearVelocity(NativeHandle<JPH_BodyCreationSettings> settings, float3 velocity)
        {
            UnsafeBindings.JPH_BodyCreationSettings_SetLinearVelocity(settings, &velocity);
        }

        public static float3 JPH_BodyCreationSettings_GetAngularVelocity(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            float3 result;
            UnsafeBindings.JPH_BodyCreationSettings_GetAngularVelocity(settings, &result);
            return result;
        }

        public static void JPH_BodyCreationSettings_SetAngularVelocity(NativeHandle<JPH_BodyCreationSettings> settings, float3 velocity)
        {
            UnsafeBindings.JPH_BodyCreationSettings_SetAngularVelocity(settings, &velocity);
        }

        public static MotionType JPH_BodyCreationSettings_GetMotionType(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return UnsafeBindings.JPH_BodyCreationSettings_GetMotionType(settings);
        }

        public static void JPH_BodyCreationSettings_SetMotionType(NativeHandle<JPH_BodyCreationSettings> settings, MotionType value)
        {
            UnsafeBindings.JPH_BodyCreationSettings_SetMotionType(settings, value);
        }

        public static AllowedDOFs JPH_BodyCreationSettings_GetAllowedDOFs(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return UnsafeBindings.JPH_BodyCreationSettings_GetAllowedDOFs(settings);
        }

        public static void JPH_BodyCreationSettings_SetAllowedDOFs(NativeHandle<JPH_BodyCreationSettings> settings, AllowedDOFs value)
        {
            UnsafeBindings.JPH_BodyCreationSettings_SetAllowedDOFs(settings, value);
        }
    }
}
