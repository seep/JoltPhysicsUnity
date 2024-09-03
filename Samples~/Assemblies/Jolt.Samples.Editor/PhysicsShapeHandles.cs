using System.Drawing.Drawing2D;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace Jolt.Samples
{
    public static class PhysicsShapeHandles
    {
        private static readonly Color HandleColor = new Color(0.7f, 1f, 0.5f);

        private static void StartHandle()
        {
            Handles.color = HandleColor;
            Handles.matrix = Matrix4x4.identity;
        }

        private static void StartHandle(float3 position, quaternion rotation)
        {
            Handles.color = HandleColor;
            Handles.matrix = Matrix4x4.TRS(position, rotation, Vector3.one);
        }

        private static void ResetHandle()
        {
            Handles.color = default;
            Handles.matrix = Matrix4x4.identity;
        }

        public static void DrawLine(float3 a, float3 b)
        {
            StartHandle();
            
            Handles.DrawLine(a, b);
            
            ResetHandle();
        }
        
        public static void DrawLine(float3 a, float3 b, float thickness)
        {
            StartHandle();
            
            Handles.DrawLine(a, b, thickness);
            
            ResetHandle();
        }

        public static void DrawPoint(float3 position, quaternion rotation)
        {
            StartHandle(position, rotation);

            const float scale = 0.2f;
            
            Handles.DrawLine(scale * math.forward(), scale * math.back());
            Handles.DrawLine(scale * math.left(), scale * math.right());
            Handles.DrawLine(scale * math.up(), scale * math.down());
            
            ResetHandle();
        }

        public static void DrawBoxShape(float3 position, quaternion rotation, PhysicsShapeBox shape)
        {
            StartHandle(position, rotation);

            var clampedConvexRadius = math.clamp(shape.ConvexRadius, 0f, math.cmin(shape.HalfExtent));

            if (clampedConvexRadius == 0f)
            {
                Handles.DrawWireCube(float3.zero, shape.HalfExtent * 2f);
            }
            else
            {
                DrawRoundedWireCube(float3.zero, shape.HalfExtent * 2f, clampedConvexRadius);
            }

            ResetHandle();
        }

        public static void DrawPlaneShape(float3 position, quaternion rotation, PhysicsShapePlane plane)
        {
            StartHandle(position, rotation);
            
            DrawQuadXZ(float3.zero, new float2(plane.HalfExtent * 2f));
            
            Handles.DrawLine(float3.zero, new float3(0f, 1f, 0f));
            
            ResetHandle();
        }

        public static void DrawSphereShape(float3 position, quaternion rotation, PhysicsShapeSphere shape)
        {
            StartHandle(position, rotation);

            DrawWireSphere(float3.zero, shape.Radius);

            ResetHandle();
        }

        public static void DrawCapsuleShape(float3 position, quaternion rotation, PhysicsShapeCapsule shape)
        {
            StartHandle(position, rotation);

            DrawWireCapsule(float3.zero, shape.HalfHeight * 2f, shape.Radius);

            ResetHandle();
        }

        public static void DrawTaperedCapsuleShape(float3 position, quaternion rotation, PhysicsShapeTaperedCapsule shape)
        {
            StartHandle(position, rotation);

            DrawWireTaperedCapsule(float3.zero, shape.HalfHeight * 2f, shape.TopRadius, shape.BottomRadius);

            ResetHandle();
        }

        public static void DrawPhysicsCylinder(float3 position, quaternion rotation, PhysicsShapeCylinder shape)
        {
            StartHandle(position, rotation);

            DrawRoundedWireCylinder(float3.zero, shape.HalfHeight * 2f, shape.Radius, shape.ConvexRadius);

            ResetHandle();
        }

        private static void DrawWireSphere(float3 position, float radius)
        {
            Handles.DrawWireDisc(position, math.up(), radius);
            Handles.DrawWireDisc(position, math.left(), radius);
            Handles.DrawWireDisc(position, math.forward(), radius);
        }

        private static void DrawWireCapsule(float3 position, float height, float radius)
        {
            var h = new float3(0, height * 0.5f, 0);

            Handles.DrawWireDisc(position + h, math.up(), radius);
            Handles.DrawWireDisc(position - h, math.up(), radius);

            var rx = new float3(radius, 0, 0);
            var rz = new float3(0, 0, radius);

            Handles.DrawLine(position + h + rx, position - h + rx);
            Handles.DrawLine(position + h - rx, position - h - rx);

            Handles.DrawLine(position + h + rz, position - h + rz);
            Handles.DrawLine(position + h - rz, position - h - rz);

            // xy plane wire arcs

            DrawWireArcXY(position + h,   0f, 180f, radius);
            DrawWireArcXY(position - h, 180f, 180f, radius);

            // zy plane wire arcs

            DrawWireArcZY(position + h,   0f, 180f, radius);
            DrawWireArcZY(position - h, 180f, 180f, radius);
        }

        private static void DrawWireTaperedCapsule(float3 position, float height, float radiusA, float radiusB)
        {
            var h = new float3(0, height * 0.5f, 0);

            // DrawWireSphere(position + h, radiusA);
            // DrawWireSphere(position - h, radiusB);

            var radiusBA = radiusB - radiusA;

            var tangentLength = math.sqrt((height * height) - (radiusBA * radiusBA));

            var theta = (math.PI * 0.5f) - math.atan(tangentLength / radiusBA);

            var tangentHeightA = math.sin(theta) * radiusA;
            var tangentHeightB = math.sin(theta) * radiusB;

            var tangentRadiusA = math.cos(theta) * radiusA;
            var tangentRadiusB = math.cos(theta) * radiusB;

            var ha = new float3(0, tangentHeightA, 0);
            var hb = new float3(0, tangentHeightB, 0);

            Handles.DrawWireDisc(position + h + ha, math.up(), tangentRadiusA);
            Handles.DrawWireDisc(position - h + hb, math.up(), tangentRadiusB);

            var rxa = new float3(tangentRadiusA, 0, 0);
            var rza = new float3(0, 0, tangentRadiusA);

            var rxb = new float3(tangentRadiusB, 0, 0);
            var rzb = new float3(0, 0, tangentRadiusB);

            Handles.DrawLine(position + h + ha + rxa, position - h + hb + rxb);
            Handles.DrawLine(position + h + ha - rxa, position - h + hb - rxb);

            Handles.DrawLine(position + h + ha + rza, position - h + hb + rzb);
            Handles.DrawLine(position + h + ha - rza, position - h + hb - rzb);

            var thetaDegrees = math.degrees(theta);

            var arcAngleA = 180 - thetaDegrees * 2f;
            var arcAngleB = 180 + thetaDegrees * 2f;

            DrawWireArcZY(position + h, thetaDegrees, +arcAngleA, radiusA);
            DrawWireArcZY(position - h, thetaDegrees, -arcAngleB, radiusB);

            DrawWireArcXY(position + h, thetaDegrees, +arcAngleA, radiusA);
            DrawWireArcXY(position - h, thetaDegrees, -arcAngleB, radiusB);
        }

        private static void DrawRoundedWireCube(float3 position, float3 size, float bevel)
        {
            var fx = new float3(size.x * 0.5f, 0f, 0f); // isolated x face center
            var fy = new float3(0f, size.y * 0.5f, 0f); // isolated y face center
            var fz = new float3(0f, 0f, size.z * 0.5f); // isolated z face center

            var cx = new float3(size.x * 0.5f - bevel, 0f, 0f); // isolated x corner
            var cy = new float3(0f, size.y * 0.5f - bevel, 0f); // isolated y corner
            var cz = new float3(0f, 0f, size.z * 0.5f - bevel); // isolated z corner

            // faces

            DrawQuadXY(+fz, size.xy - bevel * 2f);
            DrawQuadXY(-fz, size.xy - bevel * 2f);

            DrawQuadXZ(+fy, size.xz - bevel * 2f);
            DrawQuadXZ(-fy, size.xz - bevel * 2f);

            DrawQuadYZ(+fx, size.yz - bevel * 2f);
            DrawQuadYZ(-fx, size.yz - bevel * 2f);

            // xy plane arcs

            DrawWireArcXY(position + cx + cy + cz,   0f, 90f, bevel);
            DrawWireArcXY(position - cx + cy + cz,  90f, 90f, bevel);
            DrawWireArcXY(position - cx - cy + cz, 180f, 90f, bevel);
            DrawWireArcXY(position + cx - cy + cz, 270f, 90f, bevel);

            DrawWireArcXY(position + cx + cy - cz,   0f, 90f, bevel);
            DrawWireArcXY(position - cx + cy - cz,  90f, 90f, bevel);
            DrawWireArcXY(position - cx - cy - cz, 180f, 90f, bevel);
            DrawWireArcXY(position + cx - cy - cz, 270f, 90f, bevel);

            // xz plane arcs

            DrawWireArcXZ(position + cx + cy + cz,   0f, 90f, bevel);
            DrawWireArcXZ(position - cx + cy + cz,  90f, 90f, bevel);
            DrawWireArcXZ(position - cx + cy - cz, 180f, 90f, bevel);
            DrawWireArcXZ(position + cx + cy - cz, 270f, 90f, bevel);

            DrawWireArcXZ(position + cx - cy + cz,   0f, 90f, bevel);
            DrawWireArcXZ(position - cx - cy + cz,  90f, 90f, bevel);
            DrawWireArcXZ(position - cx - cy - cz, 180f, 90f, bevel);
            DrawWireArcXZ(position + cx - cy - cz, 270f, 90f, bevel);

            // yz plane arcs

            DrawWireArcZY(position + cx + cy + cz,   0f, 90f, bevel);
            DrawWireArcZY(position + cx + cy - cz,  90f, 90f, bevel);
            DrawWireArcZY(position + cx - cy - cz, 180f, 90f, bevel);
            DrawWireArcZY(position + cx - cy + cz, 270f, 90f, bevel);

            DrawWireArcZY(position - cx + cy + cz,   0f, 90f, bevel);
            DrawWireArcZY(position - cx + cy - cz,  90f, 90f, bevel);
            DrawWireArcZY(position - cx - cy - cz, 180f, 90f, bevel);
            DrawWireArcZY(position - cx - cy + cz, 270f, 90f, bevel);

        }

        private static void DrawRoundedWireCylinder(float3 position, float height, float radius, float bevel)
        {
            var h = new float3(0, height * 0.5f, 0); // isolated y half height

            var rx = new float3(radius, 0, 0); // isolated x radius
            var rz = new float3(0, 0, radius); // isolated z radius

            var bx = new float3(bevel, 0f, 0f); // isolated x bevel
            var by = new float3(0f, bevel, 0f); // isolated y bevel
            var bz = new float3(0f, 0f, bevel); // isolated z bevel

            // faces

            Handles.DrawWireDisc(position + h, math.up(), radius - bevel);
            Handles.DrawWireDisc(position - h, math.up(), radius - bevel);

            // cylinder edges

            Handles.DrawWireDisc(position + h - by, math.up(), radius);
            Handles.DrawWireDisc(position - h + by, math.up(), radius);

            // xy plane cylinder lines

            Handles.DrawLine(position + h + rx - by, position - h + rx + by);
            Handles.DrawLine(position + h - rx - by, position - h - rx + by);

            // xz plane cylinder lines

            Handles.DrawLine(position + h + rx - bx, position + h - rx + bx);
            Handles.DrawLine(position - h + rx - bx, position - h - rx + bx);

            Handles.DrawLine(position + h + rz - bz, position + h - rz + bz);
            Handles.DrawLine(position - h + rz - bz, position - h - rz + bz);

            // yz plane cylinder lines

            Handles.DrawLine(position + h + rz - by, position - h + rz + by);
            Handles.DrawLine(position + h - rz - by, position - h - rz + by);

            // xy plane arcs

            DrawWireArcXY(position + h + rx - bx - by,   0f, 90f, bevel);
            DrawWireArcXY(position + h - rx + bx - by,  90f, 90f, bevel);
            DrawWireArcXY(position - h - rx + bx + by, 180f, 90f, bevel);
            DrawWireArcXY(position - h + rx - bx + by, 270f, 90f, bevel);

            // yz plane arcs

            DrawWireArcZY(position + h + rz - bz - by,   0f, 90f, bevel);
            DrawWireArcZY(position + h - rz + bz - by,  90f, 90f, bevel);
            DrawWireArcZY(position - h - rz + bz + by, 180f, 90f, bevel);
            DrawWireArcZY(position - h + rz - bz + by, 270f, 90f, bevel);

        }

        /// <summary>
        /// Draw a gizmo quad on the XY plane.
        /// </summary>
        private static void DrawQuadXY(float3 position, float2 size)
        {
            DrawQuad(position, math.left() * 0.5f * size.x, math.up() * 0.5f * size.y);
        }

        /// <summary>
        /// Draw a gizmo quad on the XZ plane.
        /// </summary>
        private static void DrawQuadXZ(float3 position, float2 size)
        {
            DrawQuad(position, math.left() * 0.5f * size.x, math.forward() * 0.5f * size.y);
        }

        /// <summary>
        /// Draw a gizmo quad on the YZ plane.
        /// </summary>
        private static void DrawQuadYZ(float3 position, float2 size)
        {
            DrawQuad(position, math.up() * 0.5f * size.x, math.forward() * 0.5f * size.y);
        }

        /// <summary>
        /// Draw a wire arc on the XY plane.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="start">The start angle in degrees where 0 is the positive X axis and 90 is the positive Y axis.</param>
        /// <param name="angle">The sweep angle in degrees.</param>
        /// <param name="radius">The arc radius.</param>
        private static void DrawWireArcXY(float3 position, float start, float angle, float radius)
        {
            var t = math.radians(start);
            var v = new float3(math.cos(t), math.sin(t), 0f);

            Handles.DrawWireArc(position, math.forward(), v, angle, radius);
        }

        /// <summary>
        /// Draw a wire arc on the XZ plane.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="start">The start angle in degrees where 0 is the positive X axis and 90 is the positive Z axis.</param>
        /// <param name="angle">The sweep angle in degrees.</param>
        /// <param name="radius">The arc radius.</param>
        private static void DrawWireArcXZ(float3 position, float start, float angle, float radius)
        {
            var t = math.radians(start);
            var v = new float3(math.cos(t), 0f, math.sin(t));

            Handles.DrawWireArc(position, math.down(), v, angle, radius);
        }

        /// <summary>
        /// Draw a wire arc on the ZY plane.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="start">The start angle in degrees where 0 is the positive Z axis and 90 is the positive Y axis.</param>
        /// <param name="angle">The sweep angle in degrees.</param>
        /// <param name="radius">The arc radius.</param>
        private static void DrawWireArcZY(float3 position, float start, float angle, float radius)
        {
            var t = math.radians(start);
            var v = new float3(0f, math.sin(t), math.cos(t));

            Handles.DrawWireArc(position, math.left(), v, angle, radius);
        }

        private static void DrawQuad(float3 position, float3 u, float3 v)
        {
            var a = position + u + v;
            var b = position - u + v;
            var c = position - u - v;
            var d = position + u - v;

            Handles.DrawLine(a, b);
            Handles.DrawLine(b, c);
            Handles.DrawLine(c, d);
            Handles.DrawLine(d, a);
        }
    }
}
