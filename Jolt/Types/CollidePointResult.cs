using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CollidePointResult
    {
        public BodyID BodyID;

        public SubShapeID SubShapeID;
    }
}