namespace Jolt.Samples
{
    public class PhysicsShapeCylinder : PhysicsShapeBase
    {
        public float Radius = 0.5f;

        public float HalfHeight = 0.5f;

        public float ConvexRadius = PhysicsSettings.DefaultConvexRadius;
        
        internal override ShapeSettings CreateShapeSettings()
        {
            return CylinderShapeSettings.Create(HalfHeight, Radius, ConvexRadius);
        }
    }
}
