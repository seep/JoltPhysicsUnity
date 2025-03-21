using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct BroadPhaseLayerInterfaceTable : IEquatable<BroadPhaseLayerInterfaceTable>
    {
        #region IEquatable
        
        public bool Equals(BroadPhaseLayerInterfaceTable other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BroadPhaseLayerInterfaceTable other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BroadPhaseLayerInterfaceTable lhs, BroadPhaseLayerInterfaceTable rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BroadPhaseLayerInterfaceTable lhs, BroadPhaseLayerInterfaceTable rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_BroadPhaseLayerInterfaceTable
        
        public void MapObjectToBroadPhaseLayer(ObjectLayer objectLayer, BroadPhaseLayer broadPhaseLayer) => Bindings.JPH_BroadPhaseLayerInterfaceTable_MapObjectToBroadPhaseLayer(Handle.Reinterpret<JPH_BroadPhaseLayerInterface>(), objectLayer, broadPhaseLayer);
        
        #endregion
        
    }
}
