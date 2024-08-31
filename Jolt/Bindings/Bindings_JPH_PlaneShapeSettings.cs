using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_PlaneShapeSettings> JPH_PlaneShapeSettings_Create(Plane plane, float halfExtent)
        {
            // TODO include JPH_PhysicsMaterial argument
            
            return CreateHandle(UnsafeBindings.JPH_PlaneShapeSettings_Create(&plane, default, halfExtent));
        }

        public static NativeHandle<JPH_PlaneShape> JPH_PlaneShapeSettings_CreateShape(NativeHandle<JPH_PlaneShapeSettings> settings)
        {
            return CreateHandle(UnsafeBindings.JPH_PlaneShapeSettings_CreateShape(settings));
        }
    }
}
