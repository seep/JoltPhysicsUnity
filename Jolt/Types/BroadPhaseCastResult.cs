using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_BroadPhaseCastResult))]
    public struct BroadPhaseCastResult
    {
        public BodyID BodyID;

        public float Fraction;
    }
}
