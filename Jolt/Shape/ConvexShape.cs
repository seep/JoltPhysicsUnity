using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

namespace Jolt
{
    /// <summary>
    /// Generic Shape instance handle.
    /// </summary>
    public readonly struct ConvexShape : IConvexShape, IDisposable, IEquatable<ConvexShape>
    {
        internal readonly NativeHandle<JPH_ConvexShape> Handle;

        internal ConvexShape(NativeHandle<JPH_ConvexShape> handle)
        {
            Handle = handle;
        }

        #region Reinterpreting

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

        #endregion

        #region JPH_ConvexShape

        /// <inheritdoc/>
        public float GetDensity()
        {
            return JPH_ConvexShape_GetDensity(Handle);
        }

        /// <inheritdoc/>
        public void SetDensity(float density)
        {
            JPH_ConvexShape_SetDensity(Handle, density);
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

        public static bool operator ==(ConvexShape lhs, ConvexShape rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ConvexShape lhs, ConvexShape rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(ConvexShape other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is ConvexShape other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
