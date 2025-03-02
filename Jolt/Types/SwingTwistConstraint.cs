using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_SwingTwistConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public partial struct SwingTwistConstraint
    {
        internal NativeHandle<JPH_SwingTwistConstraint> Handle;

        public static SwingTwistConstraint Create(ref SwingTwistConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new SwingTwistConstraint { Handle = JPH_SwingTwistConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle) };
        }
    }
}
