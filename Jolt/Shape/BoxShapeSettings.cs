using System;
using Unity.Mathematics;

using static Jolt.SafeBindings;

namespace Jolt
{
    public readonly struct BoxShapeSettings : IConvexShapeSettings, IDisposable, IEquatable<BoxShapeSettings>
    {
        internal readonly NativeHandle<JPH_BoxShapeSettings> Handle;

        internal BoxShapeSettings(NativeHandle<JPH_BoxShapeSettings> handle)
        {
            Handle = handle;
        }

        #region JPH_BoxShapeSettings

        /// <summary>
        /// Allocate a new native BoxShapeSettings and return the handle.
        /// </summary>
        public static BoxShapeSettings Create(float3 halfExtent, float convexRadius = PhysicsSettings.DefaultConvexRadius)
        {
            return new BoxShapeSettings(JPH_BoxShapeSettings_Create(halfExtent, convexRadius));
        }

        /// <summary>
        /// Allocate a new native BoxShape from these shape settings and return the handle.
        /// </summary>
        public BoxShape CreateShape()
        {
            return new BoxShape(JPH_BoxShapeSettings_CreateShape(Handle));
        }

        #endregion

        #region JPH_ConvexShapeSettings

        /// <inheritdoc/>
        public float GetDensity()
        {
            return JPH_ConvexShapeSettings_GetDensity(Handle);
        }

        /// <inheritdoc/>
        public void SetDensity(float density)
        {
            JPH_ConvexShapeSettings_SetDensity(Handle, density);
        }

        #endregion

        /// <summary>
        /// Dispose the native object.
        /// </summary>
        public void Dispose()
        {
            JPH_ShapeSettings_Destroy(Handle);
        }

        #region IEquatable

        public bool Equals(BoxShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is BoxShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(BoxShapeSettings lhs, BoxShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(BoxShapeSettings lhs, BoxShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
