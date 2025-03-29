using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_MassProperties_DecomposePrincipalMomentsOfInertia(ref MassProperties properties, out float4x4 rotation, out float3 diagonal)
        {
            AssertInitialized();

            fixed (MassProperties* propertiesPtr = &properties)
            fixed (float4x4* rotationPtr = &rotation)
            fixed (float3* diagonalPtr = &diagonal)
            {
                UnsafeBindings.JPH_MassProperties_DecomposePrincipalMomentsOfInertia((JPH_MassProperties*)propertiesPtr, rotationPtr, diagonalPtr);
            }
        }

        public static void JPH_MassProperties_ScaleToMass(ref MassProperties properties, float mass)
        {
            AssertInitialized();

            fixed (MassProperties* propertiesPtr = &properties)
            {
                UnsafeBindings.JPH_MassProperties_ScaleToMass((JPH_MassProperties*)propertiesPtr, mass);
            }
        }
    }
}
