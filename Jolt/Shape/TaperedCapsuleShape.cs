using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

namespace Jolt
{
    public readonly struct TaperedCapsuleShape : IConvexShape, IDisposable, IEquatable<TaperedCapsuleShape>
    {
        internal readonly NativeHandle<JPH_ConvexShape> Handle; // TODO no JPH_TaperedCapsuleShape struct?

        internal TaperedCapsuleShape(NativeHandle<JPH_ConvexShape> handle)
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

        /// <summary>
        /// Dispose the native object.
        /// </summary>
        public void Dispose()
        {
            JPH_Shape_Destroy(Handle.Reinterpret<JPH_Shape>());
        }

        #region IEquatable

        public static bool operator ==(TaperedCapsuleShape lhs, TaperedCapsuleShape rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TaperedCapsuleShape lhs, TaperedCapsuleShape rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(TaperedCapsuleShape other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is TaperedCapsuleShape other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
