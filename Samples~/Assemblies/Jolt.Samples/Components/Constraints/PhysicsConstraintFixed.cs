namespace Jolt.Samples
{
    public class PhysicsConstraintFixed : PhysicsConstraintBase
    {
        public PhysicsBody BodyA;
        public PhysicsBody BodyB;

        internal override Constraint Initialize(ManagedPhysicsContext context)
        {
            var settings = FixedConstraintSettings.Create();
            
            settings.AutoDetectPoint = true;

            var ba = context.ManagedToNative[BodyA];
            var bb = context.ManagedToNative[BodyB];

            return FixedConstraint.Create(ref settings, ba, bb);
        }
    }
}
