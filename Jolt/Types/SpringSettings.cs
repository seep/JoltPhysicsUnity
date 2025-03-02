using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SpringSettings
    {
        public SpringMode Mode;
        public float FrequencyOrStiffness;
        public float Damping;
    }
}
