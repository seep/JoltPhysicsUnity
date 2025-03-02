using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RayCastResult
    {
        public BodyID BodyID;

        public float Fraction;

        public uint SubShapeID;
    }
}