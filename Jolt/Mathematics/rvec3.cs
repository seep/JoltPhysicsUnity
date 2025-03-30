using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    /// <summary>
    /// A 3 vector with optional double precision.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct rvec3
    {
        public static rvec3 zero => new rvec3();

        #if JOLT_DOUBLE_PRECISION
        public static rvec3 one => new rvec3(1.0, 1.0, 1.0);
        #else
        public static rvec3 one => new rvec3(1f, 1f, 1f);
        #endif

        #if JOLT_DOUBLE_PRECISION
        public double x;
        public double y;
        public double z;
        #else
        public float x;
        public float y;
        public float z;
        #endif

        #if JOLT_DOUBLE_PRECISION

        public rvec3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public rvec3(double3 value)
        {
            x = value.x;
            y = value.y;
            z = value.z;
        }

        /// <summary>
        /// Perform a reinterpreting cast from an rvec3 to a double3.
        /// </summary>
        /// <remarks>
        /// This is only available when compiled with JOLT_DOUBLE_PRECISION where the two have the same memory layout.
        /// </remarks>
        public static unsafe implicit operator double3(rvec3 vec)
        {
            return *((double3*) &vec);
        }

        /// <summary>
        /// Perform a reinterpreting cast from a double3 to an rvec3.
        /// </summary>
        /// <remarks>
        /// This is only available when compiled with JOLT_DOUBLE_PRECISION where the two have the same memory layout.
        /// </remarks>
        public static unsafe implicit operator rvec3(double3 vec)
        {
            return *((rvec3*) &vec);
        }

        /// <summary>
        /// Perform an implicit cast from a float3 to an rvec3. Safe because we are gaining precision.
        /// </summary>
        public static implicit operator rvec3(float3 vec)
        {
            return new rvec3(vec.x, vec.y, vec.z);
        }

        #else

        public rvec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public rvec3(float3 value)
        {
            x = value.x;
            y = value.y;
            z = value.z;
        }

        /// <summary>
        /// Perform a reinterpreting cast from an rvec3 to a float3.
        /// </summary>
        /// <remarks>
        /// This is only available when compiled without JOLT_DOUBLE_PRECISION where the two have the same memory layout.
        /// </remarks>
        public static unsafe implicit operator float3(rvec3 vec)
        {
            return *((float3*) &vec);
        }

        /// <summary>
        /// Perform a reinterpreting cast from a float3 to an rvec3.
        /// </summary>
        /// <remarks>
        /// This is only available when compiled without JOLT_DOUBLE_PRECISION where the two have the same memory layout.
        /// </remarks>
        public static unsafe implicit operator rvec3(float3 vec)
        {
            return *((rvec3*) &vec);
        }

        #endif

        /// <summary>
        /// Create a float3 from the rvec3 with a possible loss of precision.
        /// </summary>
        /// <remarks>
        /// This loses precision when compiled with JOLT_DOUBLE_PRECISION.
        /// </remarks>
        public float3 IntoFloat3()
        {
            #if JOLT_DOUBLE_PRECISION
            return new float3((float)x, (float)y, (float)z);
            #else
            return new float3(x, y, z);
            #endif
        }
    }
}
