using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_SwingTwistConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct SwingTwistConstraint
    {
        internal readonly NativeHandle<JPH_SwingTwistConstraint> Handle;

        internal SwingTwistConstraint(NativeHandle<JPH_SwingTwistConstraint> handle) => Handle = handle;

        public static SwingTwistConstraint Create(ref SwingTwistConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new SwingTwistConstraint(JPH_SwingTwistConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}