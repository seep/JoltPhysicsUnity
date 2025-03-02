using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_HingeConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public partial struct HingeConstraint
    {
        internal NativeHandle<JPH_HingeConstraint> Handle;

        public static HingeConstraint Create(ref HingeConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new HingeConstraint { Handle = JPH_HingeConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle) };
        }
    }
}
