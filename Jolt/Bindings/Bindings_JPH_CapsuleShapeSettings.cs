namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_CapsuleShapeSettings> JPH_CapsuleShapeSettings_Create(float halfHeightOfCylinder, float radius)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_CapsuleShapeSettings_Create(halfHeightOfCylinder, radius));
        }

        public static NativeHandle<JPH_CapsuleShape> JPH_CapsuleShapeSettings_CreateShape(NativeHandle<JPH_CapsuleShapeSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_CapsuleShapeSettings_CreateShape(settings));
        }
    }
}
