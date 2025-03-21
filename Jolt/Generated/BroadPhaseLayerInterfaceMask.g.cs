using System;
using Jolt;
using Unity.Collections;
using Unity.Mathematics;

namespace Jolt
{
    public partial struct BroadPhaseLayerInterfaceMask : IEquatable<BroadPhaseLayerInterfaceMask>
    {
        #region IEquatable
        
        public bool Equals(BroadPhaseLayerInterfaceMask other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BroadPhaseLayerInterfaceMask other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BroadPhaseLayerInterfaceMask lhs, BroadPhaseLayerInterfaceMask rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BroadPhaseLayerInterfaceMask lhs, BroadPhaseLayerInterfaceMask rhs) => !lhs.Equals(rhs);
        
        #endregion
        
        #region JPH_BroadPhaseLayerInterfaceMask
        
        public void ConfigureLayer(BroadPhaseLayer broadPhaseLayer, uint groupsToInclude, uint groupsToExclude) => Bindings.JPH_BroadPhaseLayerInterfaceMask_ConfigureLayer(Handle.Reinterpret<JPH_BroadPhaseLayerInterface>(), broadPhaseLayer, groupsToInclude, groupsToExclude);
        
        #endregion
        
    }
}
