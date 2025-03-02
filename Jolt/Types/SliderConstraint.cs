using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_SliderConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct SliderConstraint
    {
        internal readonly NativeHandle<JPH_SliderConstraint> Handle;

        internal SliderConstraint(NativeHandle<JPH_SliderConstraint> handle) => Handle = handle;

        public static SliderConstraint Create(ref SliderConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new SliderConstraint(JPH_SliderConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}
