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
        
            settings.SetPoint1(SliderPoint);
            settings.SetPoint2(SliderPoint);
            
            settings.SetSliderAxis1(math.normalizesafe(SliderAxis));
            settings.SetSliderAxis2(math.normalizesafe(SliderAxis));
            
            settings.SetNormalAxis1(SliderNormal);
            settings.SetNormalAxis2(SliderNormal);
            
            var ba = context.ManagedToNative[BodyA];
            var bb = context.ManagedToNative[BodyB];

            return settings.CreateConstraint(ba, bb);
        }
    }
}