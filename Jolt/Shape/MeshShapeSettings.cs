using System;
using Unity.Mathematics;
using static Jolt.SafeBindings;

namespace Jolt
{
    public readonly struct MeshShapeSettings : IShapeSettings, IDisposable, IEquatable<MeshShapeSettings>
    {
        internal readonly NativeHandle<JPH_MeshShapeSettings> Handle;

        internal MeshShapeSettings(NativeHandle<JPH_MeshShapeSettings> handle)
        {
            Handle = handle;
        }

        #region JPH_MeshShapeSettings

        /// <summary>
        /// Allocate a new native MeshShapeSettings and return the handle.
        /// </summary>
        public static MeshShapeSettings Create(ReadOnlySpan<float3> vertices, ReadOnlySpan<IndexedTriangle> triangles)
        {
            return new MeshShapeSettings(JPH_MeshShapeSettings_Create2(vertices, triangles));
        }

        /// <summary>
        /// Allocate a new native MeshShape from these settings and return the handle.
        /// </summary>
        public MeshShape CreateShape()
        {
            return new MeshShape(JPH_MeshShapeSettings_CreateShape(Handle));
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

        public bool Equals(MeshShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is MeshShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(MeshShapeSettings lhs, MeshShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(MeshShapeSettings lhs, MeshShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
