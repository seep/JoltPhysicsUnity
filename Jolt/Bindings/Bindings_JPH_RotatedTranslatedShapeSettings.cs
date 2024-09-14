using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_RotatedTranslatedShapeSettings> JPH_RotatedTranslatedShapeSettings_Create(float3 position, quaternion rotation, NativeHandle<JPH_ShapeSettings> settings)
        {
            return CreateHandle(UnsafeBindings.JPH_RotatedTranslatedShapeSettings_Create(&position, &rotation, settings));
        }

        public static NativeHandle<JPH_RotatedTranslatedShapeSettings> JPH_RotatedTranslatedShapeSettings_Create(float3 position, quaternion rotation, NativeHandle<JPH_Shape> shape)
        {
            return CreateHandle(UnsafeBindings.JPH_RotatedTranslatedShapeSettings_Create2(&position, &rotation, shape));
        }

        public static NativeHandle<JPH_RotatedTranslatedShape> JPH_RotatedTranslatedShapeSettings_CreateShape(NativeHandle<JPH_RotatedTranslatedShapeSettings> settings)
        {
            return CreateHandle(UnsafeBindings.JPH_RotatedTranslatedShapeSettings_CreateShape(settings));
        }
    }
}
