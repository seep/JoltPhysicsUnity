using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_CollideShapeResult))]
    public struct CollideShapeResult
    {
        public float3 ContactPointOn1;
        
        public float3 ContactPointOn2;
        
        public float3 PenetrationAxis;
        
        public float PenetrationDepth;

        public SubShapeID SubShapeID1;
        
        public SubShapeID SubShapeID2;

        public BodyID BodyID2;

        public uint Shape1FaceCount;

        public nint Shape1Faces; // TODO use NativeArray
        
        public uint Shape2FaceCount;
        
        public nint Shape2Faces; // TODO use NativeArray
    }
}
