using System;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static NativeHandle<JPH_HeightFieldShapeSettings> JPH_HeightFieldShapeSettings_Create(ReadOnlySpan<float> samples, ReadOnlySpan<float3> offset, ReadOnlySpan<float3> scale)
        {
            fixed (float* samplesPtr = samples)
            fixed (float3* offsetPtr = offset)
            fixed (float3* scalePtr = scale)
            {
                return CreateHandle(Bindings.JPH_HeightFieldShapeSettings_Create(samplesPtr, offsetPtr, scalePtr,
                    (uint)samples.Length));
            }
        }

        public static void JPH_HeightFieldShapeSettings_DetermineMinAndMaxSample(NativeHandle<JPH_HeightFieldShapeSettings> settings, out float min, out float max, out float quantization)
        {
            fixed (float* minPtr = &min)
            fixed (float* maxPtr = &max)
            fixed (float* quantizationPtr = &quantization)
            {
                Bindings.JPH_HeightFieldShapeSettings_DetermineMinAndMaxSample(GetPointer(settings), minPtr, maxPtr,
                    quantizationPtr);
            }
        }

        public static uint JPH_HeightFieldShapeSettings_CalculateBitsPerSampleForError(NativeHandle<JPH_HeightFieldShapeSettings> settings, float maxError)
        {
            return Bindings.JPH_HeightFieldShapeSettings_CalculateBitsPerSampleForError(GetPointer(settings), maxError);
        }
    }
}
