using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapePlane : MonoBehaviour, IPhysicsShapeComponent
    {
        public float HalfExtent = 1000f;

        public Plane BuildPlane()
        {
            // The body transform uses the game object transform, so we only need to define the plane in object space.
            // For simplicity the sample component always uses the positive Y normal with no distance.
            
            return new Plane { Normal = new float3(0f, 1f, 0f), Distance = 0f };
        }
    }
}