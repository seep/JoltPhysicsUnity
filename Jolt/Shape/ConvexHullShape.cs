namespace Jolt
{
    [GenerateHandle("JPH_ConvexHullShape"), GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_ConvexHullShape")]
    public readonly partial struct ConvexHullShape
    {
        internal readonly NativeHandle<JPH_ConvexHullShape> Handle;

        internal ConvexHullShape(NativeHandle<JPH_ConvexHullShape> handle)
        {
            Handle = handle;
        }
    }
}
