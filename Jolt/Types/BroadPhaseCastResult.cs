using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BroadPhaseCastResult
    {
        public BodyID BodyID;

        public float Fraction;
    }
}
