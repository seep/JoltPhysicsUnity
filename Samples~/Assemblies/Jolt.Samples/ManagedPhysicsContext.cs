using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    /// <summary>
    /// A managed container around a Jolt physics system to keep the samples simple.
    /// </summary>
    public class ManagedPhysicsContext
    {
        /// <summary>
        /// The max amount of rigid bodies that can be added to the physics system. Adding more will raise a native exception.
        /// </summary>
        /// <remarks>
        /// This is intentionally low for the samples. For a real project, use something in the order of 65536.
        /// </remarks>
        private const uint MaxBodies = 1024;

        /// <summary>
        /// The max amount of body pairs that can be queued at any time. If this is too small, the queue will fill up and the broad phase jobs will start to do narrow phase work. This is slightly less efficient.
        /// </summary>
        /// <remarks>
        /// This is intentionally low for the samples. For a real project, use something in the order of 65536.
        /// </remarks>
        private const uint MaxBodyPairs = 1024;

        /// <summary>
        /// The maximum size of the contact constraint buffer. If more contacts are detected, these contacts will be ignored and bodies will start interpenetrating / fall through the world.
        /// </summary>
        /// <remarks>
        /// This is intentionally low for the samples. For a real project, use something in the order of 10240.
        /// </remarks>
        private const uint MaxContactConstraints = 1024;

        /// <summary>
        /// The object layers used in the samples. A real application would probably have many more.
        /// </summary>
        private static class ObjectLayers
        {
            public static readonly ObjectLayer Static = 0;
            public static readonly ObjectLayer Moving = 1;
            public const uint NumLayers = 2;
        }

        /// <summary>
        /// The broad phase layers used in the samples. A real application would probably have many more.
        /// </summary>
        private static class BroadPhaseLayers
        {
            public static readonly BroadPhaseLayer Static = 0;
            public static readonly BroadPhaseLayer Moving = 1;
            public const uint NumLayers = 2;
        }

        /// <summary>
        /// The number of collision steps used in the samples, kept low for performance.
        /// </summary>
        private const int CollisionSteps = 1;

        /// <summary>
        /// The native PhysicsSystem handle.
        /// </summary>
        public readonly PhysicsSystem PhysicsSystem;

        /// <summary>
        /// The list of managed bodies that get updated with the native transforms after each system update.
        /// </summary>
        private readonly List<PhysicsBody> managedBodyList = new();

        /// <summary>
        /// The native job system for jolt. The samples just use the default thread pool config for simplicity.
        /// </summary>
        private readonly JobSystem nativeJobSystem = JobSystem.Create(new JobSystemThreadPoolConfig());

        /// <summary>
        /// The accumulated time that has been simulated by the physics system.
        /// </summary>
        public float PhysicsTime { get; private set; }

        public ManagedPhysicsContext()
        {
            var objectLayerPairFilter = ObjectLayerPairFilterTable.Create(ObjectLayers.NumLayers);
            objectLayerPairFilter.EnableCollision(ObjectLayers.Static, ObjectLayers.Moving);
            objectLayerPairFilter.EnableCollision(ObjectLayers.Moving, ObjectLayers.Moving);

            var broadPhaseLayerInterface = BroadPhaseLayerInterfaceTable.Create(ObjectLayers.NumLayers, BroadPhaseLayers.NumLayers);
            broadPhaseLayerInterface.MapObjectToBroadPhaseLayer(ObjectLayers.Static, BroadPhaseLayers.Static);
            broadPhaseLayerInterface.MapObjectToBroadPhaseLayer(ObjectLayers.Moving, BroadPhaseLayers.Moving);

            var objectVsBroadPhaseLayerFilter = ObjectVsBroadPhaseLayerFilterTable.Create(broadPhaseLayerInterface, BroadPhaseLayers.NumLayers, objectLayerPairFilter, ObjectLayers.NumLayers);

            var settings = new PhysicsSystemSettings
            {
                MaxBodies = MaxBodies,
                MaxBodyPairs = MaxBodyPairs,
                MaxContactConstraints = MaxContactConstraints,
                ObjectLayerPairFilter = objectLayerPairFilter,
                BroadPhaseLayerInterface = broadPhaseLayerInterface,
                ObjectVsBroadPhaseLayerFilter = objectVsBroadPhaseLayerFilter,
            };

            PhysicsSystem = new PhysicsSystem(settings);

            InitializeScene();

            PhysicsSystem.OptimizeBroadPhase();
        }

        private static Body CreateNativeBodyFromGameObject(BodyInterface bodies, GameObject gobj)
        {
            if (!gobj.TryGetComponent(out PhysicsBody managedBodyComponent))
            {
                throw new NotImplementedException();
            }

            if (!gobj.TryGetComponent(out PhysicsShapeBase managedShapeComponent))
            {
                throw new NotImplementedException();
            }

            var nativeShapeSettings = managedShapeComponent.CreateShapeSettings();

            var pos = (float3) gobj.transform.position;
            var rot = (quaternion) gobj.transform.rotation;

            var settings = BodyCreationSettings.Create(
                nativeShapeSettings, pos, rot, managedBodyComponent.MotionType,
                managedBodyComponent.MotionType == MotionType.Static ? ObjectLayers.Static : ObjectLayers.Moving
            );

            return bodies.CreateBody(settings);
        }

        private void InitializeScene()
        {
            var bodies = PhysicsSystem.GetBodyInterface();

            foreach (var managedBody in UnityEngine.Object.FindObjectsByType<PhysicsBody>(FindObjectsSortMode.None))
            {
                var nativeBody = CreateNativeBodyFromGameObject(bodies, managedBody.gameObject);

                bodies.AddBody(nativeBody.GetID(), Activation.Activate);

                managedBody.NativeBody = nativeBody;
                managedBody.NativeBodyID = nativeBody.GetID();

                managedBodyList.Add(managedBody);
            }

            foreach (var managedConstraint in UnityEngine.Object.FindObjectsByType<PhysicsConstraintBase>(FindObjectsSortMode.None))
            {
                PhysicsSystem.AddConstraint(managedConstraint.Initialize(this));
            }
        }

        /// <summary>
        /// Advance the physics system by <paramref name="dt"/> seconds and update all of the managed game objects.
        /// </summary>
        public void Update(float dt)
        {
            if (PhysicsSystem.Update(dt, CollisionSteps, nativeJobSystem, out var error))
            {
                PhysicsTime += dt;
                UpdateManagedTransforms();
            }
            else
            {
                Debug.LogError(error);
            }
        }

        private void UpdateManagedTransforms()
        {
#if JOLT_DOUBLE_PRECISION
            throw new NotImplementedException();
#endif
            var bodies = PhysicsSystem.GetBodyInterface();

            foreach (var managedBody in managedBodyList)
            {
                // assume no scaling and skip decomposition

                var wt = (float4x4) bodies.GetWorldTransform(managedBody.NativeBodyID!.Value);

                var position = wt.c3.xyz;
                var rotation = new quaternion(wt);

                managedBody.transform.SetPositionAndRotation(position, rotation);
            }
        }

        public void Destroy()
        {
            PhysicsSystem.Destroy();
        }
    }
}