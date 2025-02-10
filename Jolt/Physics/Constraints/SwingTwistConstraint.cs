using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_SwingTwistConstraint"), GenerateBindings("JPH_SwingTwistConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct SwingTwistConstraint
    {
        public static SwingTwistConstraint Create(ref SwingTwistConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new SwingTwistConstraint(JPH_SwingTwistConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}