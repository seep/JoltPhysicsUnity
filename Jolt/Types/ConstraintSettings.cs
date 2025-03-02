using System.Runtime.InteropServices;

namespace Jolt
{
    [ExpectedStructSize(typeof(JPH_ConstraintSettings))]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ConstraintSettings
    {
        public NativeBool Enabled;
        
        public uint ConstraintPriority;

        public uint NumVelocityStepsOverride;

        public uint NumPositionStepsOverride;

        public float DrawConstraintSize;

        public ulong UserData;
    }
}
