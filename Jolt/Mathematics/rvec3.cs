using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    /// <summary>
    /// A 3 vector with optional double precision.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct rvec3
    {
#if !JOLT_DOUBLE_PRECISION

        public float x;
        public float y;
        public float z;

	    public static unsafe implicit operator float3(rvec3 vec)
	    {
		    return *((float3*) &vec);
	    }

	    public static unsafe implicit operator rvec3(float3 vec)
	    {
		    return *((rvec3*) &vec);
	    }

#else

        public double x;
        public double y;
        public double z;

        public static unsafe implicit operator double3(rvec3 vec)
	    {
			return *((double3*) &vec);
		}

        public static unsafe implicit operator rvec3(double3 vec)
	    {
			return *((rvec3*) &vec);
		}

#endif
    }
}
