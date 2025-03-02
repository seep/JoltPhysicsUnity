using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_PointConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public partial struct PointConstraint
    {
        internal NativeHandle<JPH_PointConstraint> Handle;

        public static PointConstraint Create(ref PointConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new PointConstraint { Handle = JPH_PointConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle) };
        }
    }
}
