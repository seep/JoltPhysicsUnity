namespace Jolt
{
    [GenerateHandle("JPH_PointConstraint"), GenerateBindings("JPH_Constraint"), GenerateBindings("JPH_PointConstraint")]
    public readonly partial struct PointConstraint
    {
        internal readonly NativeHandle<JPH_PointConstraint> Handle;

        internal PointConstraint(NativeHandle<JPH_PointConstraint> handle)
        {
            Handle = handle;
        }
    }
}
