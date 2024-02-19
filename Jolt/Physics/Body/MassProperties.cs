using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MassProperties
    {
        /// <summary>
        /// Mass of the shape (kg).
        /// </summary>
        public float Mass;

        /// <summary>
        /// Inertia tensor of the shape (kg m^2).
        /// </summary>
        public float4x4 Inertia;
    }
}
