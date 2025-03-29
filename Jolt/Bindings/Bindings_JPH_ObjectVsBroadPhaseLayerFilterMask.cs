namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> JPH_ObjectVsBroadPhaseLayerFilterMask_Create(NativeHandle<JPH_BroadPhaseLayerInterface> @interface)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_ObjectVsBroadPhaseLayerFilterMask_Create(@interface));
        }
    }
}
