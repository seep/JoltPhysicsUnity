namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static NativeHandle<JPH_SphereShape> JPH_SphereShape_Create(float radius)
        {
            return CreateHandle(Bindings.JPH_SphereShape_Create(radius));
        }

        public static float JPH_SphereShape_GetRadius(NativeHandle<JPH_SphereShape> shape)
        {
            return Bindings.JPH_SphereShape_GetRadius(GetPointer(shape));
        }
    }
}
