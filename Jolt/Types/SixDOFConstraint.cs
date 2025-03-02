using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_SixDOFConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct SixDOFConstraint
    {
        internal readonly NativeHandle<JPH_SixDOFConstraint> Handle;

        internal SixDOFConstraint(NativeHandle<JPH_SixDOFConstraint> handle) => Handle = handle;

        public static SixDOFConstraint Create(ref SixDOFConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new SixDOFConstraint(JPH_SixDOFConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle));
        }
    }
}