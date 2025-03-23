using Unity.Mathematics;

namespace Jolt.Samples
{
    public class SliderSample : Sample
    {
        public PhysicsBody SliderBody;

        protected override void FixedUpdate()
        {
            // Oscillate the slider body on the X and Z rotation axes to create simple motion without motors.

            const float scale = 0.2f;

            var t = PhysicsTime;
            var r = quaternion.Euler(math.cos(t) * scale, 0f, math.sin(t) * scale);

            PhysicsSystem.GetBodyInterface().SetRotation(SliderBody.NativeBodyID!.Value, r, Activation.Activate);

            base.FixedUpdate();
        }
    }
}