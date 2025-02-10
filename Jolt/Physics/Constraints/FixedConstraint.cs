using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_FixedConstraint"), GenerateBindings("JPH_FixedConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct FixedConstraint
    {
        public static FixedConstraint Create(ref FixedConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new FixedConstraint(JPH_FixedConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}
