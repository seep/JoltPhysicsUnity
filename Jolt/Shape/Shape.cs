using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

namespace Jolt
{
    /// <summary>
    /// Generic Shape instance handle.
    /// </summary>
    public readonly struct Shape : IShape, IDisposable, IEquatable<Shape>
    {
        internal readonly NativeHandle<JPH_Shape> Handle;

        internal Shape(NativeHandle<JPH_Shape> handle)
        {
            Handle = handle;
        }

        #region Reinterpreting

        public static implicit operator Shape(BoxShape shape)
        {
            return new Shape(shape.Handle.Reinterpret<JPH_Shape>());
        }

        public static implicit operator Shape(CapsuleShape shape)
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

        #endregion

        #region JPH_Shape

        /// <inheritdoc/>
        public AABox GetLocalBounds()
        {
            return JPH_Shape_GetLocalBounds(Handle);
        }

        /// <inheritdoc/>
        public MassProperties GetMassProperties()
        {
            return JPH_Shape_GetMassProperties(Handle);
        }

        /// <inheritdoc/>
        public float3 GetCenterOfMass()
        {
            return JPH_Shape_GetCenterOfMass(Handle);
        }

        /// <inheritdoc/>
        public float GetInnerRadius()
        {
            return JPH_Shape_GetInnerRadius(Handle);
        }

        #endregion

        public void Dispose()
        {
            JPH_Shape_Destroy(Handle);
        }

        #region IEquatable

        public static bool operator ==(Shape lhs, Shape rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Shape lhs, Shape rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(Shape other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is Shape other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
