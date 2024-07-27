using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    public enum PhysicsSamplesLayers : ushort
    {
        Static = 1,
        Moving = 1,
    }

    public class ManagedPhysicsContext
    {
        public Dictionary<PhysicsBody, Body> ManagedToNative = new ();
        public Dictionary<Body, PhysicsBody> NativeToManaged = new ();

        public List<(BodyID, PhysicsBody)> Bodies = new();
    }

    public static class PhysicsHelpers
    {
        public static Body CreateBodyFromGameObject(BodyInterface bodies, PhysicsBody component)
        {
            if (!TryGetShapeSettings(component.gameObject, out ShapeSettings shape))
            {
                throw new NotImplementedException();
            }

            var pos = (float3) component.transform.position;
            var rot = (quaternion) component.transform.rotation;

            var layer = component.MotionType == MotionType.Static
                ? (ushort)PhysicsSamplesLayers.Static
                : (ushort)PhysicsSamplesLayers.Moving;

            var activation = component.MotionType == MotionType.Static
                ? Activation.DontActivate
                : Activation.Activate;

            var settings = BodyCreationSettings.FromShapeSettings(
                shape, pos, rot, component.MotionType, layer
            );

            return bodies.CreateBody(settings);
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

        public static Constraint CreateConstraint(ManagedPhysicsContext context, PhysicsConstraint component)
        {
            if (component is PhysicsConstraintDistance dist)
            {
                // dist.BodyA;
                // dist.BodyB;

                var settings = DistanceConstraintSettings.Create();

                settings.SetPoint1(default);
                settings.SetPoint2(default);
                settings.SetSpace(ConstraintSpace.LocalToBodyCOM);

                var ba = context.ManagedToNative[dist.BodyA];
                var bb = context.ManagedToNative[dist.BodyB];

                return settings.CreateConstraint(ba, bb);
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
