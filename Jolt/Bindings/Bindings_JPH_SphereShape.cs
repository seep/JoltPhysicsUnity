namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_SphereShape> JPH_SphereShape_Create(float radius)
        {
            return CreateHandle(UnsafeBindings.JPH_SphereShape_Create(radius));
        }

        public static float JPH_SphereShape_GetRadius(NativeHandle<JPH_SphereShape> shape)
        {
            return UnsafeBindings.JPH_SphereShape_GetRadius(shape);
        }
    }
}
