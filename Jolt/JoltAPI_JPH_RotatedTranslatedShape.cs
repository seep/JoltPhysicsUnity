using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static NativeHandle<JPH_RotatedTranslatedShape> JPH_RotatedTranslatedShape_Create(float3 position, quaternion rotation, NativeHandle<JPH_Shape> shape)
        {
            return CreateHandle(Bindings.JPH_RotatedTranslatedShape_Create(&position, &rotation, GetPointer(shape)));
        }
    }
}