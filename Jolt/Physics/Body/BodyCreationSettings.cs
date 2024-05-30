using System;
using Unity.Mathematics;

using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle]
    public readonly partial struct BodyCreationSettings : IDisposable
    {
        internal readonly NativeHandle<JPH_BodyCreationSettings> Handle;

        internal BodyCreationSettings(NativeHandle<JPH_BodyCreationSettings> handle)
        {
            Handle = handle;
        }

        #region JPH_BodyCreationSettings

        public static BodyCreationSettings Create()
        {
            return new BodyCreationSettings(JPH_BodyCreationSettings_Create());
        }

        public static BodyCreationSettings FromShapeSettings(ShapeSettings settings, rvec3 position, quaternion rotation, MotionType motion, ushort layer)
        {
            return new BodyCreationSettings(JPH_BodyCreationSettings_Create2(settings.Handle, position, rotation, motion, layer));
        }

        public static BodyCreationSettings FromShape(Shape shape, rvec3 position, quaternion rotation, MotionType motion, ushort layer)
        {
            return new BodyCreationSettings(JPH_BodyCreationSettings_Create3(shape.Handle, position, rotation, motion, layer));
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
    }
}
