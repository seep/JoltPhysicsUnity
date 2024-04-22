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
        public new ShapeType GetType() => JPH_Shape_GetType(Handle);

        /// <inheritdoc/>
        public ShapeSubType GetSubType() => JPH_Shape_GetSubType(Handle);

        /// <inheritdoc/>
        public ulong GetUserData() => JPH_Shape_GetUserData(Handle);

        /// <inheritdoc/>
        public void SetUserData(ulong userData) => JPH_Shape_SetUserData(Handle, userData);

        /// <inheritdoc/>
        public bool MustBeStatic() => JPH_Shape_MustBeStatic(Handle);

        /// <inheritdoc/>
        public float3 GetCenterOfMass() => JPH_Shape_GetCenterOfMass(Handle);

        /// <inheritdoc/>
        public AABox GetLocalBounds() => JPH_Shape_GetLocalBounds(Handle);

        /// <inheritdoc/>
        public AABox GetWorldSpaceBounds(rmatrix4x4 centerOfMassTransform, float3 scale) => JPH_Shape_GetWorldSpaceBounds(Handle, centerOfMassTransform, scale);

        /// <inheritdoc/>
        public float GetInnerRadius() => JPH_Shape_GetInnerRadius(Handle);

        /// <inheritdoc/>
        public MassProperties GetMassProperties() => JPH_Shape_GetMassProperties(Handle);

        /// <inheritdoc/>
        public float3 GetSurfaceNormal(uint subShapeID, float3 localPosition) => JPH_Shape_GetSurfaceNormal(Handle, subShapeID, localPosition);

        /// <inheritdoc/>
        public float GetVolume() => JPH_Shape_GetVolume(Handle);

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
