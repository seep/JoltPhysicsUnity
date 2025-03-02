using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CollideShapeResult
    {
        public float3 ContactPointOn1;
        
        public float3 ContactPointOn2;
        
        public float3 PenetrationAxis;
        
        public float PenetrationDepth;

        public SubShapeID SubShapeID1;
        
        public SubShapeID SubShapeID2;

        public BodyID BodyID2;
    }
}