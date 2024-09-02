using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapeBox : PhysicsShapeBase
    {
        public float3 HalfExtent = new (0.5f, 0.5f, 0.5f);

        public float ConvexRadius = PhysicsSettings.DefaultConvexRadius;
        
        internal override ShapeSettings CreateShapeSettings()
        {
            return BoxShapeSettings.Create(HalfExtent, ConvexRadius);
        }
    }
}
