using Unity.Mathematics;

namespace Jolt.Samples
{
    public class PhysicsShapePlane : PhysicsShapeBase
    {
        public float HalfExtent = 1000f;

        internal override ShapeSettings CreateShapeSettings()
        {
            // The shape is transformed by the body local-to-world, so we only need to define the plane in object
            // space. For simplicity the sample component always uses the positive Y normal with no distance.
            
            return PlaneShapeSettings.Create(new Plane { Normal = new float3(0f, 1f, 0f), Distance = 0f }, HalfExtent);
        }
    }
}