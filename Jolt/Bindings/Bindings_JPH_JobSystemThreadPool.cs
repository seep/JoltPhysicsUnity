namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_JobSystem> JPH_JobSystemThreadPool_Create(JobSystemThreadPoolConfig config)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_JobSystemThreadPool_Create((JPH_JobSystemThreadPoolConfig*)&config));
        }
    }
}
