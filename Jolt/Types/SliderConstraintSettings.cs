using System.Runtime.InteropServices;
using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [ExpectedStructSize(typeof(JPH_SliderConstraintSettings))]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SliderConstraintSettings
    {
        public static SliderConstraintSettings Create()
        {
            var instance = new SliderConstraintSettings();
            JPH_SliderConstraintSettings_Init(ref instance);
            return instance;
        }

        #region ConstraintSettings
        
        public NativeBool Enabled;

        public uint ConstraintPriority;

        public uint NumVelocityStepsOverride;

        public uint NumPositionStepsOverride;

        public float DrawConstraintSize;

        public ulong UserData;

        #endregion
        
        public ConstraintSpace Space;

        public NativeBool AutoDetectPoint;
        
        public rvec3 Point1;
        
        public float3 SliderAxis1;

        public float3 NormalAxis1;

        public rvec3 Point2;

        public float3 SliderAxis2;

        public float3 NormalAxis2;

        public float LimitsMin;

        public float LimitsMax;

        public SpringSettings LimitsSpringSettings;

        public float MaxFrictionForce;

        public MotorSettings MotorSettings;

        public void SetSliderAxis(float3 axis)
        {
            JPH_SliderConstraintSettings_SetSliderAxis(ref this, axis);
        }
    }
}