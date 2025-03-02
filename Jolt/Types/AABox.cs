using System;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AABox : IEquatable<AABox>
    {
        public float3 Min;
        public float3 Max;

        #region IEquatable

        public bool Equals(AABox other)
        {
            return Min.Equals(other.Min) && Max.Equals(other.Max);
        }

        public override bool Equals(object obj)
        {
            return obj is AABox other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Min, Max);
        }

        public static bool operator ==(AABox lhs, AABox rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(AABox lhs, AABox rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
