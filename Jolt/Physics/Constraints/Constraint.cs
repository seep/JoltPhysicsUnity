using System;
using Unity.Mathematics;
using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle]
    public readonly partial struct Constraint : IDisposable
    {
        internal readonly NativeHandle<JPH_Constraint> Handle;

        internal Constraint(NativeHandle<JPH_Constraint> handle)
        {
            Handle = handle;
        }

        public void Dispose()
        {
            JPH_Constraint_Destroy(Handle);
        }

        #region JPH_Constraint

        public ConstraintSettings GetConstraintSettings()
        {
            return new ConstraintSettings(JPH_Constraint_GetConstraintSettings(Handle));
        }

        public new ConstraintType GetType()
        {
            return JPH_Constraint_GetType(Handle);
        }

        public ConstraintSubType GetSubType()
        {
            return JPH_Constraint_GetSubType(Handle);
        }

        public uint GetConstraintPriority()
        {
            return JPH_Constraint_GetConstraintPriority(Handle);
        }

        public void SetConstraintPriority(uint priority)
        {
            JPH_Constraint_SetConstraintPriority(Handle, priority);
        }

        public bool GetEnabled()
        {
            return JPH_Constraint_GetEnabled(Handle);
        }

        public void SetEnabled(bool enabled)
        {
            JPH_Constraint_SetEnabled(Handle, enabled);
        }

        public ulong GetUserData()
        {
            return JPH_Constraint_GetUserData(Handle);
        }

        public void SetUserData(ulong userData)
        {
            JPH_Constraint_SetUserData(Handle, userData);
        }

        public void NotifyShapeChanged(BodyID bodyID, float3 deltaCOM)
        {
            JPH_Constraint_NotifyShapeChanged(Handle, bodyID, deltaCOM);
        }

        #endregion
    }
}
