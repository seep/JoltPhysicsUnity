using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BroadPhaseCastResult
    {
        public BodyID BodyID;

        public float Fraction;
    }
}