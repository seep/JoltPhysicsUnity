using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
	/// <summary>
	/// A 4x4 matrix with three columns of floats and one column of doubles.
	/// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct rmatrix4x4
    {
        public float4 c0;
        public float4 c1;
        public float4 c2;
        public double4 c3;

        public rmatrix4x4(double4x4 value)
        {
			c0 = new float4(value.c0);
			c1 = new float4(value.c1);
			c2 = new float4(value.c2);
			c3 = value.c3;
        }

        /// <summary>
        /// Convert the mixed precision matrix into a float4x4. Note that this loses precision on the translation column.
        /// </summary>
        public float4x4 IntoFloat4x4()
        {
	        return new float4x4(c0, c1, c2, new float4(c3));
        }

        /// <summary>
        /// Convert the mixed precision matrix into a double4x4.
        /// </summary>
        public double4x4 IntoDouble4x4()
        {
	        return new double4x4(c0, c1, c2, c3);
        }
    }
}
