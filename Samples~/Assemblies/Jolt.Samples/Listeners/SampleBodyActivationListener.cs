using UnityEngine;

namespace Jolt.Samples
{
    public class SampleBodyActivationListener : PhysicsSampleAddon, IBodyActivationListener
    {
        public override void Initialize(PhysicsSystem system, ManagedPhysicsContext _)
        {
            system.SetBodyActivationListener(this);
        }

        public void OnBodyActivated(BodyID bodyID, ulong bodyUserData)
        {
            Debug.Log($"OnBodyActivated(BodyID: {bodyID}, BodyUserData: {bodyUserData})");
        }

        public void OnBodyDeactivated(BodyID bodyID, ulong bodyUserData)
        {
            Debug.Log($"OnBodyDeactivated(BodyID: {bodyID}, BodyUserData: {bodyUserData})");
        }
    }
}
