namespace Jolt
{
    [GenerateBindings("JPH_ConeConstraint", "JPH_TwoBodyConstraint", "JPH_Constraint")]
    public readonly partial struct ConeConstraint
    {
        internal readonly NativeHandle<JPH_ConeConstraint> Handle;
        
        internal ConeConstraint(NativeHandle<JPH_ConeConstraint> handle) => Handle = handle;
    }
}