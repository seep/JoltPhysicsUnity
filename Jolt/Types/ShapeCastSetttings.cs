using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_CollideShapeSettings))]
    public struct ShapeCastSetttings
    {
        private CollideSettings @base;

        public ActiveEdgeMode ActiveEdgeMode
        {
            get => @base.ActiveEdgeMode;
            set => @base.ActiveEdgeMode = value;
        }

        public CollectFacesMode CollectFacesMode
        {
            get => @base.CollectFacesMode;
            set => @base.CollectFacesMode = value;
        }

        public float CollisionTolerance
        {
            get => @base.CollisionTolerance;
            set => @base.CollisionTolerance = value;
        }

        public float PenetrationTolerance
        {
            get => @base.PenetrationTolerance;
            set => @base.PenetrationTolerance = value;
        }

        public float3 ActiveEdgeMovementDirection
        {
            get => @base.ActiveEdgeMovementDirection;
            set => @base.ActiveEdgeMovementDirection = value;
        }

        public BackFaceMode BackFaceModeTriangles;

        public BackFaceMode BackFaceModeConvex;

        public NativeBool UseShrunkenShapeAndConvexRadius;

        public NativeBool ReturnDeepestPoint;
    }
}
