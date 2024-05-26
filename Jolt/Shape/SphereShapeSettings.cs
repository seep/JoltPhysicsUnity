using System;
using static Jolt.SafeBindings;

namespace Jolt
{
    public readonly struct SphereShapeSettings : IConvexShapeSettings, IDisposable, IEquatable<SphereShapeSettings>
    {
        internal readonly NativeHandle<JPH_SphereShapeSettings> Handle;

        internal SphereShapeSettings(NativeHandle<JPH_SphereShapeSettings> handle)
        {
            Handle = handle;
        }

        #region JPH_SphereShapeSettings

        /// <summary>
        /// Allocate a new native SphereShapeSettings and return the handle.
        /// </summary>
        public static SphereShapeSettings Create(float radius)
        {
            return new SphereShapeSettings(JPH_SphereShapeSettings_Create(radius));
        }

        /// <summary>
        /// Allocate a new native SphereShape from these settings and return the handle.
        /// </summary>
        public SphereShape CreateShape()
        {
            return new SphereShape(JPH_SphereShapeSettings_CreateShape(Handle));
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

        public bool Equals(SphereShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is SphereShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(SphereShapeSettings lhs, SphereShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(SphereShapeSettings lhs, SphereShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
