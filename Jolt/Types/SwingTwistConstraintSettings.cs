using System.Runtime.InteropServices;
using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_SwingTwistConstraintSettings))]
    public struct SwingTwistConstraintSettings
    {
        /// <summary>
        /// Create a new instance initialized with the default values.
        /// </summary>
        public static SwingTwistConstraintSettings Create()
        {
            var result = new SwingTwistConstraintSettings();
            JPH_SwingTwistConstraintSettings_Init(ref result);
            return result;
        }

        private ConstraintSettings @base;
        
        public NativeBool Enabled
        {
            get => @base.Enabled;
            set => @base.Enabled = value;
        }

        public uint ConstraintPriority 
        {
            get => @base.ConstraintPriority;
            set => @base.ConstraintPriority = value;
        }

        public uint NumVelocityStepsOverride 
        {
            get => @base.NumVelocityStepsOverride;
            set => @base.NumVelocityStepsOverride = value;
        }

        public uint NumPositionStepsOverride 
        {
            get => @base.NumPositionStepsOverride;
            set => @base.NumPositionStepsOverride = value;
        }

        public float DrawConstraintSize 
        {
            get => @base.DrawConstraintSize;
            set => @base.DrawConstraintSize = value;
        }

        public ulong UserData 
        {
            get => @base.UserData;
            set => @base.UserData = value;
        }
        
        public ConstraintSpace Space;

        public rvec3 Position1;
        
        public float3 TwistAxis1;

        public float3 PlaneAxis1;

        public rvec3 Position2;

        public float3 TwistAxis2;

        public float3 PlaneAxis2;

        public SwingType SwingType;

        public float NormalHalfConeAngle;

        public float PlaneHalfConeAngle;

        public float TwistMinAngle;

        public float TwistMaxAngle;

        public float MaxFrictionTorque;

        public MotorSettings SwingMotorSettings;

        public MotorSettings TwistMotorSettings;
    }
}
