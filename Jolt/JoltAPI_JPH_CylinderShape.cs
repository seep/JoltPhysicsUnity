namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static NativeHandle<JPH_CylinderShape> JPH_CylinderShape_Create(float halfHeight, float radius)
        {
            return CreateHandle(Bindings.JPH_CylinderShape_Create(halfHeight, radius));
        }

        public static float JPH_CylinderShape_GetRadius(NativeHandle<JPH_CylinderShape> shape)
        {
            return Bindings.JPH_CylinderShape_GetRadius(GetPointer(shape));
        }

        public static float JPH_CylinderShape_GetHalfHeight(NativeHandle<JPH_CylinderShape> shape)
        {
            return Bindings.JPH_CylinderShape_GetHalfHeight(GetPointer(shape));
        }
    }
}
