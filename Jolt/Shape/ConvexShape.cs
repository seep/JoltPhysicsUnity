namespace Jolt
{
    /// <summary>
    /// A widened ConvexShape instance handle.
    /// </summary>
    [GenerateHandle, GenerateBindings("JPH_Shape"), GenerateBindings("JPH_ConvexShape")]
    public readonly partial struct ConvexShape : IConvexShape
    {
        internal readonly NativeHandle<JPH_ConvexShape> Handle;

        internal ConvexShape(NativeHandle<JPH_ConvexShape> handle)
        {
            Handle = handle;
        }

        public static implicit operator ConvexShape(BoxShape shape)
        {
            return new ConvexShape(shape.Handle.Reinterpret<JPH_ConvexShape>());
        }

        public static implicit operator ConvexShape(CapsuleShape shape)
        {
            return new ConvexShape(shape.Handle.Reinterpret<JPH_ConvexShape>());
        }

        public static implicit operator ConvexShape(ConvexHullShape shape)
        {
            return new ConvexShape(shape.Handle.Reinterpret<JPH_ConvexShape>());
        }

        public static implicit operator ConvexShape(CylinderShape shape)
        {
            return new ConvexShape(shape.Handle.Reinterpret<JPH_ConvexShape>());
        }

        public static implicit operator ConvexShape(SphereShape shape)
        {
            return new ConvexShape(shape.Handle.Reinterpret<JPH_ConvexShape>());
        }

        public static implicit operator ConvexShape(TaperedCapsuleShape shape)
        {
            return new ConvexShape(shape.Handle.Reinterpret<JPH_ConvexShape>());
        }
    }
}
