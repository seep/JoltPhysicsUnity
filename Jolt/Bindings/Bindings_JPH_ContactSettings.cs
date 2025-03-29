using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static float JPH_ContactSettings_GetFriction(NativeHandle<JPH_ContactSettings> settings)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ContactSettings_GetFriction(settings);
        }

        public static void JPH_ContactSettings_SetFriction(NativeHandle<JPH_ContactSettings> settings, float friction)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ContactSettings_SetFriction(settings, friction);
        }

        public static float JPH_ContactSettings_GetRestitution(NativeHandle<JPH_ContactSettings> settings)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ContactSettings_GetRestitution(settings);
        }

        public static void JPH_ContactSettings_SetRestitution(NativeHandle<JPH_ContactSettings> settings, float restitution)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ContactSettings_SetRestitution(settings, restitution);
        }

        public static float JPH_ContactSettings_GetInvMassScale1(NativeHandle<JPH_ContactSettings> settings)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ContactSettings_GetInvMassScale1(settings);
        }

        public static void JPH_ContactSettings_SetInvMassScale1(NativeHandle<JPH_ContactSettings> settings, float scale)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ContactSettings_SetInvMassScale1(settings, scale);
        }

        public static float JPH_ContactSettings_GetInvInertiaScale1(NativeHandle<JPH_ContactSettings> settings)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ContactSettings_GetInvInertiaScale1(settings);
        }

        public static void JPH_ContactSettings_SetInvInertiaScale1(NativeHandle<JPH_ContactSettings> settings, float scale)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ContactSettings_SetInvInertiaScale1(settings, scale);
        }

        public static float JPH_ContactSettings_GetInvMassScale2(NativeHandle<JPH_ContactSettings> settings)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ContactSettings_GetInvMassScale2(settings);
        }

        public static void JPH_ContactSettings_SetInvMassScale2(NativeHandle<JPH_ContactSettings> settings, float scale)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ContactSettings_SetInvMassScale2(settings, scale);
        }

        public static float JPH_ContactSettings_GetInvInertiaScale2(NativeHandle<JPH_ContactSettings> settings)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ContactSettings_GetInvInertiaScale2(settings);
        }

        public static void JPH_ContactSettings_SetInvInertiaScale2(NativeHandle<JPH_ContactSettings> settings, float scale)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ContactSettings_SetInvInertiaScale2(settings, scale);
        }

        public static bool JPH_ContactSettings_GetIsSensor(NativeHandle<JPH_ContactSettings> settings)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ContactSettings_GetIsSensor(settings);
        }

        public static void JPH_ContactSettings_SetIsSensor(NativeHandle<JPH_ContactSettings> settings, bool sensor)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ContactSettings_SetIsSensor(settings, sensor);
        }

        public static float3 JPH_ContactSettings_GetRelativeLinearSurfaceVelocity(NativeHandle<JPH_ContactSettings> settings)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_ContactSettings_GetRelativeLinearSurfaceVelocity(settings, &result);
            return result;
        }

        public static void JPH_ContactSettings_SetRelativeLinearSurfaceVelocity(NativeHandle<JPH_ContactSettings> settings, float3 velocity)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ContactSettings_SetRelativeLinearSurfaceVelocity(settings, &velocity);
        }

        public static float3 JPH_ContactSettings_GetRelativeAngularSurfaceVelocity(NativeHandle<JPH_ContactSettings> settings)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_ContactSettings_GetRelativeAngularSurfaceVelocity(settings, &result);
            return result;
        }

        public static void JPH_ContactSettings_SetRelativeAngularSurfaceVelocity(NativeHandle<JPH_ContactSettings> settings, float3 velocity)
        {
            AssertInitialized();

            UnsafeBindings.JPH_ContactSettings_SetRelativeAngularSurfaceVelocity(settings, &velocity);
        }
    }
}
