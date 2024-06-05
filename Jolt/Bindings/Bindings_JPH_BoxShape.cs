using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_BoxShape> JPH_BoxShape_Create(float3 halfExtent, float convexRadius)
        {
            return CreateHandle(UnsafeBindings.JPH_BoxShape_Create(&halfExtent, convexRadius));
        }

        public static float3 JPH_BoxShape_GetHalfExtent(NativeHandle<JPH_BoxShape> shape)
        {
            float3 result = default;

            UnsafeBindings.JPH_BoxShape_GetHalfExtent(shape, &result);

            return result;
        }

        public static float JPH_BoxShape_GetVolume(NativeHandle<JPH_BoxShape> shape)
        {
            return UnsafeBindings.JPH_BoxShape_GetVolume(shape);
        }

        public static float JPH_BoxShape_GetConvexRadius(NativeHandle<JPH_BoxShape> shape)
        {
            return UnsafeBindings.JPH_BoxShape_GetConvexRadius(shape);
        }
    }
}
