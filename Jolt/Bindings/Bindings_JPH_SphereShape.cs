namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_SphereShape> JPH_SphereShape_Create(float radius)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_SphereShape_Create(radius));
        }

        public static float JPH_SphereShape_GetRadius(NativeHandle<JPH_SphereShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_SphereShape_GetRadius(shape);
        }
    }
}
