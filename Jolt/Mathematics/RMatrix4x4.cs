using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
	/// <summary>
	/// A 4x4 matrix with optional double precision on the last column.
	/// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct rmatrix4x4
    {
	    public float4 c0;
	    public float4 c1;
	    public float4 c2;

#if !JOLT_DOUBLE_PRECISION
	    public float4 c3;
#else
	    public double4 c3;
#endif

#if !JOLT_DOUBLE_PRECISION
	    public static unsafe implicit operator float4x4(rmatrix4x4 mat)
	    {
		    return *((float4x4*) &mat);
	    }

	    public static unsafe implicit operator rmatrix4x4(float4x4 mat)
	    {
		    return *((rmatrix4x4*) &mat);
	    }
#else
	    /// <summary>
	    /// Create a float4x4 from the rmatrix4x4.
	    /// </summary>
	    /// <remarks>
	    /// Because double precision is enabled, this conversion loses precision on the translation column.
	    /// </remarks>
	    public float4x4 IntoFloat4x4()
	    {
		    return new float4x4(c0, c1, c2, new float4(c3));
	    }

	    // TODO implement additional math helpers for double precision mode
#endif
    }
}
