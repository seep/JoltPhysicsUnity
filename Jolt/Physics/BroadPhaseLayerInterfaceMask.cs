using System;
using static Jolt.SafeBindings;

namespace Jolt
{
    public struct BroadPhaseLayerInterfaceMask : IEquatable<BroadPhaseLayerInterfaceMask>
    {
        internal NativeHandle<JPH_BroadPhaseLayerInterface> Handle;

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

        #region IEquatable

        public static bool operator ==(BroadPhaseLayerInterfaceMask lhs, BroadPhaseLayerInterfaceMask rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(BroadPhaseLayerInterfaceMask lhs, BroadPhaseLayerInterfaceMask rhs)
        {
            return !lhs.Equals(rhs);
        }
        public bool Equals(BroadPhaseLayerInterfaceMask other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is BroadPhaseLayerInterfaceMask other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
