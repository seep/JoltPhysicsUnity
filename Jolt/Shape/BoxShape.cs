using System;
using Unity.Mathematics;

using static Jolt.JoltAPI;

namespace Jolt
{
    public readonly struct BoxShape : IConvexShape, IDisposable, IEquatable<BoxShape>
    {
        internal readonly NativeHandle<JPH_BoxShape> Handle;

        internal BoxShape(NativeHandle<JPH_BoxShape> handle)
        {
            Handle = handle;
        }

        #region JPH_BoxShape

        /// <summary>
        /// Allocate a new native BoxShape and return the handle.
        /// </summary>
        public static BoxShape Create(in float3 halfExtent, float convexRadius = PhysicsSettings.DefaultConvexRadius)
        {
            return new BoxShape(JPH_BoxShape_Create(halfExtent, convexRadius));
        }

        public float3 GetHalfExtent()
        {
            return JPH_BoxShape_GetHalfExtent(Handle);
        }

        public float GetVolume()
        {
            return JPH_BoxShape_GetVolume(Handle);
        }

        public float GetConvexRadius()
        {
            return JPH_BoxShape_GetConvexRadius(Handle);
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

        /// <summary>
        /// Dispose the native object.
        /// </summary>
        public void Dispose()
        {
            JPH_Shape_Destroy(Handle);
        }

        #region IEquatable

        public static bool operator ==(BoxShape lhs, BoxShape rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(BoxShape lhs, BoxShape rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(BoxShape other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is BoxShape other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
