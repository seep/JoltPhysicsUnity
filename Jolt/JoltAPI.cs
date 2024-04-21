using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;

namespace Jolt
{
    internal static unsafe class JoltAPI
    {
        #region Handle Management

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static NativeHandle<T> CreateHandle<T>(T* ptr) where T : unmanaged
        {
            return new NativeHandle<T>(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static NativeHandle<U> CreateOwnedHandle<T, U>(NativeHandle<T> owner, U* ptr) where T : unmanaged where U : unmanaged
        {
            return owner.CreateOwnedHandle(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T* GetPointer<T>(NativeHandle<T> handle) where T : unmanaged
        {
            return handle.Unwrap();
        }

        #endregion

        #region JPH

        public static bool JPH_Init(uint tempAllocatorSize)
        {
            return Bindings.JPH_Init(tempAllocatorSize);
        }

        public static void JPH_Shutdown()
        {
            Bindings.JPH_Shutdown();
        }

        public static void JPH_SetAssertFailureHandler(AssertFailureHandler handler)
        {
            Bindings.JPH_SetAssertFailureHandler(Marshal.GetFunctionPointerForDelegate(handler));
        }

        internal delegate void AssertFailureHandler(string expr, string message, string file, uint line);

        #endregion

        #region JPH_BroadPhaseLayerInterfaceMask

        public static NativeHandle<JPH_BroadPhaseLayerInterface> JPH_BroadPhaseLayerInterfaceMask_Create(uint numBroadPhaseLayers)
        {
            return CreateHandle(Bindings.JPH_BroadPhaseLayerInterfaceMask_Create(numBroadPhaseLayers));
        }

        public static void JPH_BroadPhaseLayerInterfaceMask_ConfigureLayer(NativeHandle<JPH_BroadPhaseLayerInterface> @interface, BroadPhaseLayer broadPhaseLayer, uint groupsToInclude, uint groupsToExclude)
        {
            Bindings.JPH_BroadPhaseLayerInterfaceMask_ConfigureLayer(GetPointer(@interface), broadPhaseLayer, groupsToInclude, groupsToExclude);
        }

        #endregion

        #region JPH_BroadPhaseLayerInterfaceTable

        public static NativeHandle<JPH_BroadPhaseLayerInterface> JPH_BroadPhaseLayerInterfaceTable_Create(uint numObjectLayers, uint numBroadPhaseLayers)
        {
            return CreateHandle(Bindings.JPH_BroadPhaseLayerInterfaceTable_Create(numObjectLayers, numBroadPhaseLayers));
        }

        public static void JPH_BroadPhaseLayerInterfaceTable_MapObjectToBroadPhaseLayer(NativeHandle<JPH_BroadPhaseLayerInterface> @interface, ObjectLayer objectLayer, BroadPhaseLayer broadPhaseLayer)
        {
            Bindings.JPH_BroadPhaseLayerInterfaceTable_MapObjectToBroadPhaseLayer(GetPointer(@interface), objectLayer, broadPhaseLayer);
        }

        #endregion

        #region JPH_ObjectLayerPairFilterMask

        public static NativeHandle<JPH_ObjectLayerPairFilter> JPH_ObjectLayerPairFilterMask_Create()
        {
            return CreateHandle(Bindings.JPH_ObjectLayerPairFilterMask_Create());
        }

        public static ObjectLayer JPH_ObjectLayerPairFilterMask_GetObjectLayer(uint group, uint mask)
        {
            return Bindings.JPH_ObjectLayerPairFilterMask_GetObjectLayer(group, mask);
        }

        public static uint JPH_ObjectLayerPairFilterMask_GetGroup(ObjectLayer layer)
        {
            return Bindings.JPH_ObjectLayerPairFilterMask_GetGroup(layer);
        }

        public static uint JPH_ObjectLayerPairFilterMask_GetMask(ObjectLayer layer)
        {
            return Bindings.JPH_ObjectLayerPairFilterMask_GetMask(layer);
        }

        #endregion

        #region JPH_ObjectLayerPairFilterTable

        public static NativeHandle<JPH_ObjectLayerPairFilter> JPH_ObjectLayerPairFilterTable_Create(uint numObjectLayers)
        {
            return CreateHandle(Bindings.JPH_ObjectLayerPairFilterTable_Create(numObjectLayers));
        }

        public static void JPH_ObjectLayerPairFilterTable_DisableCollision(NativeHandle<JPH_ObjectLayerPairFilter> filter, ObjectLayer layerA, ObjectLayer layerB)
        {
            Bindings.JPH_ObjectLayerPairFilterTable_DisableCollision(GetPointer(filter), layerA, layerB);
        }

        public static void JPH_ObjectLayerPairFilterTable_EnableCollision(NativeHandle<JPH_ObjectLayerPairFilter> filter, ObjectLayer layerA, ObjectLayer layerB)
        {
            Bindings.JPH_ObjectLayerPairFilterTable_EnableCollision(GetPointer(filter), layerA, layerB);
        }

        public static bool JPH_ObjectLayerPairFilterTable_ShouldCollide(NativeHandle<JPH_ObjectLayerPairFilter> filter, ObjectLayer layerA, ObjectLayer layerB)
        {
            return Bindings.JPH_ObjectLayerPairFilterTable_ShouldCollide(GetPointer(filter), layerA, layerB);
        }

        #endregion

        #region JPH_ObjectVsBroadPhaseLayerFilterMask

        public static NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> JPH_ObjectVsBroadPhaseLayerFilterMask_Create(NativeHandle<JPH_BroadPhaseLayerInterface> @interface)
        {
            return CreateHandle(Bindings.JPH_ObjectVsBroadPhaseLayerFilterMask_Create(GetPointer(@interface)));
        }

        #endregion

        #region JPH_ObjectVsBroadPhaseLayerFilterTable

        public static NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> JPH_ObjectVsBroadPhaseLayerFilterTable_Create(NativeHandle<JPH_BroadPhaseLayerInterface> @interface, uint numBroadPhaseLayers, NativeHandle<JPH_ObjectLayerPairFilter> filter, uint numObjectLayers)
        {
            return CreateHandle(Bindings.JPH_ObjectVsBroadPhaseLayerFilterTable_Create(GetPointer(@interface), numBroadPhaseLayers, GetPointer(filter), numObjectLayers));
        }

        #endregion

        #region JPH_PhysicsSystem

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

        public static void JPH_PhysicsSystem_Destroy(NativeHandle<JPH_PhysicsSystem> handle)
        {
            Bindings.JPH_PhysicsSystem_Destroy(GetPointer(handle));

            handle.Dispose();
        }

        public static void JPH_PhysicsSystem_OptimizeBroadPhase(NativeHandle<JPH_PhysicsSystem> handle)
        {
            Bindings.JPH_PhysicsSystem_OptimizeBroadPhase(GetPointer(handle));
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

        public static NativeHandle<JPH_BodyLockInterface> JPC_PhysicsSystem_GetBodyLockInterface(NativeHandle<JPH_PhysicsSystem> system)
        {
            return CreateOwnedHandle(system, Bindings.JPC_PhysicsSystem_GetBodyLockInterface(GetPointer(system)));
        }

        public static NativeHandle<JPH_BodyLockInterface> JPC_PhysicsSystem_GetBodyLockInterfaceNoLock(NativeHandle<JPH_PhysicsSystem> system)
        {
            return CreateOwnedHandle(system, Bindings.JPC_PhysicsSystem_GetBodyLockInterfaceNoLock(GetPointer(system)));
        }

        public static NativeHandle<JPH_NarrowPhaseQuery> JPC_PhysicsSystem_GetNarrowPhaseQuery(NativeHandle<JPH_PhysicsSystem> system)
        {
            return CreateOwnedHandle(system, Bindings.JPC_PhysicsSystem_GetNarrowPhaseQuery(GetPointer(system)));
        }

        public static NativeHandle<JPH_NarrowPhaseQuery> JPC_PhysicsSystem_GetNarrowPhaseQueryNoLock(NativeHandle<JPH_PhysicsSystem> system)
        {
            return CreateOwnedHandle(system, Bindings.JPC_PhysicsSystem_GetNarrowPhaseQueryNoLock(GetPointer(system)));
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

        #endregion

        // JPH_Quaternion_FromTo covered by Unity.Mathematics

        #region JPH_ShapeSettings

        public static void JPH_ShapeSettings_Destroy<T>(NativeHandle<T> settings) where T : unmanaged, INativeShapeSettings
        {
            Bindings.JPH_ShapeSettings_Destroy((JPH_ShapeSettings*) GetPointer(settings));

            settings.Dispose();
        }

        #endregion

        #region JPH_ConvexShape

        public static float JPH_ConvexShape_GetDensity<T>(NativeHandle<T> shape) where T : unmanaged, INativeConvexShape
        {
            return Bindings.JPH_ConvexShape_GetDensity((JPH_ConvexShape*) GetPointer(shape));
        }

        public static void JPH_ConvexShape_SetDensity<T>(NativeHandle<T> shape, float density) where T : unmanaged, INativeConvexShape
        {
            Bindings.JPH_ConvexShape_SetDensity((JPH_ConvexShape*) GetPointer(shape), density);
        }

        #endregion

        #region JPH_BoxShapeSettings

        public static NativeHandle<JPH_BoxShapeSettings> JPH_BoxShapeSettings_Create(float3 halfExtent, float convexRadius)
        {
            return CreateHandle(Bindings.JPH_BoxShapeSettings_Create(&halfExtent, convexRadius));
        }

        public static NativeHandle<JPH_BoxShape> JPH_BoxShapeSettings_CreateShape(NativeHandle<JPH_BoxShapeSettings> settings)
        {
            return CreateHandle(Bindings.JPH_BoxShapeSettings_CreateShape(GetPointer(settings)));
        }

        #endregion

        #region JPH_BoxShape

        public static NativeHandle<JPH_BoxShape> JPH_BoxShape_Create(float3 halfExtent, float convexRadius)
        {
            return CreateHandle(Bindings.JPH_BoxShape_Create(&halfExtent, convexRadius));
        }

        public static float3 JPH_BoxShape_GetHalfExtent(NativeHandle<JPH_BoxShape> shape)
        {
            float3 result = default;

            Bindings.JPH_BoxShape_GetHalfExtent(GetPointer(shape), &result);

            return result;
        }

        public static float JPH_BoxShape_GetVolume(NativeHandle<JPH_BoxShape> shape)
        {
            return Bindings.JPH_BoxShape_GetVolume(GetPointer(shape));
        }

        public static float JPH_BoxShape_GetConvexRadius(NativeHandle<JPH_BoxShape> shape)
        {
            return Bindings.JPH_BoxShape_GetConvexRadius(GetPointer(shape));
        }

        #endregion

        #region JPH_SphereShapeSettings

        public static NativeHandle<JPH_SphereShapeSettings> JPH_SphereShapeSettings_Create(float radius)
        {
            return CreateHandle(Bindings.JPH_SphereShapeSettings_Create(radius));
        }

        public static NativeHandle<JPH_SphereShape> JPH_SphereShapeSettings_CreateShape(NativeHandle<JPH_SphereShapeSettings> settings)
        {
            return CreateHandle(Bindings.JPH_SphereShapeSettings_CreateShape(GetPointer(settings)));
        }

        public static float JPH_SphereShapeSettings_GetRadius(NativeHandle<JPH_SphereShapeSettings> settings)
        {
            return Bindings.JPH_SphereShapeSettings_GetRadius(GetPointer(settings));
        }

        public static void JPH_SphereShapeSettings_SetRadius(NativeHandle<JPH_SphereShapeSettings> settings, float radius)
        {
            Bindings.JPH_SphereShapeSettings_SetRadius(GetPointer(settings), radius);
        }

        #endregion

        #region JPH_SphereShape

        public static NativeHandle<JPH_SphereShape> JPH_SphereShape_Create(float radius)
        {
            return CreateHandle(Bindings.JPH_SphereShape_Create(radius));
        }

        public static float JPH_SphereShape_GetRadius(NativeHandle<JPH_SphereShape> shape)
        {
            return Bindings.JPH_SphereShape_GetRadius(GetPointer(shape));
        }

        #endregion

        #region JPH_TriangleShapeSettings

        public static NativeHandle<JPH_TriangleShapeSettings> JPH_TriangleShapeSettings_Create(float3 va, float3 vb, float3 vc, float convexRadius)
        {
            return CreateHandle(Bindings.JPH_TriangleShapeSettings_Create(&va, &vb, &vc, convexRadius));
        }

        #endregion

        #region JPH_CapsuleShapeSettings

        public static NativeHandle<JPH_CapsuleShapeSettings> JPH_CapsuleShapeSettings_Create(float halfHeightOfCylinder, float radius)
        {
            return CreateHandle(Bindings.JPH_CapsuleShapeSettings_Create(halfHeightOfCylinder, radius));
        }

        #endregion

        #region JPH_CapsuleShape_Create

        public static NativeHandle<JPH_CapsuleShape> JPH_CapsuleShape_Create(float halfHeightOfCylinder, float radius)
        {
            return CreateHandle(Bindings.JPH_CapsuleShape_Create(halfHeightOfCylinder, radius));
        }

        public static float JPH_CapsuleShape_GetRadius(NativeHandle<JPH_CapsuleShape> shape)
        {
            return Bindings.JPH_CapsuleShape_GetRadius(GetPointer(shape));
        }

        public static float JPH_CapsuleShape_GetHalfHeightOfCylinder(NativeHandle<JPH_CapsuleShape> shape)
        {
            return Bindings.JPH_CapsuleShape_GetHalfHeightOfCylinder(GetPointer(shape));
        }

        #endregion

        #region JPH_CylinderShapeSettings

        public static NativeHandle<JPH_CylinderShapeSettings> JPH_CylinderShapeSettings_Create(float halfHeight, float radius, float convexRadius)
        {
            return CreateHandle(Bindings.JPH_CylinderShapeSettings_Create(halfHeight, radius, convexRadius));
        }

        #endregion

        #region JPH_CylinderShape

        public static NativeHandle<JPH_CylinderShape> JPH_CylinderShape_Create(float halfHeight, float radius)
        {
            return CreateHandle(Bindings.JPH_CylinderShape_Create(halfHeight, radius));
        }

        public static float JPH_CylinderShape_GetRadius(NativeHandle<JPH_CylinderShape> shape)
        {
            return Bindings.JPH_CylinderShape_GetRadius(GetPointer(shape));
        }

        public static float JPH_CylinderShape_GetHalfHeight(NativeHandle<JPH_CylinderShape> shape)
        {
            return Bindings.JPH_CylinderShape_GetHalfHeight(GetPointer(shape));
        }

        #endregion

        #region JPH_ConvexShapeSettings

        public static float JPH_ConvexShapeSettings_GetDensity<T>(NativeHandle<T> settings) where T : unmanaged, INativeConvexShapeSettings
        {
            return Bindings.JPH_ConvexShapeSettings_GetDensity((JPH_ConvexShapeSettings*) GetPointer(settings));
        }

        public static void JPH_ConvexShapeSettings_SetDensity<T>(NativeHandle<T> settings, float density) where T : unmanaged, INativeConvexShapeSettings
        {
            Bindings.JPH_ConvexShapeSettings_SetDensity((JPH_ConvexShapeSettings*) GetPointer(settings), density);
        }

        #endregion

        #region JPH_ConvexHullShapeSettings

        public static NativeHandle<JPH_ConvexHullShapeSettings> JPH_ConvexHullShapeSettings_Create(ReadOnlySpan<float3> points, float maxConvexRadius)
        {
            fixed (float3* pointsPtr = points)
            {
                return CreateHandle(Bindings.JPH_ConvexHullShapeSettings_Create(pointsPtr, (uint) points.Length, maxConvexRadius));
            }
        }

        public static NativeHandle<JPH_ConvexHullShape> JPH_ConvexHullShapeSettings_CreateShape(NativeHandle<JPH_ConvexHullShapeSettings> settings)
        {
            return CreateHandle(Bindings.JPH_ConvexHullShapeSettings_CreateShape(GetPointer(settings)));
        }

        #endregion

        #region JPH_MeshShapeSettings

        public static NativeHandle<JPH_MeshShapeSettings> JPH_MeshShapeSettings_Create(ReadOnlySpan<Triangle> triangles)
        {
            fixed (Triangle* trianglesPtr = triangles)
            {
                return CreateHandle(Bindings.JPH_MeshShapeSettings_Create(trianglesPtr, (uint) triangles.Length));
            }
        }

        public static NativeHandle<JPH_MeshShapeSettings> JPH_MeshShapeSettings_Create2(ReadOnlySpan<float3> vertices, ReadOnlySpan<IndexedTriangle> triangles)
        {
            fixed (float3* verticesPtr = vertices)
            fixed (IndexedTriangle* trianglesPtr = triangles)
            {
                return CreateHandle(Bindings.JPH_MeshShapeSettings_Create2(verticesPtr, (uint) vertices.Length, trianglesPtr, (uint) triangles.Length));
            }
        }

        public static void JPH_MeshShapeSettings_Sanitize(NativeHandle<JPH_MeshShapeSettings> settings)
        {
            Bindings.JPH_MeshShapeSettings_Sanitize(GetPointer(settings));
        }

        public static NativeHandle<JPH_MeshShape> JPH_MeshShapeSettings_CreateShape(NativeHandle<JPH_MeshShapeSettings> settings)
        {
            return CreateHandle(Bindings.JPH_MeshShapeSettings_CreateShape(GetPointer(settings)));
        }

        public static NativeHandle<JPH_HeightFieldShapeSettings> JPH_HeightFieldShapeSettings_Create(ReadOnlySpan<float> samples, ReadOnlySpan<float3> offset, ReadOnlySpan<float3> scale)
        {
            fixed (float* samplesPtr = samples)
            fixed (float3* offsetPtr = offset)
            fixed (float3* scalePtr = scale)
            {
                return CreateHandle(Bindings.JPH_HeightFieldShapeSettings_Create(samplesPtr, offsetPtr, scalePtr, (uint) samples.Length));
            }
        }

        public static void JPH_HeightFieldShapeSettings_DetermineMinAndMaxSample(NativeHandle<JPH_HeightFieldShapeSettings> settings, out float min, out float max, out float quantization)
        {
            fixed (float* minPtr = &min)
            fixed (float* maxPtr = &max)
            fixed (float* quantizationPtr = &quantization)
            {
                Bindings.JPH_HeightFieldShapeSettings_DetermineMinAndMaxSample(GetPointer(settings), minPtr, maxPtr, quantizationPtr);
            }
        }

        public static uint JPH_HeightFieldShapeSettings_CalculateBitsPerSampleForError(NativeHandle<JPH_HeightFieldShapeSettings> settings, float maxError)
        {
            return Bindings.JPH_HeightFieldShapeSettings_CalculateBitsPerSampleForError(GetPointer(settings), maxError);
        }

        #endregion

        #region JPH_TaperedCapsuleShapeSettings

        public static NativeHandle<JPH_TaperedCapsuleShapeSettings> JPH_TaperedCapsuleShapeSettings_Create(float halfHeightOfTaperedCylinder, float topRadius, float bottomRadius)
        {
            return CreateHandle(Bindings.JPH_TaperedCapsuleShapeSettings_Create(halfHeightOfTaperedCylinder, topRadius, bottomRadius));
        }

        #endregion

        #region JPH_CompoundShapeSetting

        public static void JPH_CompoundShapeSettings_AddShape<T, U>(NativeHandle<T> settings, float3 position, quaternion rotation, NativeHandle<U> shape, uint userData) where T : unmanaged, INativeCompoundShapeSettings where U : unmanaged, INativeShapeSettings
        {
            Bindings.JPH_CompoundShapeSettings_AddShape((JPH_CompoundShapeSettings*) GetPointer(settings), &position, &rotation, (JPH_ShapeSettings*) GetPointer(shape), userData);
        }

        public static void JPH_CompoundShapeSettings_AddShape2<T, U>(NativeHandle<T> settings, float3 position, quaternion rotation, NativeHandle<U> shape, uint userData) where T : unmanaged, INativeCompoundShapeSettings where U : unmanaged, INativeShape
        {
            Bindings.JPH_CompoundShapeSettings_AddShape2((JPH_CompoundShapeSettings*) GetPointer(settings), &position, &rotation, (JPH_Shape*) GetPointer(shape), userData);
        }

        public static NativeHandle<JPH_StaticCompoundShapeSettings> JPH_StaticCompoundShapeSettings_Create()
        {
            return CreateHandle(Bindings.JPH_StaticCompoundShapeSettings_Create());
        }

        public static NativeHandle<JPH_MutableCompoundShapeSettings> JPH_MutableCompoundShapeSettings_Create()
        {
            return CreateHandle(Bindings.JPH_MutableCompoundShapeSettings_Create());
        }

        public static NativeHandle<JPH_MutableCompoundShape> JPH_MutableCompoundShape_Create(NativeHandle<JPH_MutableCompoundShapeSettings> settings)
        {
            return CreateHandle(Bindings.JPH_MutableCompoundShape_Create(GetPointer(settings)));
        }


        #endregion

        #region JPH_RotatedTranslatedShapeSettings

        public static NativeHandle<JPH_RotatedTranslatedShapeSettings> JPH_RotatedTranslatedShapeSettings_Create(float3 position, quaternion rotation, NativeHandle<JPH_ShapeSettings> settings)
        {
            return CreateHandle(Bindings.JPH_RotatedTranslatedShapeSettings_Create(&position, &rotation, GetPointer(settings)));
        }

        public static NativeHandle<JPH_RotatedTranslatedShapeSettings> JPH_RotatedTranslatedShapeSettings_Create2(float3 position, quaternion rotation, NativeHandle<JPH_Shape> shape)
        {
            return CreateHandle(Bindings.JPH_RotatedTranslatedShapeSettings_Create2(&position, &rotation, GetPointer(shape)));
        }

        public static NativeHandle<JPH_RotatedTranslatedShape> JPH_RotatedTranslatedShapeSettings_CreateShape(NativeHandle<JPH_RotatedTranslatedShapeSettings> settings)
        {
            return CreateHandle(Bindings.JPH_RotatedTranslatedShapeSettings_CreateShape(GetPointer(settings)));
        }

        #endregion

        #region JPH_RotatedTranslatedShape

        public static NativeHandle<JPH_RotatedTranslatedShape> JPH_RotatedTranslatedShape_Create(float3 position, quaternion rotation, NativeHandle<JPH_Shape> shape)
        {
            return CreateHandle(Bindings.JPH_RotatedTranslatedShape_Create(&position, &rotation, GetPointer(shape)));
        }

        #endregion

        #region JPH_Shape

        public static void JPH_Shape_Destroy<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            Bindings.JPH_Shape_Destroy((JPH_Shape*) GetPointer(shape));

            shape.Dispose();
        }

        public static AABox JPH_Shape_GetLocalBounds<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            AABox result;

            Bindings.JPH_Shape_GetLocalBounds((JPH_Shape*) GetPointer(shape), &result);

            return result;
        }

        public static MassProperties JPH_Shape_GetMassProperties<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            MassProperties result;

            Bindings.JPH_Shape_GetMassProperties((JPH_Shape*) GetPointer(shape), &result);

            return result;
        }

        public static float3 JPH_Shape_GetCenterOfMass<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            float3 result = default;

            Bindings.JPH_Shape_GetCenterOfMass((JPH_Shape*) GetPointer(shape), &result);

            return result;
        }

        public static float JPH_Shape_GetInnerRadius<T>(NativeHandle<T> shape) where T : unmanaged, INativeShape
        {
            return Bindings.JPH_Shape_GetInnerRadius((JPH_Shape*) GetPointer(shape));
        }

        #endregion

        #region JPH_BodyCreationSettings

        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create()
        {
            return CreateHandle(Bindings.JPH_BodyCreationSettings_Create());
        }

        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create2<T>(NativeHandle<T> settings, rvec3 position, quaternion rotation, MotionType motion, ushort layer) where T : unmanaged, INativeShapeSettings
        {
            return CreateHandle(Bindings.JPH_BodyCreationSettings_Create2((JPH_ShapeSettings*) GetPointer(settings), &position, &rotation, motion, layer));
        }

        public static NativeHandle<JPH_BodyCreationSettings> JPH_BodyCreationSettings_Create3<T>(NativeHandle<T> shape, rvec3 position, quaternion rotation, MotionType motion, ushort layer) where T : unmanaged, INativeShape
        {
            return CreateHandle(Bindings.JPH_BodyCreationSettings_Create3((JPH_Shape*) GetPointer(shape), &position, &rotation, motion, layer));
        }

        public static void JPH_BodyCreationSettings_Destroy(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            Bindings.JPH_BodyCreationSettings_Destroy(GetPointer(settings));

            settings.Dispose();
        }

        public static float3 JPH_BodyCreationSettings_GetLinearVelocity(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            float3 result;

            Bindings.JPH_BodyCreationSettings_GetLinearVelocity(GetPointer(settings), &result);

            return result;
        }

        public static void JPH_BodyCreationSettings_SetLinearVelocity(NativeHandle<JPH_BodyCreationSettings> settings, float3 velocity)
        {
            Bindings.JPH_BodyCreationSettings_SetLinearVelocity(GetPointer(settings), &velocity);
        }

        public static float3 JPH_BodyCreationSettings_GetAngularVelocity(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            float3 result;

            Bindings.JPH_BodyCreationSettings_GetAngularVelocity(GetPointer(settings), &result);

            return result;
        }

        public static void JPH_BodyCreationSettings_SetAngularVelocity(NativeHandle<JPH_BodyCreationSettings> settings, float3 velocity)
        {
            Bindings.JPH_BodyCreationSettings_SetAngularVelocity(GetPointer(settings), &velocity);
        }

        public static MotionType JPH_BodyCreationSettings_GetMotionType(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return Bindings.JPH_BodyCreationSettings_GetMotionType(GetPointer(settings));
        }

        public static void JPH_BodyCreationSettings_SetMotionType(NativeHandle<JPH_BodyCreationSettings> settings, MotionType value)
        {
            Bindings.JPH_BodyCreationSettings_SetMotionType(GetPointer(settings), value);
        }

        public static AllowedDOFs JPH_BodyCreationSettings_GetAllowedDOFs(NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return Bindings.JPH_BodyCreationSettings_GetAllowedDOFs(GetPointer(settings));
        }

        public static void JPH_BodyCreationSettings_SetAllowedDOFs(NativeHandle<JPH_BodyCreationSettings> settings, AllowedDOFs value)
        {
            Bindings.JPH_BodyCreationSettings_SetAllowedDOFs(GetPointer(settings), value);
        }

        #endregion

        #region JPH_SoftBodyCreationSettings

        public static NativeHandle<JPH_SoftBodyCreationSettings> JPH_SoftBodyCreationSettings()
        {
            return CreateHandle(Bindings.JPH_SoftBodyCreationSettings_Create());
        }

        #endregion

        #region JPH_SpringSettings

        // TODO

        #endregion

        #region JPH_ConstraintSettings

        // TODO

        #endregion

        #region JPH_Constraint

        // TODO

        #endregion

        #region JPH_DistanceConstraint

        // TODO

        #endregion

        #region JPH_PointConstraint

        // TODO

        #endregion

        #region JPH_HingConstraint

        // TODO

        #endregion

        #region JPH_SliderConstraint

        // TODO

        #endregion

        #region JPH_SwingTistConstraint

        // TODO

        #endregion

        #region JPH_SixDOFConstraint

        // TODO

        #endregion

        #region JPH_TwoBodyConstraint

        // TODO

        #endregion

        #region JPH_FixedConstraintSettings

        // TODO

        #endregion

        #region JPH_FixedConstraint

        // TODO

        #endregion

        #region JPH_BodyInterface

        public static void JPH_BodyInterface_DestroyBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            Bindings.JPH_BodyInterface_DestroyBody(GetPointer(@interface), bodyID);

            // TODO mark any active body handles for this bodyID as disposed
        }

        public static BodyID JPH_BodyInterface_CreateAndAddBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings, Activation activation)
        {
            return Bindings.JPH_BodyInterface_CreateAndAddBody(GetPointer(@interface), GetPointer(settings), activation);
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return CreateHandle(Bindings.JPH_BodyInterface_CreateBody(GetPointer(@interface), GetPointer(settings)));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateSoftBody(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_SoftBodyCreationSettings> settings)
        {
            return CreateHandle(Bindings.JPH_BodyInterface_CreateSoftBody(GetPointer(@interface), GetPointer(settings)));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBodyWithID(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return CreateHandle(Bindings.JPH_BodyInterface_CreateBodyWithID(GetPointer(@interface), bodyID, GetPointer(settings)));
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_CreateBodyWithoutID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_BodyCreationSettings> settings)
        {
            return CreateHandle(Bindings.JPH_BodyInterface_CreateBodyWithoutID(GetPointer(@interface), GetPointer(settings)));
        }

        public static void JPH_BodyInterface_DestroyBodyWithoutID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body)
        {
            Bindings.JPH_BodyInterface_DestroyBodyWithoutID(GetPointer(@interface), GetPointer(body));
        }

        public static bool JPH_BodyInterface_AssignBodyID(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_BodyInterface_AssignBodyID(GetPointer(@interface), GetPointer(body));
        }

        public static bool JPH_BodyInterface_AssignBodyID2(NativeHandle<JPH_BodyInterface> @interface, NativeHandle<JPH_Body> body, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_AssignBodyID2(GetPointer(@interface), GetPointer(body), bodyID);
        }

        public static NativeHandle<JPH_Body> JPH_BodyInterface_UnassignBodyID(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            // TODO is CreateHandle correct? Does that create a duplicate pointer to the body?

            // return CreateHandle(Bindings.JPH_BodyInterface_UnassignBodyID(GetPointer(@interface), bodyID));

            throw new NotImplementedException();
        }

        public static void JPH_BodyInterface_AddBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, Activation activation)
        {
            Bindings.JPH_BodyInterface_AddBody(GetPointer(@interface), bodyID, activation);
        }

