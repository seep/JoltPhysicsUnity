using System.Runtime.InteropServices;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_GearConstraintSettings))]
    public struct GearConstraintSettings
    {
        /// <summary>
        /// Create a new instance initialized with the default values.
        /// </summary>
        public static GearConstraintSettings Create()
        {
            var result = new GearConstraintSettings();
            JPH_GearConstraintSettings_Init(ref result);
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

        public float3 HingeAxis1;

        public float3 HingeAxis2;

        public float Ratio;
    }
}
