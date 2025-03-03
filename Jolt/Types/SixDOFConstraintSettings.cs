using System.Runtime.InteropServices;
using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [ExpectedStructSize(typeof(JPH_SixDOFConstraintSettings))]
    [StructLayout(LayoutKind.Sequential)]
    public struct SixDOFConstraintSettings
    {
        public static SixDOFConstraintSettings Create()
        {
            var instance = new SixDOFConstraintSettings();
            JPH_SixDOFConstraintSettings_Init(ref instance);
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
