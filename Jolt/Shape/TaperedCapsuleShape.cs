namespace Jolt
{
    [GenerateHandle("JPH_ConvexShape"), GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape"), GenerateBindings("JPH_TaperedCapsuleShape")]
    public readonly partial struct TaperedCapsuleShape
    {
        internal readonly NativeHandle<JPH_ConvexShape> Handle; // TODO no JPH_TaperedCapsuleShape struct?

        internal TaperedCapsuleShape(NativeHandle<JPH_ConvexShape> handle)
        {
            Handle = handle;
        }

        // TODO no JPH_TaperedCapsuleShape_Create binding?
    }
}
