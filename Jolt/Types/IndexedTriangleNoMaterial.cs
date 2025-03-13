using System;
using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_IndexedTriangleNoMaterial))]
    public struct IndexedTriangleNoMaterial : IEquatable<IndexedTriangleNoMaterial>
    {
        public readonly uint I1;
        public readonly uint I2;
        public readonly uint I3;

        public IndexedTriangleNoMaterial(uint i1, uint i2, uint i3)
        {
            I1 = i1;
            I2 = i2;
            I3 = i3;
        }

        #region IEquatable

        public bool Equals(IndexedTriangleNoMaterial other)
        {
            return I1 == other.I1 && I2 == other.I2 && I3 == other.I3;
        }

        public override bool Equals(object obj)
        {
            return obj is IndexedTriangleNoMaterial other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(I1, I2, I3);
        }

        public static bool operator ==(IndexedTriangleNoMaterial lhs, IndexedTriangleNoMaterial rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(IndexedTriangleNoMaterial lhs, IndexedTriangleNoMaterial rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
