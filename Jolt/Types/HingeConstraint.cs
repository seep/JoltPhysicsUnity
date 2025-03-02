using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_HingeConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct HingeConstraint
    {
        internal readonly NativeHandle<JPH_HingeConstraint> Handle;

        internal HingeConstraint(NativeHandle<JPH_HingeConstraint> handle) => Handle = handle;

        public static HingeConstraint Create(ref HingeConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new HingeConstraint(JPH_HingeConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}
