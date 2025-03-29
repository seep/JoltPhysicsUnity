namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_CylinderShape> JPH_CylinderShape_Create(float halfHeight, float radius)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_CylinderShape_Create(halfHeight, radius));
        }

        public static float JPH_CylinderShape_GetRadius(NativeHandle<JPH_CylinderShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_CylinderShape_GetRadius(shape);
        }

        public static float JPH_CylinderShape_GetHalfHeight(NativeHandle<JPH_CylinderShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_CylinderShape_GetHalfHeight(shape);
        }
    }
}
