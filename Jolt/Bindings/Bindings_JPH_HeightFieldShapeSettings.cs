using System;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_HeightFieldShapeSettings> JPH_HeightFieldShapeSettings_Create(ReadOnlySpan<float> samples, ReadOnlySpan<float3> offset, ReadOnlySpan<float3> scale)
        {
            AssertInitialized();

            fixed (float* samplesPtr = samples)
            fixed (float3* offsetPtr = offset)
            fixed (float3* scalePtr = scale)
            {
                return CreateHandle(UnsafeBindings.JPH_HeightFieldShapeSettings_Create(samplesPtr, offsetPtr, scalePtr,
                    (uint)samples.Length));
            }
        }

        public static void JPH_HeightFieldShapeSettings_DetermineMinAndMaxSample(NativeHandle<JPH_HeightFieldShapeSettings> settings, out float min, out float max, out float quantization)
        {
            AssertInitialized();

            fixed (float* minPtr = &min)
            fixed (float* maxPtr = &max)
            fixed (float* quantizationPtr = &quantization)
            {
                UnsafeBindings.JPH_HeightFieldShapeSettings_DetermineMinAndMaxSample(settings, minPtr, maxPtr,
                    quantizationPtr);
            }
        }

        public static uint JPH_HeightFieldShapeSettings_CalculateBitsPerSampleForError(NativeHandle<JPH_HeightFieldShapeSettings> settings, float maxError)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_HeightFieldShapeSettings_CalculateBitsPerSampleForError(settings, maxError);
        }
    }
}
