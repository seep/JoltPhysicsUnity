using System;
using static Jolt.SafeBindings;

namespace Jolt
{
    public readonly struct TaperedCapsuleShapeSettings : IConvexShapeSettings, IDisposable, IEquatable<TaperedCapsuleShapeSettings>
    {
        internal readonly NativeHandle<JPH_TaperedCapsuleShapeSettings> Handle;

        internal TaperedCapsuleShapeSettings(NativeHandle<JPH_TaperedCapsuleShapeSettings> handle)
        {
            Handle = handle;
        }

        #region JPH_TaperedCapsuleShapeSettings

        /// <summary>
        /// Allocate a new native TaperedCapsuleShapeSettings and return the handle.
        /// </summary>
        public static TaperedCapsuleShapeSettings Create(float halfHeightOfCylinder, float topRadius, float bottomRadius)
        {
            return new TaperedCapsuleShapeSettings(JPH_TaperedCapsuleShapeSettings_Create(halfHeightOfCylinder, topRadius, bottomRadius));
        }

        /// <summary>
        /// Allocate a new native TaperedCapsuleShape from these settings and return the handle.
        /// </summary>
        public TaperedCapsuleShape CreateShape()
        {
            throw new NotImplementedException(); // TODO JPH_TaperedCapsuleShapeSettings_CreateShape is missing from bindings?
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

        public static bool operator ==(TaperedCapsuleShapeSettings lhs, TaperedCapsuleShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TaperedCapsuleShapeSettings lhs, TaperedCapsuleShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(TaperedCapsuleShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is TaperedCapsuleShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
