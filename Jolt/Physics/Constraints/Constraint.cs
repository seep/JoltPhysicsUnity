namespace Jolt
{
    [GenerateHandle("JPH_Constraint"), GenerateBindings("JPH_Constraint")]
    public readonly partial struct Constraint
    {
        internal readonly NativeHandle<JPH_Constraint> Handle;

        internal Constraint(NativeHandle<JPH_Constraint> handle)
        {
            Handle = handle;
        }
    }
}
