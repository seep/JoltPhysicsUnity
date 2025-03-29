using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct PhysicsMaterial : IEquatable<PhysicsMaterial>
    {
        #region IEquatable
        
        public bool Equals(PhysicsMaterial other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is PhysicsMaterial other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(PhysicsMaterial lhs, PhysicsMaterial rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(PhysicsMaterial lhs, PhysicsMaterial rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_PhysicsMaterial
        
        public void Destroy() => Bindings.JPH_PhysicsMaterial_Destroy(Handle);
        
        public string GetDebugName() => Bindings.JPH_PhysicsMaterial_GetDebugName(Handle);
        
        public uint GetDebugColor() => Bindings.JPH_PhysicsMaterial_GetDebugColor(Handle);
        
        #endregion
        
    }
}
