using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

namespace Jolt
{
    public readonly struct MeshShape: IShape, IDisposable, IEquatable<MeshShape>
    {
        internal readonly NativeHandle<JPH_MeshShape> Handle;

        internal MeshShape(NativeHandle<JPH_MeshShape> handle)
        {
            Handle = handle;
        }

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

        public void Dispose()
        {
            JPH_Shape_Destroy(Handle);
        }

        #region IEquatable

        public static bool operator ==(MeshShape lhs, MeshShape rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(MeshShape lhs, MeshShape rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(MeshShape other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is MeshShape other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
