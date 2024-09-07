using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct Constraint : IEquatable<Constraint>
    {
        internal readonly NativeHandle<JPH_Constraint> Handle;
        
        internal Constraint(NativeHandle<JPH_Constraint> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(Constraint other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is Constraint other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(Constraint lhs, Constraint rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(Constraint lhs, Constraint rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_Constraint
        
        public ConstraintSettings GetConstraintSettings() => new ConstraintSettings(Bindings.JPH_Constraint_GetConstraintSettings(Handle));
        
        public new ConstraintType GetType() => Bindings.JPH_Constraint_GetType(Handle);
        
        public ConstraintSubType GetSubType() => Bindings.JPH_Constraint_GetSubType(Handle);
        
        public uint GetConstraintPriority() => Bindings.JPH_Constraint_GetConstraintPriority(Handle);
        
        public void SetConstraintPriority(uint priority) => Bindings.JPH_Constraint_SetConstraintPriority(Handle, priority);
        
        public bool GetEnabled() => Bindings.JPH_Constraint_GetEnabled(Handle);
        
        public void SetEnabled(bool enabled) => Bindings.JPH_Constraint_SetEnabled(Handle, enabled);
        
        public ulong GetUserData() => Bindings.JPH_Constraint_GetUserData(Handle);
        
        public void SetUserData(ulong userData) => Bindings.JPH_Constraint_SetUserData(Handle, userData);
        
        public void NotifyShapeChanged(BodyID bodyID, float3 deltaCOM) => Bindings.JPH_Constraint_NotifyShapeChanged(Handle, bodyID, deltaCOM);
        
        public void Destroy() => Bindings.JPH_Constraint_Destroy(Handle);
        
        #endregion
        
    }
}
