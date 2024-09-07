using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_SliderConstraintSettings> JPH_SliderConstraintSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_SliderConstraintSettings_Create());
        }

        public static void JPH_SliderConstraintSettings_SetSliderAxis(NativeHandle<JPH_SliderConstraintSettings> settings, float3 axis)
        {
            UnsafeBindings.JPH_SliderConstraintSettings_SetSliderAxis(settings, &axis);
        }

        public static bool JPH_SliderConstraintSettings_GetAutoDetectPoint(NativeHandle<JPH_SliderConstraintSettings> settings)
        {
            return UnsafeBindings.JPH_SliderConstraintSettings_GetAutoDetectPoint(settings);
        }

        public static void JPH_SliderConstraintSettings_SetAutoDetectPoint(NativeHandle<JPH_SliderConstraintSettings> settings, bool value)
        {
            UnsafeBindings.JPH_SliderConstraintSettings_SetAutoDetectPoint(settings, value);
        }

        public static rvec3 JPH_SliderConstraintSettings_GetPoint1(NativeHandle<JPH_SliderConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_SliderConstraintSettings_GetPoint1(settings, &result);
            return result;
        }

        public static void JPH_SliderConstraintSettings_SetPoint1(NativeHandle<JPH_SliderConstraintSettings> settings, rvec3 value)
        {
            UnsafeBindings.JPH_SliderConstraintSettings_SetPoint1(settings, &value);
        }

        public static rvec3 JPH_SliderConstraintSettings_GetPoint2(NativeHandle<JPH_SliderConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_SliderConstraintSettings_GetPoint2(settings, &result);
            return result;
        }

        public static void JPH_SliderConstraintSettings_SetPoint2(NativeHandle<JPH_SliderConstraintSettings> settings, rvec3 value) 
        {
            UnsafeBindings.JPH_SliderConstraintSettings_SetPoint2(settings, &value);
        }

        public static void JPH_SliderConstraintSettings_SetSliderAxis1(NativeHandle<JPH_SliderConstraintSettings> settings, float3 value) 
        {
            UnsafeBindings.JPH_SliderConstraintSettings_SetSliderAxis1(settings, &value);
        }

        public static float3 JPH_SliderConstraintSettings_GetSliderAxis1(NativeHandle<JPH_SliderConstraintSettings> settings) 
        {
            float3 result;
            UnsafeBindings.JPH_SliderConstraintSettings_GetSliderAxis1(settings, &result);
            return result;
        }

        public static void JPH_SliderConstraintSettings_SetNormalAxis1(NativeHandle<JPH_SliderConstraintSettings> settings, float3 value) 
        {
            UnsafeBindings.JPH_SliderConstraintSettings_SetNormalAxis1(settings, &value);
        }

        public static float3 JPH_SliderConstraintSettings_GetNormalAxis1(NativeHandle<JPH_SliderConstraintSettings> settings) 
        {
            float3 result;
            UnsafeBindings.JPH_SliderConstraintSettings_GetNormalAxis1(settings, &result);
            return result;
        }

        public static void JPH_SliderConstraintSettings_SetSliderAxis2(NativeHandle<JPH_SliderConstraintSettings> settings, float3 value) 
        {
            UnsafeBindings.JPH_SliderConstraintSettings_SetSliderAxis2(settings, &value);
        }

        public static float3 JPH_SliderConstraintSettings_GetSliderAxis2(NativeHandle<JPH_SliderConstraintSettings> settings) 
        {
            float3 result;
            UnsafeBindings.JPH_SliderConstraintSettings_GetSliderAxis2(settings, &result);
            return result;
        }

        public static void JPH_SliderConstraintSettings_SetNormalAxis2(NativeHandle<JPH_SliderConstraintSettings> settings, float3 value) 
        {
            UnsafeBindings.JPH_SliderConstraintSettings_SetNormalAxis2(settings, &value);
        }

        public static float3 JPH_SliderConstraintSettings_GetNormalAxis2(NativeHandle<JPH_SliderConstraintSettings> settings) 
        {
            float3 result;
            UnsafeBindings.JPH_SliderConstraintSettings_GetNormalAxis2(settings, &result);
            return result;
        }

        public static NativeHandle<JPH_SliderConstraint> JPH_SliderConstraintSettings_CreateConstraint(NativeHandle<JPH_SliderConstraintSettings> settings, NativeHandle<JPH_Body> bodyA, NativeHandle<JPH_Body> bodyB)
        {
            return CreateHandle(UnsafeBindings.JPH_SliderConstraintSettings_CreateConstraint(settings, bodyA, bodyB));
        }

    }
}