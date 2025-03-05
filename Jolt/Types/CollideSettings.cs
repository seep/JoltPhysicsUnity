using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_CollideSettingsBase))]
    public struct CollideSettings
    {
        public ActiveEdgeMode ActiveEdgeMode;

        public CollectFacesMode CollectFacesMode;

        public float CollisionTolerance;

        public float PenetrationTolerance;

        public float3 ActiveEdgeMovementDirection;
    }
}
