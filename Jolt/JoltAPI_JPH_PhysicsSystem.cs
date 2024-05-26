using System;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe partial class JoltAPI
    {
        public static NativeHandle<JPH_PhysicsSystem> JPH_PhysicsSystem_Create(PhysicsSystemSettings settings)
        {
            var nativeSettings = new JPH_PhysicsSystemSettings
            {
                maxBodies = settings.MaxBodies,
                maxBodyPairs = settings.MaxBodyPairs,
                maxContactConstraints = settings.MaxContactConstraints,
                objectLayerPairFilter = GetPointer(settings.ObjectLayerPairFilter.Handle),
                broadPhaseLayerInterface = GetPointer(settings.BroadPhaseLayerInterface.Handle),
                objectVsBroadPhaseLayerFilter = GetPointer(settings.ObjectVsBroadPhaseLayerFilter.Handle)
            };

            return CreateHandle(Bindings.JPH_PhysicsSystem_Create(&nativeSettings));
        }

        public static void JPH_PhysicsSystem_Destroy(NativeHandle<JPH_PhysicsSystem> system)
        {
            Bindings.JPH_PhysicsSystem_Destroy(GetPointer(system));

            system.Dispose();
        }

        public static void JPH_PhysicsSystem_OptimizeBroadPhase(NativeHandle<JPH_PhysicsSystem> system)
        {
            Bindings.JPH_PhysicsSystem_OptimizeBroadPhase(GetPointer(system));
        }

        public static PhysicsUpdateError JPH_PhysicsSystem_Step(NativeHandle<JPH_PhysicsSystem> system, float deltaTime, int collisionSteps)
        {
            return Bindings.JPH_PhysicsSystem_Step(GetPointer(system), deltaTime, collisionSteps);
        }

        public static NativeHandle<JPH_BodyInterface> JPH_PhysicsSystem_GetBodyInterface(NativeHandle<JPH_PhysicsSystem> system)
        {
            return CreateOwnedHandle(system, Bindings.JPH_PhysicsSystem_GetBodyInterface(GetPointer(system)));
        }

        public static NativeHandle<JPH_BodyInterface> JPH_PhysicsSystem_GetBodyInterfaceNoLock(NativeHandle<JPH_PhysicsSystem> system)
        {
            return CreateOwnedHandle(system, Bindings.JPH_PhysicsSystem_GetBodyInterfaceNoLock(GetPointer(system)));
        }

        public static NativeHandle<JPH_BodyLockInterface> JPH_PhysicsSystem_GetBodyLockInterface(NativeHandle<JPH_PhysicsSystem> system)
        {
            return CreateOwnedHandle(system, Bindings.JPH_PhysicsSystem_GetBodyLockInterface(GetPointer(system)));
        }

        public static NativeHandle<JPH_BodyLockInterface> JPH_PhysicsSystem_GetBodyLockInterfaceNoLock(NativeHandle<JPH_PhysicsSystem> system)
        {
            return CreateOwnedHandle(system, Bindings.JPH_PhysicsSystem_GetBodyLockInterfaceNoLock(GetPointer(system)));
        }

        public static NativeHandle<JPH_NarrowPhaseQuery> JPH_PhysicsSystem_GetNarrowPhaseQuery(NativeHandle<JPH_PhysicsSystem> system)
        {
            return CreateOwnedHandle(system, Bindings.JPH_PhysicsSystem_GetNarrowPhaseQuery(GetPointer(system)));
        }

        public static NativeHandle<JPH_NarrowPhaseQuery> JPH_PhysicsSystem_GetNarrowPhaseQueryNoLock(NativeHandle<JPH_PhysicsSystem> system)
        {
            return CreateOwnedHandle(system, Bindings.JPH_PhysicsSystem_GetNarrowPhaseQueryNoLock(GetPointer(system)));
        }

        public static void JPH_PhysicsSystem_SetContactListener(NativeHandle<JPH_PhysicsSystem> system, NativeHandle<JPH_ContactListener> listener)
        {
            Bindings.JPH_PhysicsSystem_SetContactListener(GetPointer(system), GetPointer(listener));
        }

        public static void JPH_PhysicsSystem_SetBodyActivationListener(NativeHandle<JPH_PhysicsSystem> system, NativeHandle<JPH_BodyActivationListener> listener)
        {
            Bindings.JPH_PhysicsSystem_SetBodyActivationListener(GetPointer(system), GetPointer(listener));
        }

        public static uint JPH_PhysicsSystem_GetNumBodies(NativeHandle<JPH_PhysicsSystem> system)
        {
            return Bindings.JPH_PhysicsSystem_GetNumBodies(GetPointer(system));
        }

        public static uint JPH_PhysicsSystem_GetNumActiveBodies(NativeHandle<JPH_PhysicsSystem> system, BodyType type)
        {
            return Bindings.JPH_PhysicsSystem_GetNumActiveBodies(GetPointer(system), type);
        }

        public static uint JPH_PhysicsSystem_GetMaxBodies(NativeHandle<JPH_PhysicsSystem> system)
        {
            return Bindings.JPH_PhysicsSystem_GetMaxBodies(GetPointer(system));
        }

        public static void JPH_PhysicsSystem_SetGravity(NativeHandle<JPH_PhysicsSystem> system, float3 gravity)
        {
            Bindings.JPH_PhysicsSystem_SetGravity(GetPointer(system), &gravity);
        }

        public static float3 JPH_PhysicsSystem_GetGravity(NativeHandle<JPH_PhysicsSystem> system)
        {
            float3 gravity = default;

            Bindings.JPH_PhysicsSystem_GetGravity(GetPointer(system), &gravity);

            return gravity;
        }

        public static void JPH_PhysicsSystem_AddConstraint(NativeHandle<JPH_PhysicsSystem> system)
        {
            throw new NotImplementedException();
        }

        public static void JPH_PhysicsSystem_RemoveConstraint(NativeHandle<JPH_PhysicsSystem> system)
        {
            throw new NotImplementedException();
        }

        public static void JPH_PhysicsSystem_AddConstraints(NativeHandle<JPH_PhysicsSystem> system)
        {
            throw new NotImplementedException();
        }

        public static void JPH_PhysicsSystem_RemoveConstraints(NativeHandle<JPH_PhysicsSystem> system)
        {
            throw new NotImplementedException();
        }

        public static void JPH_PhysicsSystem_GetBodies(NativeHandle<JPH_PhysicsSystem> system)
        {
            throw new NotImplementedException();
        }

        public static void JPH_PhysicsSystem_GetConstraints(NativeHandle<JPH_PhysicsSystem> system)
        {
            throw new NotImplementedException();
        }
    }
}
