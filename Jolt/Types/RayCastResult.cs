using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RayCastResult
    {
        public BodyID BodyID;

        public float Fraction;

        public uint SubShapeID;
    }
}
