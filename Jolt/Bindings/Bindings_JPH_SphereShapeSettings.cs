namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_SphereShapeSettings> JPH_SphereShapeSettings_Create(float radius)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_SphereShapeSettings_Create(radius));
        }

        public static NativeHandle<JPH_SphereShape> JPH_SphereShapeSettings_CreateShape(NativeHandle<JPH_SphereShapeSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_SphereShapeSettings_CreateShape(settings));
        }

        public static float JPH_SphereShapeSettings_GetRadius(NativeHandle<JPH_SphereShapeSettings> settings)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SphereShapeSettings_GetRadius(settings);
        }

        public static void JPH_SphereShapeSettings_SetRadius(NativeHandle<JPH_SphereShapeSettings> settings, float radius)
        {
            AssertInitialized();

            UnsafeBindings.JPH_SphereShapeSettings_SetRadius(settings, radius);
        }
    }
}
