namespace Jolt
{
    [GenerateHandle("JPH_DistanceConstraint"), GenerateBindings("JPH_Constraint"), GenerateBindings("JPH_DistanceConstraint")]
    public readonly partial struct DistanceConstraint
    {
        internal readonly NativeHandle<JPH_DistanceConstraint> Handle;

        internal DistanceConstraint(NativeHandle<JPH_DistanceConstraint> handle)
        {
            Handle = handle;
        }
    }
}
