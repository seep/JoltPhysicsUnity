using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapeTaperedCapsule : PhysicsShapeBase
    {
        public float TopRadius = 0.5f;

        public float BottomRadius = 0.5f;

        public float HalfHeight = 0.5f;
        
        internal override ShapeSettings CreateShapeSettings()
        {
            return TaperedCapsuleShapeSettings.Create(HalfHeight, TopRadius, BottomRadius);
        }
    }
}
