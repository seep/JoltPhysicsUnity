namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_TaperedCapsuleShapeSettings> JPH_TaperedCapsuleShapeSettings_Create(float halfHeightOfTaperedCylinder, float topRadius, float bottomRadius)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_TaperedCapsuleShapeSettings_Create(halfHeightOfTaperedCylinder, topRadius, bottomRadius));
        }

        public static NativeHandle<JPH_TaperedCapsuleShape> JPH_TaperedCapsuleShapeSettings_CreateShape(NativeHandle<JPH_TaperedCapsuleShapeSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_TaperedCapsuleShapeSettings_CreateShape(settings));
        }
    }
}
