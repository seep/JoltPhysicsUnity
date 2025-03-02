using System;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_MeshShapeSettings", "JPH_ShapeSettings")]
    public partial struct MeshShapeSettings
    {
        internal NativeHandle<JPH_MeshShapeSettings> Handle;
        
        /// <summary>
        /// Allocate a new native MeshShapeSettings and return the handle.
        /// </summary>
        public static MeshShapeSettings Create(ReadOnlySpan<Triangle> triangles)
        {
            return new MeshShapeSettings { Handle = JPH_MeshShapeSettings_Create(triangles) };
        }

        /// <summary>
        /// Allocate a new native MeshShapeSettings and return the handle.
        /// </summary>
        public static MeshShapeSettings Create(ReadOnlySpan<float3> vertices, ReadOnlySpan<IndexedTriangle> triangles)
        {
            return new MeshShapeSettings { Handle = JPH_MeshShapeSettings_Create(vertices, triangles) };
        }
    }
}
