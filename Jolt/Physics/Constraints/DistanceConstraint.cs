using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_DistanceConstraint"), GenerateBindings("JPH_DistanceConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct DistanceConstraint
    {
        public static DistanceConstraint Create(ref DistanceConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new DistanceConstraint(JPH_DistanceConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}
