using Unity.Mathematics;

namespace Jolt.Samples
{
    public static class SampleHelpers
    {
        public static void Tumble(ManagedPhysicsContext context, PhysicsBody body)
        {
            var t = context.PhysicsTime * 0.2f;
            var r = quaternion.Euler(t * 3f, t * 5f, t * 11f);

            context.PhysicsSystem.GetBodyInterface().SetRotation(body.NativeBodyID!.Value, r, Activation.Activate);
        }
    }
}