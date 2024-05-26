using System;
using static Jolt.SafeBindings;

namespace Jolt
{
    public readonly struct CylinderShapeSettings : IConvexShapeSettings, IDisposable, IEquatable<CylinderShapeSettings>
    {
        internal readonly NativeHandle<JPH_CylinderShapeSettings> Handle;

        internal CylinderShapeSettings(NativeHandle<JPH_CylinderShapeSettings> handle)
        {
            Handle = handle;
        }

        #region JPH_CylinderShapeSettings

        /// <summary>
        /// Allocate a new native CylinderShapeSettings and return the handle.
        /// </summary>
        public static CylinderShapeSettings Create(float halfHeight, float radius, float convexRadius)
        {
            // TODO JPH_CylinderShapeSettings_Create takes convex radius but JPH_CylinderShape_Create does not?

            return new CylinderShapeSettings(JPH_CylinderShapeSettings_Create(halfHeight, radius, convexRadius));
        }

        /// <summary>
        /// Allocate a new native CylinderShape from these settings and return the handle.
        /// </summary>
        public CylinderShape CreateShape()
        {
            throw new NotImplementedException(); // TODO JPH_CylinderShapeSettings_CreateShape is missing from bindings?
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

        public static bool operator ==(CylinderShapeSettings lhs, CylinderShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(CylinderShapeSettings lhs, CylinderShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(CylinderShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is CylinderShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
