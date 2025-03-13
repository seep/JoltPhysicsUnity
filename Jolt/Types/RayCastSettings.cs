using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_RayCastSettings))]
    public struct RayCastSettings
    {
        public BackFaceMode BackFaceModeTriangles;

        public BackFaceMode BackFaceModeConvex;

        public NativeBool TreatConvexAsSolid;
    }
}
