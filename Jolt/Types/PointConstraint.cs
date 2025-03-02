using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_PointConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct PointConstraint
    {
        internal readonly NativeHandle<JPH_PointConstraint> Handle;

        internal PointConstraint(NativeHandle<JPH_PointConstraint> handle) => Handle = handle;

        public static PointConstraint Create(ref PointConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new PointConstraint(JPH_PointConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}
