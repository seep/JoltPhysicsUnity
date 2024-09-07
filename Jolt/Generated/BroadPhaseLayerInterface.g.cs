using System;
using Jolt;
using Unity.Mathematics;

namespace Jolt
{
    public readonly partial struct BroadPhaseLayerInterface : IEquatable<BroadPhaseLayerInterface>
    {
        internal readonly NativeHandle<JPH_BroadPhaseLayerInterface> Handle;
        
        internal BroadPhaseLayerInterface(NativeHandle<JPH_BroadPhaseLayerInterface> handle) => Handle = handle;
        
        #region IEquatable
        
        public bool Equals(BroadPhaseLayerInterface other) => Handle.Equals(other.Handle);
        
        public override bool Equals(object obj) => obj is BroadPhaseLayerInterface other && Equals(other);
        
        public override int GetHashCode() => Handle.GetHashCode();
        
        public static bool operator ==(BroadPhaseLayerInterface lhs, BroadPhaseLayerInterface rhs) => lhs.Equals(rhs);
        
        public static bool operator !=(BroadPhaseLayerInterface lhs, BroadPhaseLayerInterface rhs) => !lhs.Equals(rhs);
        
        #endregion
        
    }
}
