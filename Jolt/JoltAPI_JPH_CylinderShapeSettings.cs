namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static NativeHandle<JPH_CylinderShapeSettings> JPH_CylinderShapeSettings_Create(float halfHeight, float radius, float convexRadius)
        {
            return CreateHandle(Bindings.JPH_CylinderShapeSettings_Create(halfHeight, radius, convexRadius));
        }
    }
}
