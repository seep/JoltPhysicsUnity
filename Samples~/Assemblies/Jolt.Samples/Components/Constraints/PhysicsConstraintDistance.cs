namespace Jolt.Samples
{
    public class PhysicsConstraintDistance : PhysicsConstraintBase
    {
        public PhysicsBody BodyA;
        public PhysicsBody BodyB;

        internal override Constraint Initialize(ManagedPhysicsContext context)
        {
            var settings = DistanceConstraintSettings.Create();

            settings.Point1 = default;
            settings.Point2 = default;
            settings.Space = ConstraintSpace.LocalToBodyCOM;

            var ba = BodyA.NativeBody!.Value;
            var bb = BodyB.NativeBody!.Value;

            return DistanceConstraint.Create(ref settings, ba, bb);
        }
    }
}