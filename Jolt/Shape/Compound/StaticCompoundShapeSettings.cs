using System;
using Unity.Mathematics;
using static Jolt.SafeBindings;

namespace Jolt
{
    public readonly struct StaticCompoundShapeSettings : IShapeSettings, IDisposable, IEquatable<StaticCompoundShapeSettings>
    {
        internal readonly NativeHandle<JPH_StaticCompoundShapeSettings> Handle;

        internal StaticCompoundShapeSettings(NativeHandle<JPH_StaticCompoundShapeSettings> handle)
        {
            Handle = handle;
        }

        #region JPH_StaticCompoundShapeSettings

        public static StaticCompoundShapeSettings Create()
        {
            return new StaticCompoundShapeSettings(JPH_StaticCompoundShapeSettings_Create());
        }

        #endregion

        #region JPH_CompoundShapeSettings

        public void AddShape(float3 position, quaternion rotation, ShapeSettings shape, uint userData = 0)
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

        public static bool operator ==(StaticCompoundShapeSettings lhs, StaticCompoundShapeSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(StaticCompoundShapeSettings lhs, StaticCompoundShapeSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(StaticCompoundShapeSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is StaticCompoundShapeSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
