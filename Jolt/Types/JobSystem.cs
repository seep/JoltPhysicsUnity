using System;

using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_JobSystem")]
    public partial struct JobSystem : IDisposable
    {
        internal NativeHandle<JPH_JobSystem> Handle;

        /// <summary>
        /// Allocate a new native JobSystem from a thead pool config. Pass default to use the max threads available.
        /// </summary>
        public static JobSystem Create(JobSystemThreadPoolConfig config = default)
        {
            return new JobSystem { Handle = JPH_JobSystemThreadPool_Create(config) };
        }

        /// <summary>
        /// Allocate a new native JobSystem from a callback config.
        /// </summary>
        public static JobSystem Create(JobSystemConfig config)
        {
            return new JobSystem { Handle = JPH_JobSystemCallback_Create(config) };
        }

        public void Dispose()
        {
            Handle.Dispose();
        }
    }
}
