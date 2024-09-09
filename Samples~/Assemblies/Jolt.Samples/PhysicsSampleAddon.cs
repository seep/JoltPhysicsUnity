using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsSampleAddon : MonoBehaviour
    {
        public virtual void Initialize(PhysicsSystem system, ManagedPhysicsContext context) { }
        
        public virtual void PrePhysicsStep(PhysicsSystem system, ManagedPhysicsContext context) { }
        
        public virtual void PostPhysicsStep(PhysicsSystem system, ManagedPhysicsContext context) { }
    }
}