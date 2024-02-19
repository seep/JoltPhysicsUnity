using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

namespace Jolt
{
    public readonly struct ConvexHullShape: IConvexShape, IDisposable, IEquatable<ConvexHullShape>
    {
        internal readonly NativeHandle<JPH_ConvexHullShape> Handle;

        internal ConvexHullShape(NativeHandle<JPH_ConvexHullShape> handle)
        {
            Handle = handle;
        }

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

        public static bool operator ==(ConvexHullShape lhs, ConvexHullShape rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ConvexHullShape lhs, ConvexHullShape rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(ConvexHullShape other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is ConvexHullShape other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
