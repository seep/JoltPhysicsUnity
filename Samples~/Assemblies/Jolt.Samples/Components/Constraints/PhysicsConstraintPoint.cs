using Unity.Mathematics;

namespace Jolt.Samples
{
    public class PhysicsConstraintPoint : PhysicsConstraintBase
    {
        public PhysicsBody BodyA;
        public PhysicsBody BodyB;

        public float3 Point;

        internal override Constraint Initialize(ManagedPhysicsContext context)
        {
            var settings = PointConstraintSettings.Create();

            settings.SetPoint1(Point);
            settings.SetPoint2(Point);
            
            var ba = context.ManagedToNative[BodyA];
            var bb = context.ManagedToNative[BodyB];

            return settings.CreateConstraint(ba, bb);
        }
    }
}