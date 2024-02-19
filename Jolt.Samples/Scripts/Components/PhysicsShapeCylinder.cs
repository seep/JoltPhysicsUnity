using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapeCylinder : MonoBehaviour, IPhysicsShapeComponent
    {
        public float Radius = 0.5f;

        public float HalfHeight = 0.5f;

        public float ConvexRadius = PhysicsSettings.DefaultConvexRadius;
    }
}
