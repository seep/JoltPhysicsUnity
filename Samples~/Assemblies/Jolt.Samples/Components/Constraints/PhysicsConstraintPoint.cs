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

            settings.Point1 = Point;
            settings.Point2 = Point;

            var ba = BodyA.NativeBody!.Value;
            var bb = BodyB.NativeBody!.Value;

            return PointConstraint.Create(ref settings, ba, bb);
        }
    }
}