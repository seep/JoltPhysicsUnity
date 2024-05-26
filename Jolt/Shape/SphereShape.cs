using System;
using Unity.Mathematics;
using static Jolt.SafeBindings;

namespace Jolt
{
    public readonly struct SphereShape : IConvexShape, IDisposable, IEquatable<SphereShape>
    {
        internal readonly NativeHandle<JPH_SphereShape> Handle;

        internal SphereShape(NativeHandle<JPH_SphereShape> handle)
        {
            Handle = handle;
        }

        #region JPH_SphereShape

        /// <summary>
        /// Allocate a new native SphereShape and return the handle.
        /// </summary>
        public static SphereShape Create(float radius)
        {
            return new SphereShape(JPH_SphereShape_Create(radius));
        }

        public float GetRadius()
        {
            return JPH_SphereShape_GetRadius(Handle);
        }

        #endregion

        #region JPH_ConvexShape

        /// <inheritdoc/>
        public float GetDensity() => JPH_ConvexShape_GetDensity(Handle);

        /// <inheritdoc/>
        public void SetDensity(float density) => JPH_ConvexShape_SetDensity(Handle, density);

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

        /// <summary>
        /// Dispose the native object.
        /// </summary>
        public void Dispose()
        {
            JPH_Shape_Destroy(Handle.Reinterpret<JPH_Shape>());
        }

        #region IEquatable

        public static bool operator ==(SphereShape lhs, SphereShape rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(SphereShape lhs, SphereShape rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(SphereShape other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is SphereShape other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
