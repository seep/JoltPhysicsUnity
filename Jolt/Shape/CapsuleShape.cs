using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

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

        public static bool operator ==(CapsuleShape lhs, CapsuleShape rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(CapsuleShape lhs, CapsuleShape rhs)
        {
            return !lhs.Equals(rhs);
        }

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

        #endregion
    }
}
