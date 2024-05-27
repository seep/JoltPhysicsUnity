namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> JPH_ObjectVsBroadPhaseLayerFilterMask_Create(NativeHandle<JPH_BroadPhaseLayerInterface> @interface)
        {
            return CreateHandle(Bindings.JPH_ObjectVsBroadPhaseLayerFilterMask_Create(@interface));
        }
    }
}
