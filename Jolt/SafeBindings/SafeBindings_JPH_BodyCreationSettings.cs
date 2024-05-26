using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create()
        {
            return CreateHandle(Bindings.JPH_BodyCreationSettings_Create());
        }

        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create2<T>(NativeHandle<T> settings, rvec3 position, quaternion rotation, MotionType motion, ushort layer) where T : unmanaged, INativeShapeSettings
        {
            return CreateHandle(Bindings.JPH_BodyCreationSettings_Create2((JPH_ShapeSettings*)GetPointer(settings), &position, &rotation, motion, layer));
        }

        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create3<T>(NativeHandle<T> shape, rvec3 position, quaternion rotation, MotionType motion, ushort layer) where T : unmanaged, INativeShape
        {
            return CreateHandle(Bindings.JPH_BodyCreationSettings_Create3((JPH_Shape*)GetPointer(shape), &position, &rotation, motion, layer));
        }

        public static void JPH_BodyCreationSettings_Destroy(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            Bindings.JPH_BodyCreationSettings_Destroy(GetPointer(settings));

            settings.Dispose();
        }

        public static float3 JPH_BodyCreationSettings_GetLinearVelocity(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            float3 result;

            Bindings.JPH_BodyCreationSettings_GetLinearVelocity(GetPointer(settings), &result);

            return result;
        }

        public static void JPH_BodyCreationSettings_SetLinearVelocity(NativeHandle<JPH_BodyCreationSettings> settings, float3 velocity)
        {
            Bindings.JPH_BodyCreationSettings_SetLinearVelocity(GetPointer(settings), &velocity);
        }

        public static float3 JPH_BodyCreationSettings_GetAngularVelocity(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            float3 result;

            Bindings.JPH_BodyCreationSettings_GetAngularVelocity(GetPointer(settings), &result);

            return result;
        }

        public static void JPH_BodyCreationSettings_SetAngularVelocity(NativeHandle<JPH_BodyCreationSettings> settings, float3 velocity)
        {
            Bindings.JPH_BodyCreationSettings_SetAngularVelocity(GetPointer(settings), &velocity);
        }

        public static MotionType JPH_BodyCreationSettings_GetMotionType(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return Bindings.JPH_BodyCreationSettings_GetMotionType(GetPointer(settings));
        }

        public static void JPH_BodyCreationSettings_SetMotionType(NativeHandle<JPH_BodyCreationSettings> settings, MotionType value)
        {
            Bindings.JPH_BodyCreationSettings_SetMotionType(GetPointer(settings), value);
        }

        public static AllowedDOFs JPH_BodyCreationSettings_GetAllowedDOFs(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return Bindings.JPH_BodyCreationSettings_GetAllowedDOFs(GetPointer(settings));
        }

        public static void JPH_BodyCreationSettings_SetAllowedDOFs(NativeHandle<JPH_BodyCreationSettings> settings, AllowedDOFs value)
        {
            Bindings.JPH_BodyCreationSettings_SetAllowedDOFs(GetPointer(settings), value);
        }
    }
}
