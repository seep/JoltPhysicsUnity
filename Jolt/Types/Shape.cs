namespace Jolt
{
    /// <summary>
    /// A widened Shape instance handle.
    /// </summary>
    [GenerateBindings("JPH_Shape")]
    public partial struct Shape
    {
        internal NativeHandle<JPH_Shape> Handle;
        
        public static implicit operator Shape(BoxShape shape)
        {
            return new Shape { Handle = shape.Handle.Reinterpret<JPH_Shape>() };
        }

        public static implicit operator Shape(CapsuleShape shape)
        {
            return new Shape { Handle = shape.Handle.Reinterpret<JPH_Shape>() };
        }

        public static implicit operator Shape(ConvexShape shape)
        {
            return new Shape { Handle = shape.Handle.Reinterpret<JPH_Shape>() };
        }

        public static implicit operator Shape(ConvexHullShape shape)
        {
            return new Shape { Handle = shape.Handle.Reinterpret<JPH_Shape>() };
        }

        public static implicit operator Shape(CylinderShape shape)
        {
            return new Shape { Handle = shape.Handle.Reinterpret<JPH_Shape>() };
        }

        public static implicit operator Shape(MeshShape shape)
        {
            return new Shape { Handle = shape.Handle.Reinterpret<JPH_Shape>() };
        }

        public static implicit operator Shape(SphereShape shape)
        {
            return new Shape { Handle = shape.Handle.Reinterpret<JPH_Shape>() };
        }

        public static implicit operator Shape(TaperedCapsuleShape shape)
        {
            return new Shape { Handle = shape.Handle.Reinterpret<JPH_Shape>() };
        }
    }
}
