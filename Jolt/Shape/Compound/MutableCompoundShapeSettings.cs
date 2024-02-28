using System;
using Unity.Mathematics;
using static Jolt.JoltAPI;

namespace Jolt
{
    public readonly struct MutableCompoundShapeSettings : IShapeSettings, IDisposable, IEquatable<MutableCompoundShapeSettings>
    {
        internal readonly NativeHandle<JPH_MutableCompoundShapeSettings> Handle;

        internal MutableCompoundShapeSettings(NativeHandle<JPH_MutableCompoundShapeSettings> handle)
        {
            Handle = handle;
        }

        #region JPH_MutableCompoundShapeSettings

        public static MutableCompoundShapeSettings Create()
        {
            return new MutableCompoundShapeSettings(JPH_MutableCompoundShapeSettings_Create());
        }

        #endregion

        #region JPH_CompoundShapeSettings

        public void AddShape(float3 position, quaternion rotation, ShapeSettings shape, uint userData)
        {
            JPH_CompoundShapeSettings_AddShape(Handle, position, rotation, shape.Handle, userData);
        }

        public void AddShape(float3 position, quaternion rotation, Shape shape, uint userData)
        {
            JPH_CompoundShapeSettings_AddShape2(Handle, position, rotation, shape.Handle, userData);
        }

        #endregion

        public void Dispose()
        {
            JPH_ShapeSettings_Destroy(Handle);
        }

        #region IEquatable

        public static bool operator ==(MutableCompoundShapeSettings lhs, MutableCompoundShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(MutableCompoundShapeSettings lhs, MutableCompoundShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(MutableCompoundShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is MutableCompoundShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
