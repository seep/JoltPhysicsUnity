using UnityEngine;

namespace Jolt.Samples
{
    public class SampleContactListener : PhysicsSampleAddon, IContactListener
    {
        public override void Initialize(PhysicsSystem system, ManagedPhysicsContext _)
        {
            system.SetContactListener(this);
        }

        public ValidateResult OnContactValidate()
        {
            Debug.Log("OnContactValidate");

            return ValidateResult.AcceptAllContactsForThisBodyPair;
        }

        void IContactListener.OnContactAdded()
        {
            Debug.Log("OnContactAdded");
        }

        public void OnContactPersisted()
        {
            Debug.Log("OnContactPersisted");
        }

        public void OnContactRemoved()
        {
            Debug.Log("OnContactRemoved");
        }
    }
}
