using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_SixDOFConstraint"), GenerateBindings("JPH_SixDOFConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct SixDOFConstraint
    {
        public static SixDOFConstraint Create(ref SixDOFConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new SixDOFConstraint(JPH_SixDOFConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}