using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_Shape_Destroy<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            UnsafeBindings.JPH_Shape_Destroy(shape.Reinterpret<JPH_Shape>());

            shape.Dispose();
        }

        public static ShapeType JPH_Shape_GetType<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return UnsafeBindings.JPH_Shape_GetType(shape.Reinterpret<JPH_Shape>());
        }

        public static ShapeSubType JPH_Shape_GetSubType<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return UnsafeBindings.JPH_Shape_GetSubType(shape.Reinterpret<JPH_Shape>());
        }

        public static ulong JPH_Shape_GetUserData<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return UnsafeBindings.JPH_Shape_GetUserData(shape.Reinterpret<JPH_Shape>());
        }

        public static void JPH_Shape_SetUserData<T>(NativeHandle<T> shape, ulong userData) where T : unmanaged, INativeShape
        {
            UnsafeBindings.JPH_Shape_SetUserData(shape.Reinterpret<JPH_Shape>(), userData);
        }

        public static bool JPH_Shape_MustBeStatic<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return UnsafeBindings.JPH_Shape_MustBeStatic(shape.Reinterpret<JPH_Shape>());
        }

        public static float3 JPH_Shape_GetCenterOfMass<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            float3 result;

            UnsafeBindings.JPH_Shape_GetCenterOfMass(shape.Reinterpret<JPH_Shape>(), &result);

            return result;
        }

        public static AABox JPH_Shape_GetLocalBounds<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            AABox result;

            UnsafeBindings.JPH_Shape_GetLocalBounds(shape.Reinterpret<JPH_Shape>(), &result);

            return result;
        }

        public static AABox JPH_Shape_GetWorldSpaceBounds<T>(NativeHandle<T> shape, rmatrix4x4 centerOfMassTransform, float3 scale) where T : unmanaged, INativeShape
        {
            AABox result;

            UnsafeBindings.JPH_Shape_GetWorldSpaceBounds(shape.Reinterpret<JPH_Shape>(), &centerOfMassTransform, &scale, &result);

            return result;
        }

        public static float JPH_Shape_GetInnerRadius<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return UnsafeBindings.JPH_Shape_GetInnerRadius(shape.Reinterpret<JPH_Shape>());
        }

        public static MassProperties JPH_Shape_GetMassProperties<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            MassProperties result;

            UnsafeBindings.JPH_Shape_GetMassProperties(shape.Reinterpret<JPH_Shape>(), &result);

            return result;
        }

        public static float3 JPH_Shape_GetSurfaceNormal<T>(NativeHandle<T> shape, uint subShapeID, float3 localPosition) where T : unmanaged, INativeShape
        {
            float3 result;

            UnsafeBindings.JPH_Shape_GetSurfaceNormal(shape.Reinterpret<JPH_Shape>(), subShapeID, &localPosition, &result);

            return result;
        }

        public static float JPH_Shape_GetVolume<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return UnsafeBindings.JPH_Shape_GetVolume(shape.Reinterpret<JPH_Shape>());
        }
    }
}
