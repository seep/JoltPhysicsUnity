using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_PointConstraint"), GenerateBindings("JPH_PointConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct PointConstraint
    {
        public static PointConstraint Create(ref PointConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new PointConstraint(JPH_PointConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}
