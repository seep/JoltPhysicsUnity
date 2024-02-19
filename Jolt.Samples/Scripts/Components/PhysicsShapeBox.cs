using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapeBox : MonoBehaviour, IPhysicsShapeComponent
    {
        public float3 HalfExtent = new (0.5f, 0.5f, 0.5f);

        public float ConvexRadius = PhysicsSettings.DefaultConvexRadius;
    }
}
