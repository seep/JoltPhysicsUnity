namespace Jolt
{
    [GenerateHandle("JPH_HingeConstraint"), GenerateBindings("JPH_Constraint"), GenerateBindings("JPH_HingeConstraint")]
    public readonly partial struct HingeConstraint
    {
        internal readonly NativeHandle<JPH_HingeConstraint> Handle;

        internal HingeConstraint(NativeHandle<JPH_HingeConstraint> handle)
        {
            Handle = handle;
        }
    }
}
