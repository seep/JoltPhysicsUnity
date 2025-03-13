using System.Runtime.InteropServices;
using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_SixDOFConstraintSettings))]
    public struct SixDOFConstraintSettings
    {
        /// <summary>
        /// Create a new instance initialized with the default values.
        /// </summary>
        public static SixDOFConstraintSettings Create()
        {
            var result = new SixDOFConstraintSettings();
            JPH_SixDOFConstraintSettings_Init(ref result);
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

        public float3 AxisX1;

        public float3 AxisY1;

        public rvec3 Position2;

        public float3 AxisX2;

        public float3 AxisY2;

        public unsafe fixed float MaxFriction[6];

        public SwingType SwingType;

        public unsafe fixed float LimitMin[6];

        public unsafe fixed float LimitMax[6];

        public SpringSettingsFixedBuffer LimitsSpringSettings;

        public MotorSettingsFixedBuffer MotorSettings;
        
        /// <summary>
        /// Specialized fixed size buffer for SixDOFConstraintSettings LimitsSpringSettings.
        /// </summary>
        [ExpectedStructSize(typeof(JPH_SixDOFConstraintSettings._limitsSpringSettings_e__FixedBuffer))]
        public struct SpringSettingsFixedBuffer
        {
            private SpringSettings e0;
            private SpringSettings e1;
            private SpringSettings e2;

            public unsafe ref SpringSettings this[int index]
            {
                get
                {
                    fixed (SpringSettings* ptr = &e0)
                    {
                        return ref ptr[index];
                    }
                }
            }
        }

        /// <summary>
        /// Specialized fixed size buffer for SixDOFConstraintSettings MotorSettings.
        /// </summary>
        [ExpectedStructSize(typeof(JPH_SixDOFConstraintSettings._motorSettings_e__FixedBuffer))]
        public struct MotorSettingsFixedBuffer
        {
            private MotorSettings e0;
            private MotorSettings e1;
            private MotorSettings e2;
            private MotorSettings e3;
            private MotorSettings e4;
            private MotorSettings e5;
            
            public unsafe ref MotorSettings this[int index]
            {
                get
                {
                    fixed (MotorSettings* ptr = &e0)
                    {
                        return ref ptr[index];
                    }
                }
            }
        }
    }
}
