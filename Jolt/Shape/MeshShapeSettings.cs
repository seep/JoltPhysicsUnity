using System;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_MeshShapeSettings"), GenerateBindings("JPH_MeshShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct MeshShapeSettings
    {
        /// <summary>
        /// Allocate a new native MeshShapeSettings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_MeshShapeSettings_Create")]
        public static MeshShapeSettings Create(ReadOnlySpan<Triangle> triangles)
        {
            return new MeshShapeSettings(JPH_MeshShapeSettings_Create(triangles));
        }

        /// <summary>
        /// Allocate a new native MeshShapeSettings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_MeshShapeSettings_Create")]
        public static MeshShapeSettings Create(ReadOnlySpan<float3> vertices, ReadOnlySpan<IndexedTriangle> triangles)
        {
            return new MeshShapeSettings(JPH_MeshShapeSettings_Create(vertices, triangles));
        }
    }
}
