using System;
using static Jolt.SafeBindings;

namespace Jolt
{
    public readonly struct CapsuleShapeSettings : IConvexShapeSettings, IDisposable, IEquatable<CapsuleShapeSettings>
    {
        internal readonly NativeHandle<JPH_CapsuleShapeSettings> Handle;

        internal CapsuleShapeSettings(NativeHandle<JPH_CapsuleShapeSettings> handle)
        {
            Handle = handle;
        }

        #region JPH_CapsuleShapeSettings

        /// <summary>
        /// Allocate a new native CapsuleShapeSettings and return the handle.
        /// </summary>
        public static CapsuleShapeSettings Create(float halfHeightOfCylinder, float radius)
        {
            return new CapsuleShapeSettings(JPH_CapsuleShapeSettings_Create(halfHeightOfCylinder, radius));
        }

        /// <summary>
        /// Allocate a new native CapsuleShape from these settings and return the handle.
        /// </summary>
        public CapsuleShape CreateShape()
        {
            throw new NotImplementedException(); // TODO JPH_CapsuleShapeSettings_CreateShape is missing from bindings?
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

        public bool Equals(CapsuleShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is CapsuleShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(CapsuleShapeSettings lhs, CapsuleShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(CapsuleShapeSettings lhs, CapsuleShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
