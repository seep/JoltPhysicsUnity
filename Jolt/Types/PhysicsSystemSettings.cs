using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicsSystemSettings
    {
        public uint MaxBodies;
        
        public uint NumBodyMutexes;
        
        public uint MaxBodyPairs;
        
        public uint MaxContactConstraints;

        public ObjectLayerPairFilter ObjectLayerPairFilter;

        public BroadPhaseLayerInterface BroadPhaseLayerInterface;

        public ObjectVsBroadPhaseLayerFilter ObjectVsBroadPhaseLayerFilter;
    }
}
