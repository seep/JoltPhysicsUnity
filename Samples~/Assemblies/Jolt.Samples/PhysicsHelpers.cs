using System;
using Unity.Mathematics;

namespace Jolt.Samples
{
    public enum PhysicsSamplesLayers : ushort
    {
        Static = 1,
        Moving = 1,
    }

    public static class PhysicsHelpers
    {
        public static Body CreateBodyFromGameObject(BodyInterface bodies, PhysicsBody component)
        {
            if (!component.TryGetComponent(out PhysicsShapeBase shapeComponent))
            {
                throw new NotImplementedException();
            }

            var pos = (float3) component.transform.position;
            var rot = (quaternion) component.transform.rotation;

            var layer = component.MotionType == MotionType.Static
                ? (ushort)PhysicsSamplesLayers.Static
                : (ushort)PhysicsSamplesLayers.Moving;
            
            var settings = BodyCreationSettings.Create(
                shapeComponent.CreateShapeSettings(), pos, rot, component.MotionType, layer
            );

            return bodies.CreateBody(settings);
        }
    }
}
