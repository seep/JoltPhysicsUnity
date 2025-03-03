using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_SixDOFConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public partial struct SixDOFConstraint
    {
        internal NativeHandle<JPH_SixDOFConstraint> Handle;

        public static SixDOFConstraint Create(ref SixDOFConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new SixDOFConstraint { Handle = JPH_SixDOFConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle) };
        }
    }
}
