using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static AllowedDOFs JPH_MotionProperties_GetAllowedDOFs(NativeHandle<JPH_MotionProperties> properties)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_MotionProperties_GetAllowedDOFs(properties);
        }

        public static void JPH_MotionProperties_SetLinearDamping(NativeHandle<JPH_MotionProperties> properties, float damping)
        {
            AssertInitialized();

            UnsafeBindings.JPH_MotionProperties_SetLinearDamping(properties, damping);
        }

        public static float JPH_MotionProperties_GetLinearDamping(NativeHandle<JPH_MotionProperties> properties)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_MotionProperties_GetLinearDamping(properties);
        }

        public static void JPH_MotionProperties_SetAngularDamping(NativeHandle<JPH_MotionProperties> properties, float damping)
        {
            AssertInitialized();

            UnsafeBindings.JPH_MotionProperties_SetAngularDamping(properties, damping);
        }

        public static float JPH_MotionProperties_GetAngularDamping(NativeHandle<JPH_MotionProperties> properties)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_MotionProperties_GetAngularDamping(properties);
        }

        public static void JPH_MotionProperties_SetMassProperties(NativeHandle<JPH_MotionProperties> properties, AllowedDOFs allowedDOFs, MassProperties massProperties)
        {
            AssertInitialized();

            UnsafeBindings.JPH_MotionProperties_SetMassProperties(properties, allowedDOFs, (JPH_MassProperties*)&massProperties);
        }

        public static float JPH_MotionProperties_GetInverseMassUnchecked(NativeHandle<JPH_MotionProperties> properties)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_MotionProperties_GetInverseMassUnchecked(properties);
        }

        public static void JPH_MotionProperties_SetInverseMass(NativeHandle<JPH_MotionProperties> properties, float inverseMass)
        {
            AssertInitialized();

            UnsafeBindings.JPH_MotionProperties_SetInverseMass(properties, inverseMass);
        }

        public static float3 JPH_MotionProperties_GetInverseInertiaDiagonal(NativeHandle<JPH_MotionProperties> properties)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_MotionProperties_GetInverseInertiaDiagonal(properties, &result);
            return result;
        }

        public static quaternion JPH_MotionProperties_GetInertiaRotation(NativeHandle<JPH_MotionProperties> properties)
        {
            AssertInitialized();

            quaternion result;
            UnsafeBindings.JPH_MotionProperties_GetInertiaRotation(properties, &result);
            return result;
        }

        public static void JPH_MotionProperties_SetInverseInertia(NativeHandle<JPH_MotionProperties> properties, float3 diagonal, quaternion rotation)
        {
            AssertInitialized();

            UnsafeBindings.JPH_MotionProperties_SetInverseInertia(properties, &diagonal, &rotation);
        }
    }
}
