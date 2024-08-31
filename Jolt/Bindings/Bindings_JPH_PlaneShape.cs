using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_PlaneShape> JPH_PlaneShape_Create(Plane plane, float halfExtent)
        {
            // TODO include JPH_PhysicsMaterial argument
            
            return CreateHandle(UnsafeBindings.JPH_PlaneShape_Create(&plane, default, halfExtent));
        }

        public static Plane JPH_PlaneShape_GetPlane(NativeHandle<JPH_PlaneShape> shape)
        {
            Plane result = default;

            UnsafeBindings.JPH_PlaneShape_GetPlane(shape, &result);

            return result;
        }
        
        public static float JPH_PlaneShape_GetHalfExtent(NativeHandle<JPH_PlaneShape> shape)
        {
            return UnsafeBindings.JPH_PlaneShape_GetHalfExtent(shape);
        }
    }
}
