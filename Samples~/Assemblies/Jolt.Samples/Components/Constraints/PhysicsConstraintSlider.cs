using Unity.Mathematics;

namespace Jolt.Samples
{
    public class PhysicsConstraintSlider : PhysicsConstraintBase
    {
        public PhysicsBody BodyA;
        public PhysicsBody BodyB;

        public float3 SliderPoint;
        public float3 SliderAxis;
        public float3 SliderNormal;

        internal override Constraint Initialize(ManagedPhysicsContext context)
        {
            var settings = SliderConstraintSettings.Create();

            settings.Point1 = SliderPoint;
            settings.Point2 = SliderPoint;

            settings.SliderAxis1 = math.normalizesafe(SliderAxis);
            settings.SliderAxis2 = math.normalizesafe(SliderAxis);

            settings.NormalAxis1 = SliderNormal;
            settings.NormalAxis2 = SliderNormal;

            var ba = BodyA.NativeBody!.Value;
            var bb = BodyB.NativeBody!.Value;

            return SliderConstraint.Create(ref settings, ba, bb);
        }
    }
}