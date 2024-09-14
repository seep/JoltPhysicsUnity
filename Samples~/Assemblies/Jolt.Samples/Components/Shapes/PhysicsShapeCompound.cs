using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapeCompound : PhysicsShapeBase
    {
        public bool Mutable;
        
        internal override ShapeSettings CreateShapeSettings()
        {
            CompoundShapeSettings settings;

            if (Mutable)
            {
                settings = MutableCompoundShapeSettings.Create();
            }
            else
            {
                settings = StaticCompoundShapeSettings.Create();
            }

            foreach (var shape in GetComponentsInChildren<PhysicsShapeBase>())
            {
                if (shape == this) continue;
                
                // transform child into local coordinates (including deeply nested ones)
                
                var pos = transform.InverseTransformPoint(shape.transform.position);
                var rot = Quaternion.Inverse(transform.rotation) * shape.transform.rotation;
                
                settings.AddShape(pos, rot, shape.CreateShapeSettings(), 0);
            }

            return settings;
        }
    }
}
