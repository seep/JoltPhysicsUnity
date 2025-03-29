using System;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_MeshShapeSettings> JPH_MeshShapeSettings_Create(ReadOnlySpan<Triangle> triangles)
        {
            AssertInitialized();

            fixed (Triangle* trianglesPtr = triangles)
            {
                return CreateHandle(UnsafeBindings.JPH_MeshShapeSettings_Create((JPH_Triangle*)trianglesPtr, (uint)triangles.Length));
            }
        }

        public static NativeHandle<JPH_MeshShapeSettings> JPH_MeshShapeSettings_Create(ReadOnlySpan<float3> vertices, ReadOnlySpan<IndexedTriangle> triangles)
        {
            AssertInitialized();

            fixed (float3* verticesPtr = vertices)
            fixed (IndexedTriangle* trianglesPtr = triangles)
            {
                return CreateHandle(UnsafeBindings.JPH_MeshShapeSettings_Create2(verticesPtr, (uint)vertices.Length, (JPH_IndexedTriangle*)trianglesPtr, (uint)triangles.Length));
            }
        }

        public static void JPH_MeshShapeSettings_Sanitize(NativeHandle<JPH_MeshShapeSettings> settings)
        {
            AssertInitialized();

            UnsafeBindings.JPH_MeshShapeSettings_Sanitize(settings);
        }

        public static NativeHandle<JPH_MeshShape> JPH_MeshShapeSettings_CreateShape(NativeHandle<JPH_MeshShapeSettings> settings)
        {
            AssertInitialized();

            return CreateHandle(UnsafeBindings.JPH_MeshShapeSettings_CreateShape(settings));
        }
    }
}
