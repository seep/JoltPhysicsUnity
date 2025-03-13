using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_CollidePointResult))]
    public struct CollidePointResult
    {
        public BodyID BodyID;

        public SubShapeID SubShapeID;
    }
}
