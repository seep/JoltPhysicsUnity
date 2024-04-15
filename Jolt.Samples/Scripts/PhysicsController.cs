using System.Collections.Generic;
using UnityEngine;

namespace Jolt.Samples
{
    public class PhysicsController : MonoBehaviour
    {
        private const uint MaxBodies = 1024;
        private const uint MaxBodyPairs = 1024;
        private const uint MaxContactConstraints = 1024;

        private const int CollisionSteps = 1;

        private PhysicsSystem system;
        private BodyInterface bodies;

        private List<(BodyID, GameObject)> managedGameObjects = new();

        private void Start()
        {
            var settings = new PhysicsSystemSettings
            {
                MaxBodies = MaxBodies,
                MaxBodyPairs = MaxBodyPairs,
                MaxContactConstraints = MaxContactConstraints
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
