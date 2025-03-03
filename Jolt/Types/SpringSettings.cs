using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpringSettings
    {
        public SpringMode Mode;
        public float FrequencyOrStiffness;
        public float Damping;
    }
}
