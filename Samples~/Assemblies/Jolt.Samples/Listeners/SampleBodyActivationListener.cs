using UnityEngine;

namespace Jolt.Samples
{
    public class SampleBodyActivationListener : PhysicsSampleAddon, IBodyActivationListener
    {
        private BodyActivationListener listener;
        
        public override void Initialize(PhysicsSystem system, ManagedPhysicsContext _)
        {
            system.SetBodyActivationListener(listener = BodyActivationListener.Create(this));
        }

        public override void Dispose(PhysicsSystem system, ManagedPhysicsContext _)
        {
            listener.Destroy();
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
