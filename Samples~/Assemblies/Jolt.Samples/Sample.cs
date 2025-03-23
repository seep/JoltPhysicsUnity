using UnityEngine;

namespace Jolt.Samples
{
    public class Sample : MonoBehaviour
    {
        protected ManagedPhysicsContext Context;

        protected PhysicsSystem PhysicsSystem => Context.PhysicsSystem;

        protected float PhysicsTime => Context.PhysicsTime;

        protected virtual void Start()
        {
            Context = new ManagedPhysicsContext();
        }

        protected virtual void FixedUpdate()
        {
            Context.Update(Time.fixedDeltaTime);
        }

        protected virtual void OnDestroy()
        {
            Context.Destroy();
        }
    }
}