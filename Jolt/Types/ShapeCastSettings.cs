using System.Runtime.InteropServices;
using Unity.Mathematics;

using static Jolt.Bindings;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_ShapeCastSettings))]
    public struct ShapeCastSettings
    {
        /// <summary>
        /// Create a new instance initialized with the default values.
        /// </summary>
        public static ShapeCastSettings Create()
        {
            ShapeCastSettings result = default;
            JPH_ShapeCastSettings_Init(ref result);
            return result;
        }

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
