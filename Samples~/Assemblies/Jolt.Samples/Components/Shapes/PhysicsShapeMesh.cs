using System;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapeMesh : PhysicsShapeBase
    {
        public Mesh Mesh;

        internal override ShapeSettings CreateShapeSettings()
        {
            return MeshShapeSettings.Create(BuildMeshVertices(), BuildMeshTriangles());
        }
        
        private ReadOnlySpan<float3> BuildMeshVertices()
        {
            var result = new float3[Mesh.vertices.Length];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = Vector3.Scale(Mesh.vertices[i], transform.localScale);
            }

            return result;
        }

        private ReadOnlySpan<IndexedTriangle> BuildMeshTriangles()
        {
            var result = new IndexedTriangle[Mesh.triangles.Length];

            const uint materialIndex = 0; // TODO

            for (var i = 0; i < Mesh.triangles.Length; i += 3)
            {
                var i1 = (uint) Mesh.triangles[i + 0];
                var i2 = (uint) Mesh.triangles[i + 1];
                var i3 = (uint) Mesh.triangles[i + 2];

                result[i] = new IndexedTriangle(i1, i2, i3, materialIndex);
            }

            return result;
        }
    }
}
