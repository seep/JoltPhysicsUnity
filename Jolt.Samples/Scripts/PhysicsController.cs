using System.Collections.Generic;
using UnityEngine;

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

        private const int CollisionSteps = 1;

        private PhysicsSystem system;
        private BodyInterface bodies;

        private List<(BodyID, GameObject)> managedGameObjects = new();

        private void Start()
        {
            var objectLayerPairFilter = ObjectLayerPairFilterTable.Create(2);

            objectLayerPairFilter.EnableCollision(0, 1);
            objectLayerPairFilter.EnableCollision(1, 1);

            var broadPhaseLayerInterface = BroadPhaseLayerInterfaceTable.Create(2, 2);

            broadPhaseLayerInterface.MapObjectToBroadPhaseLayer(0, 0);
            broadPhaseLayerInterface.MapObjectToBroadPhaseLayer(1, 1);

            var objectVsBroadPhaseLayerFilter = ObjectVsBroadPhaseLayerFilterTable.Create(broadPhaseLayerInterface, 2, objectLayerPairFilter, 2);

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

            foreach (var authoring in FindObjectsByType<PhysicsBody>(FindObjectsSortMode.None))
            {
                var bodyID = PhysicsHelpers.CreateBodyFromGameObject(bodies, authoring.gameObject);
                managedGameObjects.Add((bodyID, authoring.gameObject));
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
            foreach (var (bodyID, gobj) in managedGameObjects)
            {
                PhysicsHelpers.ApplyTransform(bodies, bodyID, gobj.transform);
            }
        }

        private void OnDestroy()
        {
            system.Dispose();
        }
    }
}
