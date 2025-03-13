using System.Runtime.InteropServices;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_MassProperties))]
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

        public void DecomposePrincipalMomentsOfInertia(out float4x4 rotation, out float3 diagonal)
        {
            JPH_MassProperties_DecomposePrincipalMomentsOfInertia(ref this, out rotation, out diagonal);
        }
        
        public void ScaleToMass(float mass)
        {
            JPH_MassProperties_ScaleToMass(ref this, mass);
        }
    }
}
