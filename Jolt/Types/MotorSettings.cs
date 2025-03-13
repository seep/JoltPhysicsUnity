using System.Runtime.InteropServices;

namespace Jolt
{
    public enum MotorState : uint
    {
        Off = 0,
        Velocity = 1,
        Position = 2,
    }

    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_MotorSettings))]
    public struct MotorSettings
    {
        public SpringSettings SpringSettings;

        public float MinForceLimit;
        public float MaxForceLimit;
        
        public float MinTorqueLimit;
        public float MaxTorqueLimit;
    }
}
