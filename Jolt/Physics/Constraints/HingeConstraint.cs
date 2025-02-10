using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_HingeConstraint"), GenerateBindings("JPH_HingeConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct HingeConstraint
    {
        public static HingeConstraint Create(ref HingeConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new HingeConstraint(JPH_HingeConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}
