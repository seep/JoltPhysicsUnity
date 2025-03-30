using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    /// <summary>
    /// A 4x4 matrix with optional double precision on the last column.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct rmatrix4x4
    {
        public float4 c0;
        public float4 c1;
        public float4 c2;

        #if JOLT_DOUBLE_PRECISION
        public double4 c3;
        #else
        public float4 c3;
        #endif

        #if JOLT_DOUBLE_PRECISION

        public rmatrix4x4(float4 c0, float4 c1, float4 c2, double4 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        #else

        public static unsafe implicit operator float4x4(rmatrix4x4 mat)
        {
            return *(float4x4*)&mat;
        }

        public static unsafe implicit operator rmatrix4x4(float4x4 mat)
        {
            return *(rmatrix4x4*)&mat;
        }

        #endif

        /// <summary>
        /// Create a float4x4 from the rmatrix4x4 with a possible loss of precision.
        /// </summary>
        /// <remarks>
        /// This conversion loses precision on the translation column when compiled with JOLT_DOUBLE_PRECISION.
        /// </remarks>
        public float4x4 IntoFloat4x4()
        {
            #if JOLT_DOUBLE_PRECISION
            return new float4x4(c0, c1, c2, new float4(c3));
            #else
            return new float4x4(c0, c1, c2, c3);
            #endif
        }
    }
}
