using System.Runtime.InteropServices;

using static Jolt.Bindings;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_DistanceConstraintSettings))]
    public struct DistanceConstraintSettings
    {
        /// <summary>
        /// Create a new instance initialized with the default values.
        /// </summary>
        public static DistanceConstraintSettings Create()
        {
            var result = new DistanceConstraintSettings();
            JPH_DistanceConstraintSettings_Init(ref result);
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

        public rvec3 Point1;
        
        public rvec3 Point2;

        public float MinDistance;

        public float MaxDistance;

        public SpringSettings LimitsSpringSettings;
    }
}
