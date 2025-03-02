namespace Jolt
{
    /// <summary>
    /// Generic ShapeSettings interface for a native ShapeSettings instance.
    /// </summary>
    [GenerateBindings("JPH_ShapeSettings")]
    public partial struct ShapeSettings
    {
        internal NativeHandle<JPH_ShapeSettings> Handle;
        
        /// <summary>
        /// Reinterpret BoxShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(BoxShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }

        /// <summary>
        /// Reinterpret PlaneShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(PlaneShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }
        
        /// <summary>
        /// Reinterpret CapsuleShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(CapsuleShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }

        /// <summary>
        /// Reinterpret ConvexHullShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(ConvexHullShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }

        /// <summary>
        /// Reinterpret CylinderShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(CylinderShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }

        /// <summary>
        /// Reinterpret MeshShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(MeshShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }

        /// <summary>
        /// Reinterpret SphereShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(SphereShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }

        /// <summary>
        /// Reinterpret TaperedCapsuleShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(TaperedCapsuleShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }

        /// <summary>
        /// Reinterpret CompoundShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(CompoundShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }

        /// <summary>
        /// Reinterpret StaticCompoundShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(StaticCompoundShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }

        /// <summary>
        /// Reinterpret MutableCompoundShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(MutableCompoundShapeSettings settings)
        {
            return new ShapeSettings { Handle = settings.Handle.Reinterpret<JPH_ShapeSettings>() };
        }
    }
}
