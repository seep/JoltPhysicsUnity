using System;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_JobSystem> JPH_JobSystemCallback_Create(JobSystemConfig config)
        {
            AssertInitialized();

            throw new NotImplementedException(); // TODO JobSystemConfig requires unmanaged function pointers
        }
    }
}
