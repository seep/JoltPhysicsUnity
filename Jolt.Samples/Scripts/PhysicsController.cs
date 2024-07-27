using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jolt.Samples
{
    public class PhysicsController : MonoBehaviour
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

        private static class ObjectLayers
        {
            public static readonly ObjectLayer Static = 0;
            public static readonly ObjectLayer Moving = 1;
            public const uint NumLayers = 2;
        }

        private static class BroadPhaseLayers
        {
            public static readonly BroadPhaseLayer Static = 0;
            public static readonly BroadPhaseLayer Moving = 1;
            public const uint NumLayers = 2;
        }

        private const int CollisionSteps = 1;

        private PhysicsSystem system;
        private BodyInterface bodies;

        private ManagedPhysicsContext context = new ();

        private void Start()
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

            system = new PhysicsSystem(settings);
            bodies = system.GetBodyInterface();

            foreach (var addon in GetComponents<IPhysicsSystemAddon>())
            {
                addon.Initialize(system); // initialize any adjacent addons
            }

            foreach (var component in FindObjectsByType<PhysicsBody>(FindObjectsSortMode.None))
            {
                var body = PhysicsHelpers.CreateBodyFromGameObject(bodies, component);

                var bodyID = body.GetID();

                context.ManagedToNative.Add(component, body);
                context.NativeToManaged.Add(body, component);
                context.Bodies.Add((bodyID, component));

                bodies.AddBody(bodyID, Activation.Activate);
            }

            foreach (var component in FindObjectsByType<PhysicsConstraint>(FindObjectsSortMode.None))
            {
                var constraint = PhysicsHelpers.CreateConstraint(context, component);

                system.AddConstraint(constraint);
            }

            system.OptimizeBroadPhase();
        }

        private void FixedUpdate()
        {
            if (system.Step(Time.fixedDeltaTime, CollisionSteps, out var error))
            {
                UpdateManagedTransforms();
            }
            else
            {
                Debug.LogError(error);
            }
        }

        private void UpdateManagedTransforms()
        {
            foreach (var (bodyID, component) in context.Bodies)
            {
                // assume no scaling and skip decomposition

                #if JOLT_DOUBLE_PRECISION
                throw new NotImplementedException();
                #endif

                var wt = (float4x4) bodies.GetWorldTransform(bodyID);

                var position = wt.c3.xyz;
                var rotation = new quaternion(wt);

                component.transform.SetLocalPositionAndRotation(position, rotation);
            }
        }

        private void OnDestroy()
        {
            system.Dispose();
        }
    }
}
