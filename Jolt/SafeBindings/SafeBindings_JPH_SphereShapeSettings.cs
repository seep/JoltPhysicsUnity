namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static NativeHandle<JPH_SphereShapeSettings> JPH_SphereShapeSettings_Create(float radius)
        {
            return CreateHandle(Bindings.JPH_SphereShapeSettings_Create(radius));
        }

        public static NativeHandle<JPH_SphereShape> JPH_SphereShapeSettings_CreateShape(NativeHandle<JPH_SphereShapeSettings> settings)
        {
            return CreateHandle(Bindings.JPH_SphereShapeSettings_CreateShape(GetPointer(settings)));
        }

        public static float JPH_SphereShapeSettings_GetRadius(NativeHandle<JPH_SphereShapeSettings> settings)
        {
            return Bindings.JPH_SphereShapeSettings_GetRadius(GetPointer(settings));
        }

        public static void JPH_SphereShapeSettings_SetRadius(NativeHandle<JPH_SphereShapeSettings> settings, float radius)
        {
            Bindings.JPH_SphereShapeSettings_SetRadius(GetPointer(settings), radius);
        }
    }
}
