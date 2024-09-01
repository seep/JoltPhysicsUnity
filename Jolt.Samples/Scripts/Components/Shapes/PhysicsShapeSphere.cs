namespace Jolt.Samples
{
    public class PhysicsShapeSphere : PhysicsShapeBase
    {
        public float Radius = 0.5f;
        
        internal override ShapeSettings CreateShapeSettings()
        {
            return SphereShapeSettings.Create(Radius);
        }
    }
}
