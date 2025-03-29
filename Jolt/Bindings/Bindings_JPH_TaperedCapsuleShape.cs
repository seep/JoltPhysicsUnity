namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static float JPH_TaperedCapsuleShape_GetTopRadius(NativeHandle<JPH_TaperedCapsuleShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_TaperedCapsuleShape_GetTopRadius(shape);
        }

        public static float JPH_TaperedCapsuleShape_GetBottomRadius(NativeHandle<JPH_TaperedCapsuleShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_TaperedCapsuleShape_GetBottomRadius(shape);
        }

        public static float JPH_TaperedCapsuleShape_GetHalfHeight(NativeHandle<JPH_TaperedCapsuleShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_TaperedCapsuleShape_GetHalfHeight(shape);
        }
    }
}
