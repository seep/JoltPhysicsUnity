using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public class QuerySample : Sample
    {
        public PhysicsBody BroadPhaseBody;
        public GameObject BroadPhasePoint;

        public PhysicsBody NarrowPhaseBody;
        public GameObject NarrowPhasePoint;

        protected override void FixedUpdate()
        {
            // This sample demonstrates broad phase and narrow phase ray casting. Broad phase queries only sample
            // the root AABBs of shapes, while narrow phase queries sample into subshapes and faces of the root shape.

            SampleHelpers.Tumble(Context, BroadPhaseBody);
            SampleHelpers.Tumble(Context, NarrowPhaseBody);

            base.FixedUpdate();

            BroadPhaseQuery(
                origin: new float3(2f, 3f, -2f),
                vector: new float3(-5f, 0f, 0f)
            );

            NarrowPhaseQuery(
                origin: new float3(2f, 3f, +2f),
                vector: new float3(-5f, 0f, 0f)
            );
        }

        private void BroadPhaseQuery(float3 origin, float3 vector)
        {
            var query = PhysicsSystem.GetBroadPhaseQuery();

            BroadPhaseCastResult hit = default;

            // TODO joltc has no simple out result for this like NarrowPhaseQuery_CastRay
            if (query.CastRay(origin, vector, (ref BroadPhaseCastResult result) => { hit = result; }, default, default))
            {
                var point = origin + vector * hit.Fraction;
                var normal = -vector; // TODO derive AABB normal from vector orientation

                BroadPhasePoint.SetActive(true);
                BroadPhasePoint.transform.position = point;
                BroadPhasePoint.transform.rotation = quaternion.LookRotation(-normal, math.up());
            }
            else
            {
                BroadPhasePoint.SetActive(false);
            }
        }

        private void NarrowPhaseQuery(float3 origin, float3 vector)
        {
            var query = PhysicsSystem.GetNarrowPhaseQuery();

            RayCastResult hit = default;

            // TODO generate bindings with default parameters
            if (query.CastRay(origin, vector, out hit, default, default, default))
            {
                var point = origin + vector * hit.Fraction;
                var normal = NarrowPhaseBody.NativeBody!.Value.GetWorldSpaceSurfaceNormal(hit.SubShapeID, point);

                NarrowPhasePoint.SetActive(true);
                NarrowPhasePoint.transform.position = point;
                NarrowPhasePoint.transform.rotation = quaternion.LookRotation(-normal, math.up());
            }
            else
            {
                NarrowPhasePoint.SetActive(false);
            }
        }
    }
}