using System;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle]
    public readonly partial struct CylinderShapeSettings : IConvexShapeSettings, IDisposable
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
    }
}
