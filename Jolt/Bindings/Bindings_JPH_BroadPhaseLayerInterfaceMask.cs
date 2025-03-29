namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_BroadPhaseLayerInterface> JPH_BroadPhaseLayerInterfaceMask_Create(uint numBroadPhaseLayers)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_BroadPhaseLayerInterfaceMask_Create(numBroadPhaseLayers));
        }

        public static void JPH_BroadPhaseLayerInterfaceMask_ConfigureLayer(NativeHandle<JPH_BroadPhaseLayerInterface> @interface, BroadPhaseLayer broadPhaseLayer, uint groupsToInclude, uint groupsToExclude)
        {
            AssertInitialized();

            UnsafeBindings.JPH_BroadPhaseLayerInterfaceMask_ConfigureLayer(@interface, broadPhaseLayer, groupsToInclude, groupsToExclude);
        }
    }
}
