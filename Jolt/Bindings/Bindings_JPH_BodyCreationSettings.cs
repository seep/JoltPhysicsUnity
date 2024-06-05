using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_BodyCreationSettings_Create());
        }

        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create2<T>(NativeHandle<T> settings, rvec3 position, quaternion rotation, MotionType motion, ushort layer) where T : unmanaged, INativeShapeSettings
        {
            return CreateHandle(UnsafeBindings.JPH_BodyCreationSettings_Create2(settings.Reinterpret<JPH_ShapeSettings>(), &position, &rotation, motion, layer));
        }

        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create3<T>(NativeHandle<T> shape, rvec3 position, quaternion rotation, MotionType motion, ushort layer) where T : unmanaged, INativeShape
        {
            return CreateHandle(UnsafeBindings.JPH_BodyCreationSettings_Create3(shape.Reinterpret<JPH_Shape>(), &position, &rotation, motion, layer));
        }

        public static void JPH_BodyCreationSettings_Destroy(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            UnsafeBindings.JPH_BodyCreationSettings_Destroy(settings);

            settings.Dispose();
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
