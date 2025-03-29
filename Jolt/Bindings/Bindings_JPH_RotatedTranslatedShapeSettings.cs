using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_RotatedTranslatedShapeSettings> JPH_RotatedTranslatedShapeSettings_Create(float3 position, quaternion rotation, NativeHandle<JPH_ShapeSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_RotatedTranslatedShapeSettings_Create(&position, &rotation, settings));
        }

        public static NativeHandle<JPH_RotatedTranslatedShapeSettings> JPH_RotatedTranslatedShapeSettings_Create(float3 position, quaternion rotation, NativeHandle<JPH_Shape> shape)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_RotatedTranslatedShapeSettings_Create2(&position, &rotation, shape));
        }

        public static NativeHandle<JPH_RotatedTranslatedShape> JPH_RotatedTranslatedShapeSettings_CreateShape(NativeHandle<JPH_RotatedTranslatedShapeSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_RotatedTranslatedShapeSettings_CreateShape(settings));
        }
    }
}
