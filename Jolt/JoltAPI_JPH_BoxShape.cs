using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static NativeHandle<JPH_BoxShape> JPH_BoxShape_Create(float3 halfExtent, float convexRadius)
        {
            return CreateHandle(Bindings.JPH_BoxShape_Create(&halfExtent, convexRadius));
        }

        public static float3 JPH_BoxShape_GetHalfExtent(NativeHandle<JPH_BoxShape> shape)
        {
            float3 result = default;

            Bindings.JPH_BoxShape_GetHalfExtent(GetPointer(shape), &result);

            return result;
        }

        public static float JPH_BoxShape_GetVolume(NativeHandle<JPH_BoxShape> shape)
        {
            return Bindings.JPH_BoxShape_GetVolume(GetPointer(shape));
        }

        public static float JPH_BoxShape_GetConvexRadius(NativeHandle<JPH_BoxShape> shape)
        {
            return Bindings.JPH_BoxShape_GetConvexRadius(GetPointer(shape));
        }
    }
}
