using System;
using static Jolt.JoltAPI;

namespace Jolt
{
    public struct BroadPhaseLayerInterfaceTable : IEquatable<BroadPhaseLayerInterfaceTable>
    {
        internal NativeHandle<JPH_BroadPhaseLayerInterface> Handle;

        internal BroadPhaseLayerInterfaceTable(NativeHandle<JPH_BroadPhaseLayerInterface> handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Implicit reinterpret cast as the base class BroadPhaseLayerInterface.
        /// </summary>
        public static implicit operator BroadPhaseLayerInterface(BroadPhaseLayerInterfaceTable table)
        {
            return new BroadPhaseLayerInterface(table.Handle);
        }

        #region JPH_BroadPhaseLayerInterfaceTable

        public static BroadPhaseLayerInterfaceTable Create(uint numObjectLayers, uint numBroadPhaseLayers)
        {
            return new BroadPhaseLayerInterfaceTable(JPH_BroadPhaseLayerInterfaceTable_Create(numObjectLayers, numBroadPhaseLayers));
        }

        public void MapObjectToBroadPhaseLayer(ObjectLayer objectLayer, BroadPhaseLayer broadPhaseLayer)
        {
            JPH_BroadPhaseLayerInterfaceTable_MapObjectToBroadPhaseLayer(Handle, objectLayer, broadPhaseLayer);
        }

        #endregion

        #region IEquatable

        public static bool operator ==(BroadPhaseLayerInterfaceTable lhs, BroadPhaseLayerInterfaceTable rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(BroadPhaseLayerInterfaceTable lhs, BroadPhaseLayerInterfaceTable rhs)
        {
            return !lhs.Equals(rhs);
        }
        public bool Equals(BroadPhaseLayerInterfaceTable other)
        {
            return Handle.Equals(other.Handle);
        }

        public override bool Equals(object obj)
        {
            return obj is BroadPhaseLayerInterfaceTable other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #endregion
    }
}
