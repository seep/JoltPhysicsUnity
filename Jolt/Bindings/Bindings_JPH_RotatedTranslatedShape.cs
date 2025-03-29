using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_RotatedTranslatedShape> JPH_RotatedTranslatedShape_Create(float3 position, quaternion rotation, NativeHandle<JPH_Shape> shape)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_RotatedTranslatedShape_Create(&position, &rotation, shape));
        }
    }
}
