using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static NativeHandle<JPH_BoxShapeSettings> JPH_BoxShapeSettings_Create(float3 halfExtent, float convexRadius)
        {
            return CreateHandle(Bindings.JPH_BoxShapeSettings_Create(&halfExtent, convexRadius));
        }

        public static NativeHandle<JPH_BoxShape> JPH_BoxShapeSettings_CreateShape(NativeHandle<JPH_BoxShapeSettings> settings)
        {
            return CreateHandle(Bindings.JPH_BoxShapeSettings_CreateShape(GetPointer(settings)));
        }
    }
}
