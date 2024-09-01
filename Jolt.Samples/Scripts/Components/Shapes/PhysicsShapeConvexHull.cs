using System;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsShapeConvexHull : PhysicsShapeBase
    {
        public Mesh Mesh;

        public float MaxConvexRadius = PhysicsSettings.DefaultConvexRadius;
        
        internal override ShapeSettings CreateShapeSettings()
        {
            return ConvexHullShapeSettings.Create(BuildMeshVertices(), MaxConvexRadius);
        }

        private ReadOnlySpan<float3> BuildMeshVertices()
        {
            var result = new float3[Mesh.vertices.Length];

            for (var i = 0; i < Mesh.vertices.Length; i++)
            {
                result[i] = Vector3.Scale(Mesh.vertices[i], transform.localScale);
            }

            return result;
        }
    }
}
