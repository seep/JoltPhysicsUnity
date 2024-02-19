using System;

namespace Jolt
{
    /// <summary>
    /// Generic ShapeSettings interface for a native ShapeSettings instance.
    /// </summary>
    public readonly struct ShapeSettings : IEquatable<ShapeSettings>
    {
        internal readonly NativeHandle<JPH_ShapeSettings> Handle;

        internal ShapeSettings(NativeHandle<JPH_ShapeSettings> handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Reinterpret BoxShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(BoxShapeSettings settings)
        {
            return new ShapeSettings(settings.Handle.Reinterpret<JPH_ShapeSettings>());
        }

        /// <summary>
        /// Reinterpret CapsuleShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(CapsuleShapeSettings settings)
        {
            return new ShapeSettings(settings.Handle.Reinterpret<JPH_ShapeSettings>());
        }

        /// <summary>
        /// Reinterpret ConvexHullShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(ConvexHullShapeSettings settings)
        {
            return new ShapeSettings(settings.Handle.Reinterpret<JPH_ShapeSettings>());
        }

        /// <summary>
        /// Reinterpret CylinderShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(CylinderShapeSettings settings)
        {
            return new ShapeSettings(settings.Handle.Reinterpret<JPH_ShapeSettings>());
        }

        /// <summary>
        /// Reinterpret MeshShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(MeshShapeSettings settings)
        {
            return new ShapeSettings(settings.Handle.Reinterpret<JPH_ShapeSettings>());
        }

        /// <summary>
        /// Reinterpret SphereShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(SphereShapeSettings settings)
        {
            return new ShapeSettings(settings.Handle.Reinterpret<JPH_ShapeSettings>());
        }

        /// <summary>
        /// Reinterpret TaperedCapsuleShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(TaperedCapsuleShapeSettings settings)
        {
            return new ShapeSettings(settings.Handle.Reinterpret<JPH_ShapeSettings>());
        }

        /// <summary>
        /// Reinterpret CompoundShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(CompoundShapeSettings settings)
        {
            return new ShapeSettings(settings.Handle.Reinterpret<JPH_ShapeSettings>());
        }

        /// <summary>
        /// Reinterpret StaticCompoundShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(StaticCompoundShapeSettings settings)
        {
            return new ShapeSettings(settings.Handle.Reinterpret<JPH_ShapeSettings>());
        }

        /// <summary>
        /// Reinterpret MutableCompoundShapeSettings as a generic ShapeSettings instance.
        /// </summary>
        /// <remarks>
        /// This does not reallocate the shape settings; the underlying pointer is the same.
        /// </remarks>
        public static implicit operator ShapeSettings(MutableCompoundShapeSettings settings)
        {
            return new ShapeSettings(settings.Handle.Reinterpret<JPH_ShapeSettings>());
        }

        #region IEquatable

        public static bool operator ==(ShapeSettings lhs, ShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ShapeSettings lhs, ShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(ShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is ShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
