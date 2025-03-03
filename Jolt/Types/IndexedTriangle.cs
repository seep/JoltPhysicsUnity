using System;
using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct IndexedTriangle : IEquatable<IndexedTriangle>
    {
        public readonly uint I1;
        public readonly uint I2;
        public readonly uint I3;

        public readonly uint MaterialIndex;

        public readonly uint UserData;

        public IndexedTriangle(uint i1, uint i2, uint i3, uint materialIndex, uint userData = 0)
        {
            I1 = i1;
            I2 = i2;
            I3 = i3;

            MaterialIndex = materialIndex;

            UserData = userData;
        }

        #region IEquatable

        public bool Equals(IndexedTriangle other)
        {
            return I1 == other.I1 && I2 == other.I2 && I3 == other.I3 && MaterialIndex == other.MaterialIndex && UserData == other.UserData;
        }

        public override bool Equals(object obj)
        {
            return obj is IndexedTriangle other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(I1, I2, I3, MaterialIndex, UserData);
        }

        public static bool operator ==(IndexedTriangle lhs, IndexedTriangle rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(IndexedTriangle lhs, IndexedTriangle rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
