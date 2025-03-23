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

            var ba = BodyA.NativeBody!.Value;
            var bb = BodyB.NativeBody!.Value;

            return FixedConstraint.Create(ref settings, ba, bb);
        }
    }
}