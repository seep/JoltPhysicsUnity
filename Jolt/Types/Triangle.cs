using System;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct Triangle : IEquatable<Triangle>
    {
        public readonly float3 V1;
        public readonly float3 V2;
        public readonly float3 V3;

        public readonly uint MaterialIndex;

        public Triangle(float3 v1, float3 v2, float3 v3, uint materialIndex)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;

            MaterialIndex = materialIndex;
        }

        #region MyRegion

        public bool Equals(Triangle other)
        {
            return V1.Equals(other.V1) && V2.Equals(other.V2) && V3.Equals(other.V3) && MaterialIndex == other.MaterialIndex;
        }

        public override bool Equals(object obj)
        {
            return obj is Triangle other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(V1, V2, V3, MaterialIndex);
        }

        public static bool operator ==(Triangle lhs, Triangle rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Triangle lhs, Triangle rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
