using System;
using Unity.Mathematics;
using static Jolt.SafeBindings;

namespace Jolt
{
    public readonly struct ConvexHullShapeSettings : IConvexShapeSettings, IDisposable, IEquatable<ConvexHullShapeSettings>
    {
        internal readonly NativeHandle<JPH_ConvexHullShapeSettings> Handle;

        internal ConvexHullShapeSettings(NativeHandle<JPH_ConvexHullShapeSettings> handle)
        {
            Handle = handle;
        }

        #region JPH_ConvexHullShapeSettings

        /// <summary>
        /// Allocate a new native ConvexHullShapeSettings and return the handle.
        /// </summary>
        public static ConvexHullShapeSettings Create(ReadOnlySpan<float3> points, float maxConvexRadius)
        {
            return new ConvexHullShapeSettings(JPH_ConvexHullShapeSettings_Create(points, maxConvexRadius));
        }

        /// <summary>
        /// Allocate a new native CapsuleShape from these settings and return the handle.
        /// </summary>
        public ConvexHullShape CreateShape()
        {
            return new ConvexHullShape(JPH_ConvexHullShapeSettings_CreateShape(Handle));
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

        public bool Equals(ConvexHullShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is ConvexHullShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(ConvexHullShapeSettings lhs, ConvexHullShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ConvexHullShapeSettings lhs, ConvexHullShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
