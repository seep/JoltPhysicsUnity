using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_SubShapeIDPair))]
    public struct SubShapeIDPair
    {
        public BodyID Body1;

        public SubShapeID SubShape1;

        public BodyID Body2;

        public SubShapeID SubShape2;
    }
}
