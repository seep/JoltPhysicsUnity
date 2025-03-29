using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_BoxShapeSettings> JPH_BoxShapeSettings_Create(float3 halfExtent, float convexRadius)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_BoxShapeSettings_Create(&halfExtent, convexRadius));
        }

        public static NativeHandle<JPH_BoxShape> JPH_BoxShapeSettings_CreateShape(NativeHandle<JPH_BoxShapeSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_BoxShapeSettings_CreateShape(settings));
        }
    }
}
