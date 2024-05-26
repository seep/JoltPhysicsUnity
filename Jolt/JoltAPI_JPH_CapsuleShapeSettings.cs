namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static NativeHandle<JPH_CapsuleShapeSettings> JPH_CapsuleShapeSettings_Create(float halfHeightOfCylinder, float radius)
        {
            return CreateHandle(Bindings.JPH_CapsuleShapeSettings_Create(halfHeightOfCylinder, radius));
        }
    }
}
