using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_HingeConstraintSettings> JPH_HingeConstraintSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_HingeConstraintSettings_Create());
        }

        public static rvec3 JPH_HingeConstraintSettings_GetPoint1(NativeHandle<JPH_HingeConstraintSettings> settings)
        {
            rvec3 result;
            UnsafeBindings.JPH_HingeConstraintSettings_GetPoint1(settings, &result);
            return result;
        }

        public static void JPH_HingeConstraintSettings_SetPoint1(NativeHandle<JPH_HingeConstraintSettings> settings, rvec3 value) 
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetPoint1(settings, &value);
        }

        public static rvec3 JPH_HingeConstraintSettings_GetPoint2(NativeHandle<JPH_HingeConstraintSettings> settings) 
        {
            rvec3 result;
            UnsafeBindings.JPH_HingeConstraintSettings_GetPoint2(settings, &result);
            return result;
        }

        public static void JPH_HingeConstraintSettings_SetPoint2(NativeHandle<JPH_HingeConstraintSettings> settings, rvec3 value) 
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetPoint2(settings, &value);
        }

        public static void JPH_HingeConstraintSettings_SetHingeAxis1(NativeHandle<JPH_HingeConstraintSettings> settings, float3 value) 
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetHingeAxis1(settings, &value);
        }

        public static float3 JPH_HingeConstraintSettings_GetHingeAxis1(NativeHandle<JPH_HingeConstraintSettings> settings) 
        {
            float3 result;
            UnsafeBindings.JPH_HingeConstraintSettings_GetHingeAxis1(settings, &result);
            return result;
        }

        public static void JPH_HingeConstraintSettings_SetNormalAxis1(NativeHandle<JPH_HingeConstraintSettings> settings, float3 value) 
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetNormalAxis1(settings, &value);
        }

        public static float3 JPH_HingeConstraintSettings_GetNormalAxis1(NativeHandle<JPH_HingeConstraintSettings> settings) 
        {
            float3 result;
            UnsafeBindings.JPH_HingeConstraintSettings_GetNormalAxis1(settings, &result);
            return result;
        }

        public static void JPH_HingeConstraintSettings_SetHingeAxis2(NativeHandle<JPH_HingeConstraintSettings> settings, float3 value) 
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetHingeAxis2(settings, &value);
        }

        public static float3 JPH_HingeConstraintSettings_GetHingeAxis2(NativeHandle<JPH_HingeConstraintSettings> settings) 
        {
            float3 result;
            UnsafeBindings.JPH_HingeConstraintSettings_GetHingeAxis2(settings, &result);
            return result;
        }

        public static void JPH_HingeConstraintSettings_SetNormalAxis2(NativeHandle<JPH_HingeConstraintSettings> settings, float3 value)
        {
            UnsafeBindings.JPH_HingeConstraintSettings_SetNormalAxis2(settings, &value);
        }

        public static float3 JPH_HingeConstraintSettings_GetNormalAxis2(NativeHandle<JPH_HingeConstraintSettings> settings) 
        {
            float3 result;
            UnsafeBindings.JPH_HingeConstraintSettings_GetNormalAxis2(settings, &result);
            return result;
        }

        public static NativeHandle<JPH_HingeConstraint> JPH_HingeConstraintSettings_CreateConstraint(NativeHandle<JPH_HingeConstraintSettings> settings, NativeHandle<JPH_Body> bodyA, NativeHandle<JPH_Body> bodyB)
        {
            return CreateHandle(UnsafeBindings.JPH_HingeConstraintSettings_CreateConstraint(settings, bodyA, bodyB));
        }
    }
}