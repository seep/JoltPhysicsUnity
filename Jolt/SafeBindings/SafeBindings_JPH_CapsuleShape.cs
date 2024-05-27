namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static NativeHandle<JPH_CapsuleShape> JPH_CapsuleShape_Create(float halfHeightOfCylinder, float radius)
        {
            return CreateHandle(Bindings.JPH_CapsuleShape_Create(halfHeightOfCylinder, radius));
        }

        public static float JPH_CapsuleShape_GetRadius(NativeHandle<JPH_CapsuleShape> shape)
        {
            return Bindings.JPH_CapsuleShape_GetRadius(shape);
        }

        public static float JPH_CapsuleShape_GetHalfHeightOfCylinder(NativeHandle<JPH_CapsuleShape> shape)
        {
            return Bindings.JPH_CapsuleShape_GetHalfHeightOfCylinder(shape);
        }
    }
}
