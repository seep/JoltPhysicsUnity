using System;
using Unity.Mathematics;

using static Jolt.JoltAPI;

namespace Jolt
{
    public struct BodyCreationSettings : IDisposable, IEquatable<BodyCreationSettings>
    {
        internal NativeHandle<JPH_BodyCreationSettings> Handle;

        #region JPH_BodyCreationSettings

        public static BodyCreationSettings Create()
        {
            return new BodyCreationSettings { Handle = JPH_BodyCreationSettings_Create() };
        }

        public static BodyCreationSettings FromShapeSettings(ShapeSettings settings, rvec3 position, quaternion rotation, MotionType motion, ushort layer)
        {
            return new BodyCreationSettings { Handle = JPH_BodyCreationSettings_Create2(settings.Handle, position, rotation, motion, layer) };
        }

        public static BodyCreationSettings FromShape(Shape shape, rvec3 position, quaternion rotation, MotionType motion, ushort layer)
        {
            return new BodyCreationSettings { Handle = JPH_BodyCreationSettings_Create3(shape.Handle, position, rotation, motion, layer) };
        }

        public float3 GetLinearVelocity()
        {
            return JPH_BodyCreationSettings_GetLinearVelocity(Handle);
        }

        public void SetLinearVelocity(in float3 value)
        {
            JPH_BodyCreationSettings_SetLinearVelocity(Handle, value);
        }

        public float3 GetAngularVelocity()
        {
            return JPH_BodyCreationSettings_GetAngularVelocity(Handle);
        }

        public void SetAngularVelocity(in float3 value)
        {
            JPH_BodyCreationSettings_SetAngularVelocity(Handle, value);
        }

        public MotionType GetMotionType()
        {
            return JPH_BodyCreationSettings_GetMotionType(Handle);
        }

        public void SetMotionType(MotionType value)
        {
            JPH_BodyCreationSettings_SetMotionType(Handle, value);
        }

        public AllowedDOFs GetAllowedDOFs()
        {
            return JPH_BodyCreationSettings_GetAllowedDOFs(Handle);
        }

        public void SetAllowedDOFs(AllowedDOFs value)
        {
            JPH_BodyCreationSettings_SetAllowedDOFs(Handle, value);
        }

        #endregion

        public void Dispose()
        {
            JPH_BodyCreationSettings_Destroy(Handle);
        }

        #region IEquatable

        public static bool operator ==(BodyCreationSettings lhs, BodyCreationSettings rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(BodyCreationSettings lhs, BodyCreationSettings rhs)
        {
            return !lhs.Equals(rhs);
        }

        public bool Equals(BodyCreationSettings other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is BodyCreationSettings other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
