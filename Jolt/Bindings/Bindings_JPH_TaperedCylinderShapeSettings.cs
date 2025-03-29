namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_TaperedCylinderShapeSettings> JPH_TaperedCylinderShapeSettings_Create(float halfHeightOfTaperedCylinder, float topRadius, float bottomRadius, float convexRadius, NativeHandle<JPH_PhysicsMaterial> material)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_TaperedCylinderShapeSettings_Create(halfHeightOfTaperedCylinder, topRadius, bottomRadius, convexRadius, material));
        }

        public static NativeHandle<JPH_TaperedCylinderShape> JPH_TaperedCylinderShapeSettings_CreateShape(NativeHandle<JPH_TaperedCylinderShapeSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_TaperedCylinderShapeSettings_CreateShape(settings));
        }
    }
}
