using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_SliderConstraint"), GenerateBindings("JPH_SliderConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct SliderConstraint
    {
        public static SliderConstraint Create(ref SliderConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new SliderConstraint(JPH_SliderConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}
