namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_CylinderShapeSettings> JPH_CylinderShapeSettings_Create(float halfHeight, float radius, float convexRadius)
        {
            return CreateHandle(UnsafeBindings.JPH_CylinderShapeSettings_Create(halfHeight, radius, convexRadius));
        }
    }
}
