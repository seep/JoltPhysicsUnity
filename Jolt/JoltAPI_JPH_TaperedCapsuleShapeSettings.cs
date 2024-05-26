namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static NativeHandle<JPH_TaperedCapsuleShapeSettings> JPH_TaperedCapsuleShapeSettings_Create(float halfHeightOfTaperedCylinder, float topRadius, float bottomRadius)
        {
            return CreateHandle(Bindings.JPH_TaperedCapsuleShapeSettings_Create(halfHeightOfTaperedCylinder, topRadius, bottomRadius));
        }
    }
}
