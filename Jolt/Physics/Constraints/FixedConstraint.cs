namespace Jolt
{
    [GenerateHandle("JPH_FixedConstraint"), GenerateBindings("JPH_Constraint"), GenerateBindings("JPH_FixedConstraint")]
    public readonly partial struct FixedConstraint
    {
        internal readonly NativeHandle<JPH_FixedConstraint> Handle;

        internal FixedConstraint(NativeHandle<JPH_FixedConstraint> handle)
        {
            Handle = handle;
        }
    }
}
