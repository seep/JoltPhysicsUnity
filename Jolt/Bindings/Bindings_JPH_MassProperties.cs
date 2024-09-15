using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_MassProperties_DecomposePrincipalMomentsOfInertia(MassProperties properties, out float4x4 rotation, out float3 diagonal)
        {
            fixed (float4x4* rotationPtr = &rotation)
            fixed (float3* diagonalPtr = &diagonal)
            {
                UnsafeBindings.JPH_MassProperties_DecomposePrincipalMomentsOfInertia(&properties, rotationPtr, diagonalPtr);   
            }
        }

        public static void JPH_MassProperties_ScaleToMass(ref MassProperties properties, float mass)
        {
            fixed (MassProperties* propertiesPtr = &properties)
            {
                UnsafeBindings.JPH_MassProperties_ScaleToMass(propertiesPtr, mass);
            }
        }
    }
}
