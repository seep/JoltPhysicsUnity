using System.Runtime.InteropServices;
using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_HingeConstraintSettings))]
    public struct HingeConstraintSettings
    {
        public static HingeConstraintSettings Create()
        {
            var instance = new HingeConstraintSettings();
            JPH_HingeConstraintSettings_Init(ref instance);
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

        public rvec3 Point1;
        
        public float3 HingeAxis1;

        public float3 NormalAxis1;

        public rvec3 Point2;

        public float3 HingeAxis2;

        public float3 NormalAxis2;

        public float LimitsMin;

        public float LimitsMax;

        public SpringSettings LimitsSpringSettings;

        public float MaxFrictionTorque;

        public MotorSettings MotorSettings;
    }
}
