using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_RayCastResult))]
    public struct RayCastResult
    {
        public BodyID BodyID;

        public float Fraction;

        public SubShapeID SubShapeID;
    }
}
