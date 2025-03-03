using System.Runtime.InteropServices;

using static Jolt.Bindings;

namespace Jolt
{
    [ExpectedStructSize(typeof(JPH_DistanceConstraintSettings))]
    [StructLayout(LayoutKind.Sequential)]
    public struct DistanceConstraintSettings
    {
        public static DistanceConstraintSettings Create()
        {
            var instance = new DistanceConstraintSettings();
            JPH_DistanceConstraintSettings_Init(ref instance);
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
        
        public rvec3 Point2;

        public float MinDistance;

        public float MaxDistance;

        public SpringSettings LimitsSpringSettings;
    }
}
