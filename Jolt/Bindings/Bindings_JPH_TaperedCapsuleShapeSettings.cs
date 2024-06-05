namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_TaperedCapsuleShapeSettings> JPH_TaperedCapsuleShapeSettings_Create(float halfHeightOfTaperedCylinder, float topRadius, float bottomRadius)
        {
            return CreateHandle(UnsafeBindings.JPH_TaperedCapsuleShapeSettings_Create(halfHeightOfTaperedCylinder, topRadius, bottomRadius));
        }
    }
}
