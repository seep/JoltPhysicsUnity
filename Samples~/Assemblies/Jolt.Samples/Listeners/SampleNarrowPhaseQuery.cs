using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public class SampleNarrowPhaseQuery : PhysicsSampleAddon
    {
        private PhysicsSystem? system;
        
        public override void Initialize(PhysicsSystem system, ManagedPhysicsContext context)
        {
            this.system = system;
        }

        public virtual void Dispose(PhysicsSystem system, ManagedPhysicsContext context)
        {
            this.system = null;
        }
        
        private void Update()
        {
            if (this.system == null) return;
            PhysicsSystem system = this.system.Value;
            
            
            var query = system.GetNarrowPhaseQuery();

            var t = math.sin(Time.realtimeSinceStartup);
            var origin = new float3(t * 2f, 2, -2);
            var direction = new float3(0, 0, 4);

            if (query.CastRay(origin, direction, out RayCastResult hit, default, default, default)) // TODO generate bindings with default parameters
            {
                Debug.DrawRay(origin, direction * hit.Fraction, UnityEngine.Color.red);   
            }
            else
            {
                Debug.DrawRay(origin, direction, UnityEngine.Color.green);
            }
        }
    }
}