namespace Jolt.Samples
{
    public class PhysicsConstraintDistance : PhysicsConstraintBase
    {
        public PhysicsBody BodyA;
        public PhysicsBody BodyB;
        
        internal override Constraint Initialize(ManagedPhysicsContext context)
        {
            var settings = DistanceConstraintSettings.Create();
            
            settings.SetPoint1(default);
            settings.SetPoint2(default);
            settings.SetSpace(ConstraintSpace.LocalToBodyCOM);

            var ba = context.ManagedToNative[BodyA];
            var bb = context.ManagedToNative[BodyB];
            
            return settings.CreateConstraint(ba, bb);
        }

    }
}
