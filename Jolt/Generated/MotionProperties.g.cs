using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct MotionProperties : IEquatable<MotionProperties>
    {
        internal readonly NativeHandle<JPH_MotionProperties> Handle;
        
        internal MotionProperties(NativeHandle<JPH_MotionProperties> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(MotionProperties other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is MotionProperties other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(MotionProperties lhs, MotionProperties rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(MotionProperties lhs, MotionProperties rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_MotionProperties
        
        public AllowedDOFs GetAllowedDOFs() => Bindings.JPH_MotionProperties_GetAllowedDOFs(Handle);
        
        public void SetLinearDamping(float damping) => Bindings.JPH_MotionProperties_SetLinearDamping(Handle, damping);
        
        public float GetLinearDamping() => Bindings.JPH_MotionProperties_GetLinearDamping(Handle);
        
        public void SetAngularDamping(float damping) => Bindings.JPH_MotionProperties_SetAngularDamping(Handle, damping);
        
        public float GetAngularDamping() => Bindings.JPH_MotionProperties_GetAngularDamping(Handle);
        
        public void SetMassProperties(AllowedDOFs allowedDOFs, MassProperties massProperties) => Bindings.JPH_MotionProperties_SetMassProperties(Handle, allowedDOFs, massProperties);
        
        public float GetInverseMassUnchecked() => Bindings.JPH_MotionProperties_GetInverseMassUnchecked(Handle);
        
        public void SetInverseMass(float inverseMass) => Bindings.JPH_MotionProperties_SetInverseMass(Handle, inverseMass);
        
        public float3 GetInverseInertiaDiagonal() => Bindings.JPH_MotionProperties_GetInverseInertiaDiagonal(Handle);
        
        public quaternion GetInertiaRotation() => Bindings.JPH_MotionProperties_GetInertiaRotation(Handle);
        
        public void SetInverseInertia(float3 diagonal, quaternion rotation) => Bindings.JPH_MotionProperties_SetInverseInertia(Handle, diagonal, rotation);
        
        #endregion
        
    }
}
