using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static uint JPH_ConvexHullShape_GetNumPoints(NativeHandle<JPH_ConvexHullShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ConvexHullShape_GetNumPoints(shape);
        }

        public static float3 JPH_ConvexHullShape_GetPoint(NativeHandle<JPH_ConvexHullShape> shape, uint index)
        {
            AssertInitialized();

            float3 result;
            UnsafeBindings.JPH_ConvexHullShape_GetPoint(shape, index, &result);
            return result;
        }

        public static uint JPH_ConvexHullShape_GetNumFaces(NativeHandle<JPH_ConvexHullShape> shape)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ConvexHullShape_GetNumFaces(shape);
        }

        public static uint JPH_ConvexHullShape_GetNumVerticesInFace(NativeHandle<JPH_ConvexHullShape> shape, uint faceIndex)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ConvexHullShape_GetNumVerticesInFace(shape, faceIndex);
        }

        /// <summary>
        /// Fill the <paramref name="vertices"/> buffer with the indices of the face vertices of the <paramref name="faceIndex"/>.
        /// </summary>
        /// <returns>
        /// The number of vertices in the face. If this is bigger than the buffer length, not all vertices were retrieved.
        /// </returns>
        public static uint JPH_ConvexHullShape_GetFaceVertices(NativeHandle<JPH_ConvexHullShape> shape, uint faceIndex, NativeArray<uint> vertices)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_ConvexHullShape_GetFaceVertices(shape, faceIndex, (uint)vertices.Length, (uint*)vertices.GetUnsafePtr());
        }
    }
}
