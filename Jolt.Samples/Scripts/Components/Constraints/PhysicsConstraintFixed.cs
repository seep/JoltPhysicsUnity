namespace Jolt.Samples
{
    public class PhysicsConstraintFixed : PhysicsConstraintBase
    {
        public PhysicsBody BodyA;
        public PhysicsBody BodyB;

        internal override Constraint Initialize(ManagedPhysicsContext context)
        {
            var settings = FixedConstraintSettings.Create();
            
            settings.SetAutoDetectPoint(true);

            var ba = context.ManagedToNative[BodyA];
            var bb = context.ManagedToNative[BodyB];

            return settings.CreateConstraint(ba, bb);
        }
    }
}
