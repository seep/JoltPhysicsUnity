using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public class QuerySample : Sample
    {
        private void Update()
        {
            // This sample demonstrates broad phase and narrow phase ray casting. Broad phase queries only sample
            // the root AABBs of shapes, while narrow phase queries sample into subshapes and faces of the root shape.

            // TODO use a drawing lib that can draw lines in the game view so gizmos dont have to be turned on

            BroadPhaseQuery();
            NarrowPhaseQuery();
        }

        private void BroadPhaseQuery()
        {
            var query = PhysicsSystem.GetBroadPhaseQuery();
            var origin = new float3(-2, 2, 2 - math.sin(PhysicsTime) * 2f);
            var vector = new float3(4, 0, 0);

            BroadPhaseCastResult hit = default;

            // TODO joltc has no simple out result for this like NarrowPhaseQuery_CastRay
            if (query.CastRay(origin, vector, (ref BroadPhaseCastResult result) => { hit = result; }, default, default))
            {
                Debug.DrawRay(origin, vector * hit.Fraction, UnityEngine.Color.magenta);
            }
            else
            {
                Debug.DrawRay(origin, vector, UnityEngine.Color.yellow);
            }
        }

        private void NarrowPhaseQuery()
        {
            var query = PhysicsSystem.GetNarrowPhaseQuery();
            var origin = new float3(-2, 2, -2 + math.sin(PhysicsTime) * 2f);
            var vector = new float3(4, 0, 0);

            RayCastResult hit = default;

            // TODO generate bindings with default parameters
            if (query.CastRay(origin, vector, out hit, default, default, default))
            {
                Debug.DrawRay(origin, vector * hit.Fraction, UnityEngine.Color.red);
            }
            else
            {
                Debug.DrawRay(origin, vector, UnityEngine.Color.green);
            }
        }
    }
}