using System;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public enum PhysicsSamplesLayers : ushort
    {
        Static = 1,
        Moving = 1,
    }

    public static class PhysicsHelpers
    {
        public static void ApplyTransform(BodyInterface bodies, BodyID bodyID, Transform transform)
        {
            // assume no scaling and skip decomposition

            var wtransform = bodies.GetWorldTransform(bodyID).IntoFloat4x4();

            transform.position = wtransform.c3.xyz;
            transform.rotation = new quaternion(wtransform);
        }

        public static BodyID CreateBodyFromGameObject(BodyInterface bodies, GameObject gobj)
        {
            var body = gobj.GetComponent<PhysicsBody>();

            Debug.Assert(body != null, "The GameObject must have a PhysicsBody component.");

            if (!TryGetShapeSettings(gobj, out ShapeSettings shape))
            {
                throw new NotImplementedException();
            }

            var pos = new double3(body.transform.position);
            var rot = (quaternion) body.transform.rotation;

            var layer = body.MotionType == MotionType.Static
                ? (ushort)PhysicsSamplesLayers.Static
                : (ushort)PhysicsSamplesLayers.Moving;

            var activation = body.MotionType == MotionType.Static
                ? Activation.DontActivate
                : Activation.Activate;

            var settings = BodyCreationSettings.FromShapeSettings(
                shape, in pos, in rot, body.MotionType, layer
            );

            return bodies.CreateAndAddBody(settings, activation);
        }

        private static bool TryGetCompoundShapeSettings(GameObject obj, out ShapeSettings settings)
        {
            var shape = obj.GetComponent<IPhysicsShapeComponent>();

            if (shape is PhysicsShapeCompound compound)
            {
                settings = CreateCompoundShapeSettings(compound);
                return true;
            }

            settings = default;
            return false;
        }

        private static bool TryGetShapeSettings(GameObject obj, out ShapeSettings settings)
        {
            var shape = obj.GetComponent<IPhysicsShapeComponent>();

            if (shape == null)
            {
                settings = default;
                return false;
            }

            if (shape is PhysicsShapeCompound compound)
            {
                settings = CreateCompoundShapeSettings(compound);
                return true;
            }

            if (shape is PhysicsShapeBox box)
            {
                settings = BoxShapeSettings.Create(box.HalfExtent, box.ConvexRadius);
                return true;
            }

            if (shape is PhysicsShapeSphere sphere)
            {
                settings = SphereShapeSettings.Create(sphere.Radius);
                return true;
            }

            if (shape is PhysicsShapeCapsule capsule)
            {
                settings = CapsuleShapeSettings.Create(capsule.HalfHeight, capsule.Radius);
                return true;
            }

            if (shape is PhysicsShapeCylinder cylinder)
            {
                settings = CylinderShapeSettings.Create(cylinder.HalfHeight, cylinder.Radius, cylinder.ConvexRadius);
                return true;
            }

            if (shape is PhysicsShapeConvexHull hull)
            {
                settings = ConvexHullShapeSettings.Create(hull.BuildMeshPoints(), hull.MaxConvexRadius);
                return true;
            }

            if (shape is PhysicsShapeMesh mesh)
            {
                settings = MeshShapeSettings.Create(mesh.BuildMeshVertices(), mesh.BuildMeshTriangles());
                return true;
            }

            if (shape is PhysicsShapeTaperedCapsule tapered)
            {
                settings = TaperedCapsuleShapeSettings.Create(tapered.HalfHeight, tapered.TopRadius, tapered.BottomRadius);
                return true;
            }

            throw new NotImplementedException();
        }

        private static ShapeSettings CreateCompoundShapeSettings(PhysicsShapeCompound component)
        {
            CompoundShapeSettings settings;

            if (component.Mutable)
            {
                settings = MutableCompoundShapeSettings.Create();
            }
            else
            {
                settings = StaticCompoundShapeSettings.Create();
            }

            // Very simple single depth compound collider creation. Not intended for robust use.

            for (var i = 0; i < component.transform.childCount; i++)
            {
                var child = component.transform.GetChild(i);

                if (!TryGetShapeSettings(child.gameObject, out ShapeSettings s)) continue;

                settings.AddShape(child.localPosition, child.localRotation, s);
            }

            return (ShapeSettings) settings;
        }
    }
}
