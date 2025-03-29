namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static float JPH_TaperedCylinderShape_GetTopRadius(NativeHandle<JPH_TaperedCylinderShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_TaperedCylinderShape_GetTopRadius(shape);
        }

        public static float JPH_TaperedCylinderShape_GetBottomRadius(NativeHandle<JPH_TaperedCylinderShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_TaperedCylinderShape_GetBottomRadius(shape);
        }

        public static float JPH_TaperedCylinderShape_GetConvexRadius(NativeHandle<JPH_TaperedCylinderShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_TaperedCylinderShape_GetConvexRadius(shape);
        }

        public static float JPH_TaperedCylinderShape_GetHalfHeight(NativeHandle<JPH_TaperedCylinderShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_TaperedCylinderShape_GetHalfHeight(shape);
        }
    }
}
