using UnityEngine;

namespace Jolt.Samples
{
    public class ListenerSample : Sample
    {
        private BodyActivationListener nativeBodyActivationListener;

        private ContactListener nativeContactListener;

        protected override void Start()
        {
            base.Start();

            nativeBodyActivationListener = BodyActivationListener.Create(new SampleBodyActivationListener());
            PhysicsSystem.SetBodyActivationListener(nativeBodyActivationListener);

            nativeContactListener = ContactListener.Create(new SampleContactListener());
            PhysicsSystem.SetContactListener(nativeContactListener);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            nativeBodyActivationListener.Destroy();
            nativeContactListener.Destroy();
        }
    }

    /// <summary>
    /// Sample body activation listener that logs each event.
    /// </summary>
    public class SampleBodyActivationListener : IBodyActivationListener
    {
        public void OnBodyActivated(BodyID bodyID, ulong bodyUserData)
        {
            Debug.Log($"OnBodyActivated(BodyID: {bodyID}, BodyUserData: {bodyUserData})");
        }

        public void OnBodyDeactivated(BodyID bodyID, ulong bodyUserData)
        {
            Debug.Log($"OnBodyDeactivated(BodyID: {bodyID}, BodyUserData: {bodyUserData})");
        }
    }

    /// <summary>
    /// Sample contact listener that logs each event.
    /// </summary>
    public class SampleContactListener : IContactListener
    {
        public ValidateResult OnContactValidate()
        {
            Debug.Log("OnContactValidate");

            return ValidateResult.AcceptAllContactsForThisBodyPair;
        }

        public void OnContactAdded()
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