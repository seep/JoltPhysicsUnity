using System;

using static Jolt.Bindings;

namespace Jolt
{
    public struct JobSystem : IDisposable, IEquatable<JobSystem>
    {
        internal NativeHandle<JPH_JobSystem> Handle;

        internal JobSystem(NativeHandle<JPH_JobSystem> handle)
        {
            Handle = handle;
        }
        
        /// <summary>
        /// Allocate a new native JobSystem from a thead pool config. Pass default to use the max threads available.
        /// </summary>
        public static JobSystem Create(JobSystemThreadPoolConfig config = default)
        {
            return new JobSystem(JPH_JobSystemThreadPool_Create(config));
        }

        /// <summary>
        /// Allocate a new native JobSystem from a callback config.
        /// </summary>
        public static JobSystem Create(JobSystemConfig config)
        {
            return new JobSystem(JPH_JobSystemCallback_Create(config));
        }

        #region IEquatable;
        
        public bool Equals(JobSystem other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is JobSystem other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        public static bool operator ==(JobSystem left, JobSystem right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(JobSystem left, JobSystem right)
        {
            return !left.Equals(right);
        }
        
        #endregion
        
        #region IDisposable

        public void Dispose()
        {
            Handle.Dispose();
        }

        #endregion
    }
}