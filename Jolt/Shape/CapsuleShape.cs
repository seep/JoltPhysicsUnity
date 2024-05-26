using System;
using Unity.Mathematics;
using static Jolt.SafeBindings;

namespace Jolt
{
    public readonly struct CapsuleShape: IConvexShape, IDisposable, IEquatable<CapsuleShape>
    {
        internal readonly NativeHandle<JPH_CapsuleShape> Handle;

        internal CapsuleShape(NativeHandle<JPH_CapsuleShape> handle)
        {
            Handle = handle;
        }

        #region JPH_CapsuleShape

        /// <summary>
        /// Allocate a new native CapsuleShape and return the handle.
        /// </summary>
        public static CapsuleShape Create(float halfHeightOfCylinder, float radius)
        {
            return new CapsuleShape(JPH_CapsuleShape_Create(halfHeightOfCylinder, radius));
        }

        public float GetHalfHeightOfCylinder()
        {
            return JPH_CapsuleShape_GetHalfHeightOfCylinder(Handle);
        }

        public float GetRadius()
        {
            return JPH_CapsuleShape_GetRadius(Handle);
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

        public void Dispose()
        {
            JPH_Shape_Destroy(Handle);
        }

        #region IEquatable

        public bool Equals(CapsuleShape other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is CapsuleShape other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(CapsuleShape lhs, CapsuleShape rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(CapsuleShape lhs, CapsuleShape rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
