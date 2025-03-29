using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static void JPH_SliderConstraintSettings_Init(ref SliderConstraintSettings settings)
        {
            AssertInitialized();

            fixed (SliderConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_SliderConstraintSettings_Init((JPH_SliderConstraintSettings*)ptr);
            }
        }

        public static void JPH_SliderConstraintSettings_SetSliderAxis(ref SliderConstraintSettings settings, float3 axis)
        {
            AssertInitialized();

            fixed (SliderConstraintSettings* ptr = &settings)
            {
                UnsafeBindings.JPH_SliderConstraintSettings_SetSliderAxis((JPH_SliderConstraintSettings*)ptr, &axis);
            }
        }
    }
}
