using System.Runtime.InteropServices;

using static Jolt.Bindings;

namespace Jolt
{
    [ExpectedStructSize(typeof(JPH_PointConstraintSettings))]
    [StructLayout(LayoutKind.Sequential)]
    public struct PointConstraintSettings
    {
        public static PointConstraintSettings Create()
        {
            var instance = new PointConstraintSettings();
            JPH_PointConstraintSettings_Init(ref instance);
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
    }
}
