namespace Jolt.Samples
{
    public class PhysicsShapeCapsule : PhysicsShapeBase
    {
        public float Radius = 0.5f;

        public float HalfHeight = 0.5f;
        
        internal override ShapeSettings CreateShapeSettings()
        {
            return CapsuleShapeSettings.Create(HalfHeight, Radius);
        }
    }
}
