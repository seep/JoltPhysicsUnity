using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

namespace Jolt
{
    public readonly struct CylinderShape: IConvexShape, IDisposable, IEquatable<CylinderShape>
    {
        internal readonly NativeHandle<JPH_CylinderShape> Handle;

        internal CylinderShape(NativeHandle<JPH_CylinderShape> handle)
        {
            Handle = handle;
        }

        #region JPH_CylinderShape

        /// <summary>
        /// Allocate a new native CylinderShape and return the handle.
        /// </summary>
        public static CylinderShape Create(float halfHeightOfCylinder, float radius)
        {
            return new CylinderShape(JPH_CylinderShape_Create(halfHeightOfCylinder, radius));
        }

        public float GetHalfHeight()
        {
            return JPH_CylinderShape_GetHalfHeight(Handle);
        }

        public float GetRadius()
        {
            return JPH_CylinderShape_GetRadius(Handle);
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

        public static bool operator ==(CylinderShape lhs, CylinderShape rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(CylinderShape lhs, CylinderShape rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(CylinderShape other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is CylinderShape other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
