using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle]
    public readonly partial struct BroadPhaseLayerInterfaceMask
    {
        internal readonly NativeHandle<JPH_BroadPhaseLayerInterface> Handle;

        internal BroadPhaseLayerInterfaceMask(NativeHandle<JPH_BroadPhaseLayerInterface> handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Implicit reinterpret cast as the base class BroadPhaseLayerInterface.
        /// </summary>
        public static implicit operator BroadPhaseLayerInterface(BroadPhaseLayerInterfaceMask mask)
        {
            return new BroadPhaseLayerInterface(mask.Handle);
        }

        #region JPH_BroadPhaseLayerInterfaceMask

        public static BroadPhaseLayerInterfaceMask Create(uint numBroadPhaseLayers)
        {
            return new BroadPhaseLayerInterfaceMask(JPH_BroadPhaseLayerInterfaceMask_Create(numBroadPhaseLayers));
        }

        public void ConfigureLayer(BroadPhaseLayer broadPhaseLayer, uint groupsToInclude, uint groupsToExclude)
        {
            JPH_BroadPhaseLayerInterfaceMask_ConfigureLayer(Handle, broadPhaseLayer, groupsToInclude, groupsToExclude);
        }

        #endregion
    }
}
