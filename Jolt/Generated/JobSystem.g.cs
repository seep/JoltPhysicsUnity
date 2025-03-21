using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct JobSystem : IEquatable<JobSystem>
    {
        #region IEquatable
        
        public bool Equals(JobSystem other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is JobSystem other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(JobSystem lhs, JobSystem rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(JobSystem lhs, JobSystem rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_JobSystem
        
        public void Destroy() => Bindings.JPH_JobSystem_Destroy(Handle);
        
        #endregion
        
    }
}
