namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_PointConstraintSettings_Init(ref PointConstraintSettings settings)
        {
            fixed (PointConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_PointConstraintSettings_Init((JPH_PointConstraintSettings*)ptr);   
            }
        }
    }
}