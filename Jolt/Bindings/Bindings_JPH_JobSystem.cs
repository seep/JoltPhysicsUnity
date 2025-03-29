namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_JobSystem_Destroy(NativeHandle<JPH_JobSystem> system)
        {
            AssertInitialized();

            UnsafeBindings.JPH_JobSystem_Destroy(system);
        }
    }
}
