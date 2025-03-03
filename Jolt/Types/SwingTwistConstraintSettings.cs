using System.Runtime.InteropServices;
using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [ExpectedStructSize(typeof(JPH_SwingTwistConstraintSettings))]
    [StructLayout(LayoutKind.Sequential)]
    public struct SwingTwistConstraintSettings
    {
        public static SwingTwistConstraintSettings Create()
        {
            var instance = new SwingTwistConstraintSettings();
            JPH_SwingTwistConstraintSettings_Init(ref instance);
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
        
        public rvec3 Position1;
        
        public float3 TwistAxis1;

        public float3 PlaneAxis1;

        public rvec3 Position2;

        public float3 TwistAxis2;

        public float3 PlaneAxis2;

        public float NormalHalfConeAngle;

        public float PlaneHalfConeAngle;

        public float TwistMinAngle;

        public float TwistMaxAngle;

        public float MaxFrictionTorque;

        public MotorSettings SwingMotorSettings;

        public MotorSettings TwistMotorSettings;
    }
}
