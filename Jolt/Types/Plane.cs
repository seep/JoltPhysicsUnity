using System;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_Plane))]
    public struct Plane : IEquatable<Plane>
    {
        public float3 Normal;
        
        public float Distance;

        #region IEquatable

        public bool Equals(Plane other)
        {
            return Normal.Equals(other.Normal) && Distance.Equals(other.Distance);
        }

        public override bool Equals(object obj)
        {
            return obj is Plane other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Normal, Distance);
        }

        public static bool operator ==(Plane left, Plane right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Plane left, Plane right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
