using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CollidePointResult
    {
        public BodyID BodyID;

        public SubShapeID SubShapeID;
    }
}
