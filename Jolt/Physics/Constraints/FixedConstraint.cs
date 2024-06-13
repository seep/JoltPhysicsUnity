namespace Jolt
{
    [GenerateHandle("JPH_FixedConstraint"), GenerateBindings("JPH_FixedConstraint")]
    public unsafe partial struct FixedConstraint
    {
        internal NativeHandle<JPH_FixedConstraint> Handle;

        internal FixedConstraint(NativeHandle<JPH_FixedConstraint> handle)
        {
            Handle = handle;
        }
    }
}
