using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_CompoundShapeSettings_AddShape(NativeHandle<JPH_CompoundShapeSettings> handle, float3 position, quaternion rotation, NativeHandle<JPH_ShapeSettings> settings, uint userData = 0)
        {
            AssertInitialized();

            UnsafeBindings.JPH_CompoundShapeSettings_AddShape(handle, &position, &rotation, settings, userData);
        }

        public static void JPH_CompoundShapeSettings_AddShape(NativeHandle<JPH_CompoundShapeSettings> settings, float3 position, quaternion rotation, NativeHandle<JPH_Shape> shape, uint userData = 0)
        {
            AssertInitialized();

            UnsafeBindings.JPH_CompoundShapeSettings_AddShape2(settings, &position, &rotation, shape, userData);
        }

        public static NativeHandle<JPH_StaticCompoundShapeSettings> JPH_StaticCompoundShapeSettings_Create()
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_StaticCompoundShapeSettings_Create());
        }

        public static NativeHandle<JPH_MutableCompoundShapeSettings> JPH_MutableCompoundShapeSettings_Create()
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_MutableCompoundShapeSettings_Create());
        }

        public static NativeHandle<JPH_MutableCompoundShape> JPH_MutableCompoundShape_Create(NativeHandle<JPH_MutableCompoundShapeSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_MutableCompoundShape_Create(settings));
        }
    }
}
