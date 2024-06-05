using System;
using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_MeshShapeSettings")]
    public readonly partial struct MeshShapeSettings : IShapeSettings
    {
        internal readonly NativeHandle<JPH_MeshShapeSettings> Handle;

        internal MeshShapeSettings(NativeHandle<JPH_MeshShapeSettings> handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Allocate a new native MeshShapeSettings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_MeshShapeSettings_Create")]
        public MeshShapeSettings Create(ReadOnlySpan<Triangle> triangles)
        {
            return new MeshShapeSettings(JPH_MeshShapeSettings_Create(triangles));
        }

        /// <summary>
        /// Allocate a new native MeshShapeSettings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_MeshShapeSettings_Create2")]
        public static MeshShapeSettings Create(ReadOnlySpan<float3> vertices, ReadOnlySpan<IndexedTriangle> triangles)
        {
            return new MeshShapeSettings(JPH_MeshShapeSettings_Create2(vertices, triangles));
        }

        /// <summary>
        /// Allocate a new native MeshShape from these settings and return the handle.
        /// </summary>
        [OverrideBinding("JPH_MeshShapeSettings_CreateShape")]
        public MeshShape CreateShape()
        {
            return new MeshShape(JPH_MeshShapeSettings_CreateShape(Handle));
        }
    }
}
