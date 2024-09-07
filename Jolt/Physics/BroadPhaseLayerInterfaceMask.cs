using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_BroadPhaseLayerInterface"), GenerateBindings("JPH_BroadPhaseLayerInterfaceMask")]
    public readonly partial struct BroadPhaseLayerInterfaceMask
    {
        /// <summary>
        /// Implicit reinterpret cast as the base class BroadPhaseLayerInterface.
        /// </summary>
        public static implicit operator BroadPhaseLayerInterface(BroadPhaseLayerInterfaceMask mask)
        {
            return new BroadPhaseLayerInterface(mask.Handle);
        }

        [OverrideBinding("JPH_BroadPhaseLayerInterfaceMask_Create")]
        public static BroadPhaseLayerInterfaceMask Create(uint numBroadPhaseLayers)
        {
            return new BroadPhaseLayerInterfaceMask(JPH_BroadPhaseLayerInterfaceMask_Create(numBroadPhaseLayers));
        }
    }
}
