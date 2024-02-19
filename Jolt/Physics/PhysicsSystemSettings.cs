using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PhysicsSystemSettings
    {
        public uint MaxBodies;
        public uint MaxBodyPairs;
        public uint MaxContactConstraints;
    }
}
