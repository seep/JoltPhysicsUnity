namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_DistanceConstraintSettings_Init(ref DistanceConstraintSettings settings)
        {
            fixed (DistanceConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_DistanceConstraintSettings_Init((JPH_DistanceConstraintSettings*)ptr);   
            }
        }
    }
}
