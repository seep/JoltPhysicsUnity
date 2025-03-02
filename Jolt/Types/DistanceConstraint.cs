using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_DistanceConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public partial struct DistanceConstraint
    {
        internal NativeHandle<JPH_DistanceConstraint> Handle;
        
        public static DistanceConstraint Create(ref DistanceConstraintSettings settings, Body bodyA, Body bodyB)
        {
            return new DistanceConstraint { Handle = JPH_DistanceConstraint_Create(ref settings, bodyA.Handle, bodyB.Handle) };
        }
    }
}
