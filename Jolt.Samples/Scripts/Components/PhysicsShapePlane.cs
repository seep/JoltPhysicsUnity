using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapePlane : MonoBehaviour, IPhysicsShapeComponent
    {
        public float HalfExtent = 1000f;

        public Plane BuildPlane()
        {
            return new Plane { Normal = transform.up, Distance = 0f };
        }
    }
}