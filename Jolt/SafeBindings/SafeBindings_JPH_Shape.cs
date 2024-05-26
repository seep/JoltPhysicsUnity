using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static void JPH_Shape_Destroy<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            Bindings.JPH_Shape_Destroy((JPH_Shape*)GetPointer(shape));

            shape.Dispose();
        }

        public static ShapeType JPH_Shape_GetType<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return Bindings.JPH_Shape_GetType((JPH_Shape*)GetPointer(shape));
        }

        public static ShapeSubType JPH_Shape_GetSubType<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return Bindings.JPH_Shape_GetSubType((JPH_Shape*)GetPointer(shape));
        }

        public static ulong JPH_Shape_GetUserData<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return Bindings.JPH_Shape_GetUserData((JPH_Shape*)GetPointer(shape));
        }

        public static void JPH_Shape_SetUserData<T>(NativeHandle<T> shape, ulong userData) where T : unmanaged, INativeShape
        {
            Bindings.JPH_Shape_SetUserData((JPH_Shape*)GetPointer(shape), userData);
        }

        public static bool JPH_Shape_MustBeStatic<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return Bindings.JPH_Shape_MustBeStatic((JPH_Shape*)GetPointer(shape));
        }

        public static float3 JPH_Shape_GetCenterOfMass<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            float3 result = default;

            Bindings.JPH_Shape_GetCenterOfMass((JPH_Shape*)GetPointer(shape), &result);

            return result;
        }

        public static AABox JPH_Shape_GetLocalBounds<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            AABox result;

            Bindings.JPH_Shape_GetLocalBounds((JPH_Shape*)GetPointer(shape), &result);

            return result;
        }

        public static AABox JPH_Shape_GetWorldSpaceBounds<T>(NativeHandle<T> shape, rmatrix4x4 centerOfMassTransform, float3 scale) where T : unmanaged, INativeShape
        {
            AABox result;

            Bindings.JPH_Shape_GetWorldSpaceBounds((JPH_Shape*)GetPointer(shape), &centerOfMassTransform, &scale, &result);

            return result;
        }

        public static float JPH_Shape_GetInnerRadius<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return Bindings.JPH_Shape_GetInnerRadius((JPH_Shape*)GetPointer(shape));
        }

        public static MassProperties JPH_Shape_GetMassProperties<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            MassProperties result;

            Bindings.JPH_Shape_GetMassProperties((JPH_Shape*)GetPointer(shape), &result);

            return result;
        }

        public static float3 JPH_Shape_GetSurfaceNormal<T>(NativeHandle<T> shape, uint subShapeID, float3 localPosition) where T : unmanaged, INativeShape
        {
            float3 result;

            Bindings.JPH_Shape_GetSurfaceNormal((JPH_Shape*)GetPointer(shape), subShapeID, &localPosition, &result);

            return result;
        }

        public static float JPH_Shape_GetVolume<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return Bindings.JPH_Shape_GetVolume((JPH_Shape*)GetPointer(shape));
        }
    }
}
