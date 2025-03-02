namespace Jolt
{
    /// <summary>
    /// A widened ConvexShape instance handle.
    /// </summary>
    [GenerateBindings("JPH_ConvexShape", "JPH_Shape")]
    public partial struct ConvexShape
    {
        internal NativeHandle<JPH_ConvexShape> Handle;
        
        public static implicit operator ConvexShape(BoxShape shape)
        {
            return new ConvexShape { Handle = shape.Handle.Reinterpret<JPH_ConvexShape>() };
        }

        public static implicit operator ConvexShape(CapsuleShape shape)
        {
            return new ConvexShape { Handle = shape.Handle.Reinterpret<JPH_ConvexShape>() };
        }

        public static implicit operator ConvexShape(ConvexHullShape shape)
        {
            return new ConvexShape { Handle = shape.Handle.Reinterpret<JPH_ConvexShape>() };
        }

        public static implicit operator ConvexShape(CylinderShape shape)
        {
            return new ConvexShape { Handle = shape.Handle.Reinterpret<JPH_ConvexShape>() };
        }

        public static implicit operator ConvexShape(SphereShape shape)
        {
            return new ConvexShape { Handle = shape.Handle.Reinterpret<JPH_ConvexShape>() };
        }

        public static implicit operator ConvexShape(TaperedCapsuleShape shape)
        {
            return new ConvexShape { Handle = shape.Handle.Reinterpret<JPH_ConvexShape>() };
        }
    }
}