        public static void JPH_BodyInterface_RemoveBody(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            Bindings.JPH_BodyInterface_RemoveBody(GetPointer(@interface), bodyID);
        }

        public static bool JPH_BodyInterface_IsActive(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_IsActive(GetPointer(@interface), bodyID);
        }

        public static bool JPH_BodyInterface_IsAdded(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_IsAdded(GetPointer(@interface), bodyID);
        }

        public static bool JPH_BodyInterface_GetBodyType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_IsAdded(GetPointer(@interface), bodyID);
        }

        public static void JPH_BodyInterface_SetLinearVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float3 velocity)
        {
            Bindings.JPH_BodyInterface_SetLinearVelocity(GetPointer(@interface), bodyID, &velocity);
        }

        public static float3 JPH_BodyInterface_GetLinearVelocity(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            float3 result;

            Bindings.JPH_BodyInterface_GetLinearVelocity(GetPointer(@interface), bodyID, &result);

            return result;
        }

        public static rvec3 JPH_BodyInterface_GetCenterOfMassPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            rvec3 result;

            Bindings.JPH_BodyInterface_GetCenterOfMassPosition(GetPointer(@interface), bodyID, &result);

            return result;
        }

        public static MotionType JPH_BodyInterface_GetMotionType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_GetMotionType(GetPointer(@interface), bodyID);
        }

        public static void JPH_BodyInterface_SetMotionType(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, MotionType motion, Activation activation)
        {
            Bindings.JPH_BodyInterface_SetMotionType(GetPointer(@interface), bodyID, motion, activation);
        }

        public static float JPH_BodyInterface_GetRestitution(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_GetRestitution(GetPointer(@interface), bodyID);
        }

        public static void JPH_BodyInterface_SetRestitution(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float restitution)
        {
            Bindings.JPH_BodyInterface_SetRestitution(GetPointer(@interface), bodyID, restitution);
        }

        public static float JPH_BodyInterface_GetFriction(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            return Bindings.JPH_BodyInterface_GetFriction(GetPointer(@interface), bodyID);
        }

        public static void JPH_BodyInterface_SetFriction(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, float friction)
        {
            Bindings.JPH_BodyInterface_SetFriction(GetPointer(@interface), bodyID, friction);
        }

        public static void JPH_BodyInterface_SetPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, rvec3 position, Activation activation)
        {
            Bindings.JPH_BodyInterface_SetPosition(GetPointer(@interface), bodyID, &position, activation);
        }

        public static rvec3 JPH_BodyInterface_GetPosition(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            rvec3 result;

            Bindings.JPH_BodyInterface_GetPosition(GetPointer(@interface), bodyID, &result);

            return result;
        }

        public static void JPH_BodyInterface_SetRotation(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID, quaternion rotation, Activation activation)
        {
            Bindings.JPH_BodyInterface_SetRotation(GetPointer(@interface), bodyID, &rotation, activation);
        }

        public static quaternion JPH_BodyInterface_GetRotation(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            quaternion result;

            Bindings.JPH_BodyInterface_GetRotation(GetPointer(@interface), bodyID, &result);

            return result;
        }

        // TODO

        public static rmatrix4x4 JPH_BodyInterface_GetWorldTransform(NativeHandle<JPH_BodyInterface> @interface, BodyID bodyID)
        {
            rmatrix4x4 result;

            Bindings.JPH_BodyInterface_GetWorldTransform(GetPointer(@interface), bodyID, &result);

            return result;
        }

        // TODO

        #endregion

        #region JPH_BodyLockInterface

        // TODO

        #endregion

        #region JPH_MotionProperties

        // TODO

        #endregion

        #region JPH_NarrowPhaseQuery

        // TODO

        #endregion

        #region JPH_ShapeCastSettings

        // TODO

        #endregion

        #region JPH_AllHit

        // TODO

        #endregion

        #region JPH_Body

        public static BodyID JPH_Body_GetID(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetID(GetPointer(body));
        }

        public static BodyType JPH_Body_GetBodyType(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetBodyType(GetPointer(body));
        }

        public static AABox JPH_Body_GetWorldSpaceBounds(NativeHandle<JPH_Body> body)
        {
            AABox result;

            Bindings.JPH_Body_GetWorldSpaceBounds(GetPointer(body), &result);

            return result;
        }

        public static float3 JPH_Body_GetWorldSpaceSurfaceNormal(NativeHandle<JPH_Body> body, uint subShapeID, rvec3 position)
        {
            float3 result;

            Bindings.JPH_Body_GetWorldSpaceSurfaceNormal(GetPointer(body), subShapeID, &position, &result);

            return result;
        }

        public static bool JPH_Body_IsActive(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_IsActive(GetPointer(body));
        }

        public static bool JPH_Body_IsStatic(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_IsStatic(GetPointer(body));
        }

        public static bool JPH_Body_IsKinematic(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_IsKinematic(GetPointer(body));
        }

        public static bool JPH_Body_IsDynamic(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_IsDynamic(GetPointer(body));
        }

        public static bool JPH_Body_IsSensor(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_IsSensor(GetPointer(body));
        }

        public static void JPH_Body_SetIsSensor(NativeHandle<JPH_Body> body, bool value)
        {
            Bindings.JPH_Body_SetIsSensor(GetPointer(body), value);
        }

        public static void JPH_Body_SetCollideKinematicVsNonDynamic(NativeHandle<JPH_Body> body, bool value)
        {
            Bindings.JPH_Body_SetCollideKinematicVsNonDynamic(GetPointer(body), value);
        }

        public static bool JPH_Body_GetCollideKinematicVsNonDynamic(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetCollideKinematicVsNonDynamic(GetPointer(body));
        }

        public static void JPH_Body_SetUseManifoldReduction(NativeHandle<JPH_Body> body, bool value)
        {
            Bindings.JPH_Body_SetUseManifoldReduction(GetPointer(body), value);
        }

        public static bool JPH_Body_GetUseManifoldReduction(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetUseManifoldReduction(GetPointer(body));
        }

        public static bool JPH_Body_GetUseManifoldReductionWithBody(NativeHandle<JPH_Body> body, NativeHandle<JPH_Body> other)
        {
            return Bindings.JPH_Body_GetUseManifoldReductionWithBody(GetPointer(body), GetPointer(body));
        }

        public static void JPH_Body_SetApplyGyroscopicForce(NativeHandle<JPH_Body> body, bool value)
        {
            Bindings.JPH_Body_SetApplyGyroscopicForce(GetPointer(body), value);
        }

        public static bool JPH_Body_GetApplyGyroscopicForce(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetApplyGyroscopicForce(GetPointer(body));
        }

        public static NativeHandle<JPH_MotionProperties> JPH_Body_GetMotionProperties(NativeHandle<JPH_Body> body)
        {
            return CreateOwnedHandle(body, Bindings.JPH_Body_GetMotionProperties(GetPointer(body)));
        }

        public static MotionType JPH_Body_GetMotionType(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetMotionType(GetPointer(body));
        }

        public static void JPH_Body_SetMotionType(NativeHandle<JPH_Body> body, MotionType motion)
        {
            Bindings.JPH_Body_SetMotionType(GetPointer(body), motion);
        }

        public static bool JPH_Body_GetAllowSleeping(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetAllowSleeping(GetPointer(body));
        }

        public static void JPH_Body_SetAllowSleeping(NativeHandle<JPH_Body> body, bool allowSleeping)
        {
            Bindings.JPH_Body_SetAllowSleeping(GetPointer(body), allowSleeping);
        }

        public static void JPH_Body_ResetSleepTimer(NativeHandle<JPH_Body> body)
        {
            Bindings.JPH_Body_ResetSleepTimer(GetPointer(body));
        }

        public static float JPH_Body_GetFriction(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetFriction(GetPointer(body));
        }

        public static void JPH_Body_SetFriction(NativeHandle<JPH_Body> body, float friction)
        {
            Bindings.JPH_Body_SetFriction(GetPointer(body), friction);
        }

        public static float JPH_Body_GetRestitution(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetRestitution(GetPointer(body));
        }

        public static void JPH_Body_SetRestitution(NativeHandle<JPH_Body> body, float restitution)
        {
            Bindings.JPH_Body_SetRestitution(GetPointer(body), restitution);
        }

        public static float3 JPH_Body_GetLinearVelocity(NativeHandle<JPH_Body> body)
        {
            float3 result;

            Bindings.JPH_Body_GetLinearVelocity(GetPointer(body), &result);

            return result;
        }

        public static void JPH_Body_SetLinearVelocity(NativeHandle<JPH_Body> body, float3 velocity)
        {
            Bindings.JPH_Body_SetLinearVelocity(GetPointer(body), &velocity);
        }

        public static float3 JPH_Body_GetAngularVelocity(NativeHandle<JPH_Body> body)
        {
            float3 result;

            Bindings.JPH_Body_GetAngularVelocity(GetPointer(body), &result);

            return result;
        }

        public static void JPH_Body_SetAngularVelocity(NativeHandle<JPH_Body> body, float3 velocity)
        {
            Bindings.JPH_Body_SetAngularVelocity(GetPointer(body), &velocity);
        }

        public static void JPH_Body_AddForce(NativeHandle<JPH_Body> body, float3 force)
        {
            Bindings.JPH_Body_AddForce(GetPointer(body), &force);
        }

        public static void JPH_Body_AddForceAtPosition(NativeHandle<JPH_Body> body, float3 force, rvec3 position)
        {
            Bindings.JPH_Body_AddForceAtPosition(GetPointer(body), &force, &position);
        }

        public static void JPH_Body_AddTorque(NativeHandle<JPH_Body> body, float3 force)
        {
            Bindings.JPH_Body_AddTorque(GetPointer(body), &force);
        }

        public static float3 JPH_Body_GetAccumulatedForce(NativeHandle<JPH_Body> body)
        {
            float3 result;

            Bindings.JPH_Body_GetAccumulatedForce(GetPointer(body), &result);

            return result;
        }

        public static float3 JPH_Body_GetAccumulatedTorque(NativeHandle<JPH_Body> body)
        {
            float3 result;

            Bindings.JPH_Body_GetAccumulatedTorque(GetPointer(body), &result);

            return result;
        }

        public static void JPH_Body_AddImpulse(NativeHandle<JPH_Body> body, float3 impulse)
        {
            Bindings.JPH_Body_AddImpulse(GetPointer(body), &impulse);
        }

        public static void JPH_Body_AddImpulseAtPosition(NativeHandle<JPH_Body> body, float3 impulse, rvec3 position)
        {
            Bindings.JPH_Body_AddImpulseAtPosition(GetPointer(body), &impulse, &position);
        }

        public static void JPH_Body_AddAngularImpulse(NativeHandle<JPH_Body> body, float3 angularImpulse)
        {
            Bindings.JPH_Body_AddAngularImpulse(GetPointer(body), &angularImpulse);
        }

        public static rvec3 JPH_Body_GetPosition(NativeHandle<JPH_Body> body)
        {
            rvec3 result;

            Bindings.JPH_Body_GetPosition(GetPointer(body), &result);

            return result;
        }

        public static quaternion JPH_Body_GetRotation(NativeHandle<JPH_Body> body)
        {
            quaternion result;

            Bindings.JPH_Body_GetRotation(GetPointer(body), &result);

            return result;
        }

        public static rvec3 JPH_Body_GetCenterOfMassPosition(NativeHandle<JPH_Body> body)
        {
            rvec3 result;

            Bindings.JPH_Body_GetCenterOfMassPosition(GetPointer(body), &result);

            return result;
        }

        public static rmatrix4x4 JPH_Body_GetWorldTransform(NativeHandle<JPH_Body> body)
        {
            rmatrix4x4 result;

            Bindings.JPH_Body_GetWorldTransform(GetPointer(body), &result);

            return result;
        }

        public static rmatrix4x4 JPH_Body_GetCenterOfMassTransform(NativeHandle<JPH_Body> body)
        {
            rmatrix4x4 result;

            Bindings.JPH_Body_GetCenterOfMassTransform(GetPointer(body), &result);

            return result;
        }

        public static void JPH_Body_SetUserData(NativeHandle<JPH_Body> body, ulong userData)
        {
            Bindings.JPH_Body_SetUserData(GetPointer(body), userData);
        }

        public static ulong JPH_Body_GetUserData(NativeHandle<JPH_Body> body)
        {
            return Bindings.JPH_Body_GetUserData(GetPointer(body));
        }

        #endregion

        #region JPH_BroadPhaseLayerFilter

        // TODO

        #endregion

        #region JPH_ObjectLayerFilter

        // TODO

        #endregion

        #region JPH_BodyFilter

        // TODO

        #endregion

        #region JPH_ContactListener

        // JPH_ContactListener_SetProcs is used directly internally

        public static NativeHandle<JPH_ContactListener> JPH_ContactListener_Create()
        {
            return CreateHandle(Bindings.JPH_ContactListener_Create());
        }

        public static void JPH_ContactListener_Destroy(NativeHandle<JPH_ContactListener> listener)
        {
            Bindings.JPH_ContactListener_Destroy(GetPointer(listener));
            listener.Dispose();
        }

        #endregion

        #region JPH_BodyActivationListener

        // JPH_BodyActivationListener_SetProcs is used directly internally

        public static NativeHandle<JPH_BodyActivationListener> JPH_BodyActivationListener_Create()
        {
            return CreateHandle(Bindings.JPH_BodyActivationListener_Create());
        }

        public static void JPH_BodyActivationListener_Destroy(NativeHandle<JPH_BodyActivationListener> listener)
        {
            Bindings.JPH_BodyActivationListener_Destroy(GetPointer(listener));
            listener.Dispose();
        }

        #endregion

        #region JPH_CharacterBaseSettings

        // TODO

        #endregion

        #region JPH_CharacterBase

        // TODO

        #endregion

        #region JPH_CharacterVirtualSettings

        // TODO

        #endregion

        #region JPH_CharacterVirtual

        // TODO

        #endregion
    }
}
