namespace Jolt
{
    /// <summary>
    /// A widened Shape instance handle.
    /// </summary>
    [GenerateHandle("JPH_Shape"), GenerateBindings("JPH_Shape")]
    public readonly partial struct Shape
    {
        public static implicit operator Shape(BoxShape shape)
        {
            return new Shape(shape.Handle.Reinterpret<JPH_Shape>());
        }

        public static implicit operator Shape(CapsuleShape shape)
        {
            return new Shape(shape.Handle.Reinterpret<JPH_Shape>());
        }

        public static implicit operator Shape(ConvexShape shape)
        {
            return new Shape(shape.Handle.Reinterpret<JPH_Shape>());
        }

        public static implicit operator Shape(ConvexHullShape shape)
        {
            return new Shape(shape.Handle.Reinterpret<JPH_Shape>());
        }

        public static implicit operator Shape(CylinderShape shape)
        {
            return new Shape(shape.Handle.Reinterpret<JPH_Shape>());
        }

        public static implicit operator Shape(MeshShape shape)
        {
            return new Shape(shape.Handle.Reinterpret<JPH_Shape>());
        }

        public static implicit operator Shape(SphereShape shape)
        {
            return new Shape(shape.Handle.Reinterpret<JPH_Shape>());
        }

        public static implicit operator Shape(TaperedCapsuleShape shape)
        {
            return new Shape(shape.Handle.Reinterpret<JPH_Shape>());
        }
    }
}
