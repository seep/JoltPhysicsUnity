namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_CapsuleShape> JPH_CapsuleShape_Create(float halfHeightOfCylinder, float radius)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_CapsuleShape_Create(halfHeightOfCylinder, radius));
        }

        public static float JPH_CapsuleShape_GetRadius(NativeHandle<JPH_CapsuleShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_CapsuleShape_GetRadius(shape);
        }

        public static float JPH_CapsuleShape_GetHalfHeightOfCylinder(NativeHandle<JPH_CapsuleShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_CapsuleShape_GetHalfHeightOfCylinder(shape);
        }
    }
}
