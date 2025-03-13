using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_SpringSettings))]
    public struct SpringSettings
    {
        public SpringMode Mode;
        
        public float FrequencyOrStiffness;
        
        public float Damping;
    }
}
