namespace Jolt
{
    public partial struct BroadPhaseLayerInterface
    {
        internal NativeHandle<JPH_BroadPhaseLayerInterface> Handle;
        
        public static implicit operator BroadPhaseLayerInterface(BroadPhaseLayerInterfaceMask mask)
        {
            return new BroadPhaseLayerInterface { Handle = mask.Handle };
        }
        
        public static implicit operator BroadPhaseLayerInterface(BroadPhaseLayerInterfaceTable table)
        {
            return new BroadPhaseLayerInterface { Handle = table.Handle };
        }
    }
}
