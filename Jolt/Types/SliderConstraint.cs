using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_SliderConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public partial struct SliderConstraint
    {
        internal NativeHandle<JPH_SliderConstraint> Handle;

        public static SliderConstraint Create(ref SliderConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new SliderConstraint { Handle = JPH_SliderConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle) };
        }
    }
}
