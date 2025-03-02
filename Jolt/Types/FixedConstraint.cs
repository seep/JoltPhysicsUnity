using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_FixedConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public partial struct FixedConstraint
    {
        internal NativeHandle<JPH_FixedConstraint> Handle;

        public static FixedConstraint Create(ref FixedConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new FixedConstraint { Handle = JPH_FixedConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle) };
        }
    }
}
