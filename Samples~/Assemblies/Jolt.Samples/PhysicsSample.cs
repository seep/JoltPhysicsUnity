using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Jolt.Samples
{
    /// <summary>
    /// The general purpose physics controller for all of the sample scenes. Handles initialization and updating the physics system.
    /// </summary>
    public class PhysicsSample : MonoBehaviour
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

        private readonly List<PhysicsSampleAddon> addons = new ();

        public readonly ManagedPhysicsContext ManagedPhysicsContext = new ();
        
        /// <summary>
        /// The accumulated time of the physics system updates.
        /// </summary>
        public float PhysicsTime { get; private set; } 
        
        private void Awake()
        {
            // FindObjectsByType is used throughout the samples as a simple way to discover scene dependencies, so
            // that the sample code can remain focused on how the Jolt bindings work. A real project should use a
            // better strategy to initialize Jolt from scene data.
            
            addons.AddRange(FindObjectsByType<PhysicsSampleAddon>(FindObjectsSortMode.None));
        }
        
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

            // Initialize bodies found in the scene.
            
            foreach (var component in FindObjectsByType<PhysicsBody>(FindObjectsSortMode.None))
            {
                var body = PhysicsHelpers.CreateBodyFromGameObject(bodies, component);
                
                bodies.AddBody(body.GetID(), Activation.Activate);
                
                ManagedPhysicsContext.Add(body, component);
            }

            // Initialize constraints found in the scene.
            
            foreach (var component in FindObjectsByType<PhysicsConstraintBase>(FindObjectsSortMode.None))
            {
                system.AddConstraint(component.Initialize(ManagedPhysicsContext));
            }

            // Initialize addons (extended behavior for individual samples).
            
            foreach (var addon in addons)
            {
                addon.Initialize(system, ManagedPhysicsContext);
            }
            
            // Optimize after the world is well defined.

            system.OptimizeBroadPhase();
        }

        private void FixedUpdate()
        {
            foreach (var addon in addons)
            {
                addon.PrePhysicsStep(system, ManagedPhysicsContext);
            }

            var dt = Time.fixedDeltaTime;
            
            if (system.Update(dt, CollisionSteps, out var error))
            {
                PhysicsTime += dt;
                
                UpdateManagedTransforms();
            }
            else
            {
                Debug.LogError(error);
            }
            
            foreach (var addon in addons)
            {
                addon.PostPhysicsStep(system, ManagedPhysicsContext);
            }
        }

        private void UpdateManagedTransforms()
        {
            foreach (var (bodyID, component) in ManagedPhysicsContext.Bodies)
            {
                // assume no scaling and skip decomposition

                #if JOLT_DOUBLE_PRECISION
                throw new NotImplementedException();
                #endif

                var wt = (float4x4) bodies.GetWorldTransform(bodyID);

                var position = wt.c3.xyz;
                var rotation = new quaternion(wt);

                component.transform.SetPositionAndRotation(position, rotation);
            }
        }

        private void OnDestroy()
        {
            system.Dispose();
        }
    }
}
