using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsConstraintHinge : PhysicsConstraintBase
    {
        public PhysicsBody BodyA;
        public PhysicsBody BodyB;

        /// <summary>
        /// The world space hinge point.
        /// </summary>
        public float3 HingePoint = float3.zero;

        private static readonly float3 DefaultHingeAxis = new(0f, 1f, 0f);

        /// <summary>
        /// The world space hinge axis.
        /// </summary>
        public float3 HingeAxis = DefaultHingeAxis;

        private static readonly float3 DefaultNormalAxis = new(1f, 0f, 0f);

        /// <summary>
        /// The body space hinge normal. The hinge rotation is zero when the hinge normal of both bodies are aligned in world space.
        /// </summary>
        public float3 NormalAxis = DefaultNormalAxis;

        [Range(0f, 1f)]
        public float MinRotation = 0f;

        [Range(0f, 1f)]
        public float MaxRotation = 1f;

        internal override Constraint Initialize(ManagedPhysicsContext context)
        {
            var settings = HingeConstraintSettings.Create();

            // The hinge constraint configuration is flexible but maybe confusing. The constraint solver enforces the
            // hinge points coinciding in world space and the hinge axes aligning in world space. The bodies are
            // constrained to maintain their initial translations and rotations relative to the world space points
            // and axes. The hinge rotation is zero when the normal axes in body local space are aligned in world space.

            // For simplicity this sample component just exposes one world space point and axis and uses it for both
            // bodies. In other words the initial state of the hinge is considered solved.

            // Note, the native library has a way to define the hinge constraint in body local coordinates (similar to
            // the other constraints, see DistanceConstraintSettings#SetSpace) but it is not exposed by joltc.

            settings.Point1 = HingePoint;
            settings.Point2 = HingePoint;

            settings.HingeAxis1 = math.normalizesafe(HingeAxis);
            settings.HingeAxis2 = math.normalizesafe(HingeAxis);

            settings.NormalAxis1 = math.normalizesafe(NormalAxis);
            settings.NormalAxis2 = math.normalizesafe(NormalAxis);

            var ba = BodyA.NativeBody!.Value;
            var bb = BodyB.NativeBody!.Value;

            var constraint = HingeConstraint.Create(ref settings, ba, bb);

            var minRotationRadians = math.remap(0f, 1f, -math.PI, +math.PI, MinRotation);
            var maxRotationRadians = math.remap(0f, 1f, -math.PI, +math.PI, MaxRotation);

            constraint.SetLimits(minRotationRadians, maxRotationRadians); // TODO constraint limits setter seems to be missing from HingeConstraintSettings?

            return constraint;
        }
    }
}