const std = @import("std");

const Build = std.build;

const Options = struct {
    enable_asserts: bool = false,
    enable_debug_renderer: bool = false,
    enable_cross_platform_determinism: bool = true,
    use_double_precision: bool = false,
};

pub fn compile(options: Options, b: *Build, lib: *Build.Step.Compile) void {
    lib.linkLibC();
    lib.linkLibCpp();

    lib.strip = lib.optimize != .Debug;

    const flags= &.{
       "-g",
       "-std=c++17",
       "-fdeclspec",
       "-DJPH_SHARED_LIBRARY_BUILD",
       if (options.use_double_precision) "-DJPH_DOUBLE_PRECISION" else "",
       if (options.enable_asserts or lib.optimize == .Debug) "-DJPH_ENABLE_ASSERTS" else "",
       if (options.enable_cross_platform_determinism) "-DJPH_CROSS_PLATFORM_DETERMINISTIC" else "",
       if (options.enable_debug_renderer) "-DJPH_DEBUG_RENDERER" else "",
    };

    // add joltc sources

    const joltc_dir = "lib/joltc/";

    lib.addIncludePath(.{
        .path = joltc_dir
    });

    lib.addCSourceFiles(&.{
        joltc_dir ++ "joltc.cpp",
        joltc_dir ++ "joltc_assert.cpp"
    }, flags);

    // add jolt sources

    const jolt_dir = "lib/jolt/";

    lib.addIncludePath(.{
        .path = jolt_dir
    });

    lib.addCSourceFiles(&.{
        jolt_dir ++ "Jolt/RegisterTypes.cpp",
        jolt_dir ++ "Jolt/AABBTree/AABBTreeBuilder.cpp",
        jolt_dir ++ "Jolt/Core/Color.cpp",
        jolt_dir ++ "Jolt/Core/Factory.cpp",
        jolt_dir ++ "Jolt/Core/IssueReporting.cpp",
        jolt_dir ++ "Jolt/Core/JobSystemSingleThreaded.cpp",
        jolt_dir ++ "Jolt/Core/JobSystemThreadPool.cpp",
        jolt_dir ++ "Jolt/Core/JobSystemWithBarrier.cpp",
        jolt_dir ++ "Jolt/Core/LinearCurve.cpp",
        jolt_dir ++ "Jolt/Core/Memory.cpp",
        jolt_dir ++ "Jolt/Core/Profiler.cpp",
        jolt_dir ++ "Jolt/Core/RTTI.cpp",
        jolt_dir ++ "Jolt/Core/Semaphore.cpp",
        jolt_dir ++ "Jolt/Core/StringTools.cpp",
        jolt_dir ++ "Jolt/Core/TickCounter.cpp",
        jolt_dir ++ "Jolt/Geometry/ConvexHullBuilder.cpp",
        jolt_dir ++ "Jolt/Geometry/ConvexHullBuilder2D.cpp",
        jolt_dir ++ "Jolt/Geometry/Indexify.cpp",
        jolt_dir ++ "Jolt/Geometry/OrientedBox.cpp",
        jolt_dir ++ "Jolt/Math/Vec3.cpp",
        jolt_dir ++ "Jolt/ObjectStream/ObjectStream.cpp",
        jolt_dir ++ "Jolt/ObjectStream/ObjectStreamBinaryIn.cpp",
        jolt_dir ++ "Jolt/ObjectStream/ObjectStreamBinaryOut.cpp",
        jolt_dir ++ "Jolt/ObjectStream/ObjectStreamIn.cpp",
        jolt_dir ++ "Jolt/ObjectStream/ObjectStreamOut.cpp",
        jolt_dir ++ "Jolt/ObjectStream/ObjectStreamTextIn.cpp",
        jolt_dir ++ "Jolt/ObjectStream/ObjectStreamTextOut.cpp",
        jolt_dir ++ "Jolt/ObjectStream/SerializableObject.cpp",
        jolt_dir ++ "Jolt/ObjectStream/TypeDeclarations.cpp",
        jolt_dir ++ "Jolt/Physics/DeterminismLog.cpp",
        jolt_dir ++ "Jolt/Physics/IslandBuilder.cpp",
        jolt_dir ++ "Jolt/Physics/LargeIslandSplitter.cpp",
        jolt_dir ++ "Jolt/Physics/PhysicsScene.cpp",
        jolt_dir ++ "Jolt/Physics/PhysicsSystem.cpp",
        jolt_dir ++ "Jolt/Physics/PhysicsUpdateContext.cpp",
        jolt_dir ++ "Jolt/Physics/StateRecorderImpl.cpp",
        jolt_dir ++ "Jolt/Physics/Body/Body.cpp",
        jolt_dir ++ "Jolt/Physics/Body/BodyCreationSettings.cpp",
        jolt_dir ++ "Jolt/Physics/Body/BodyInterface.cpp",
        jolt_dir ++ "Jolt/Physics/Body/BodyManager.cpp",
        jolt_dir ++ "Jolt/Physics/Body/MassProperties.cpp",
        jolt_dir ++ "Jolt/Physics/Body/MotionProperties.cpp",
        jolt_dir ++ "Jolt/Physics/Character/Character.cpp",
        jolt_dir ++ "Jolt/Physics/Character/CharacterBase.cpp",
        jolt_dir ++ "Jolt/Physics/Character/CharacterVirtual.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/CastConvexVsTriangles.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/CastSphereVsTriangles.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/CollideConvexVsTriangles.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/CollideSphereVsTriangles.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/CollisionDispatch.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/CollisionGroup.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/EstimateCollisionResponse.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/GroupFilter.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/GroupFilterTable.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/ManifoldBetweenTwoFaces.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/NarrowPhaseQuery.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/NarrowPhaseStats.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/PhysicsMaterial.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/PhysicsMaterialSimple.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/TransformedShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/BroadPhase/BroadPhase.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/BroadPhase/BroadPhaseBruteForce.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/BroadPhase/BroadPhaseQuadTree.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/BroadPhase/QuadTree.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/BoxShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/CapsuleShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/CompoundShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/ConvexHullShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/ConvexShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/CylinderShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/DecoratedShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/EmptyShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/HeightFieldShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/MeshShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/MutableCompoundShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/OffsetCenterOfMassShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/PlaneShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/RotatedTranslatedShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/ScaledShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/Shape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/SphereShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/StaticCompoundShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/TaperedCapsuleShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/TaperedCylinderShape.cpp",
        jolt_dir ++ "Jolt/Physics/Collision/Shape/TriangleShape.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/ConeConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/Constraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/ConstraintManager.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/ContactConstraintManager.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/DistanceConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/FixedConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/GearConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/HingeConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/MotorSettings.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/PathConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/PathConstraintPath.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/PathConstraintPathHermite.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/PointConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/PulleyConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/RackAndPinionConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/SixDOFConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/SliderConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/SpringSettings.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/SwingTwistConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Constraints/TwoBodyConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Ragdoll/Ragdoll.cpp",
        jolt_dir ++ "Jolt/Physics/SoftBody/SoftBodyCreationSettings.cpp",
        jolt_dir ++ "Jolt/Physics/SoftBody/SoftBodyMotionProperties.cpp",
        jolt_dir ++ "Jolt/Physics/SoftBody/SoftBodyShape.cpp",
        jolt_dir ++ "Jolt/Physics/SoftBody/SoftBodySharedSettings.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/MotorcycleController.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/TrackedVehicleController.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/VehicleAntiRollBar.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/VehicleCollisionTester.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/VehicleConstraint.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/VehicleController.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/VehicleDifferential.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/VehicleEngine.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/VehicleTrack.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/VehicleTransmission.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/Wheel.cpp",
        jolt_dir ++ "Jolt/Physics/Vehicle/WheeledVehicleController.cpp",
        jolt_dir ++ "Jolt/Renderer/DebugRenderer.cpp",
        jolt_dir ++ "Jolt/Renderer/DebugRendererPlayback.cpp",
        jolt_dir ++ "Jolt/Renderer/DebugRendererRecorder.cpp",
        jolt_dir ++ "Jolt/Renderer/DebugRendererSimple.cpp",
        jolt_dir ++ "Jolt/Skeleton/SkeletalAnimation.cpp",
        jolt_dir ++ "Jolt/Skeleton/Skeleton.cpp",
        jolt_dir ++ "Jolt/Skeleton/SkeletonMapper.cpp",
        jolt_dir ++ "Jolt/Skeleton/SkeletonPose.cpp",
        jolt_dir ++ "Jolt/TriangleSplitter/TriangleSplitter.cpp",
        jolt_dir ++ "Jolt/TriangleSplitter/TriangleSplitterBinning.cpp",
        jolt_dir ++ "Jolt/TriangleSplitter/TriangleSplitterMean.cpp",
    }, flags);

    b.installArtifact(lib);
}

pub fn build(b: *Build) void {
    const target = b.standardTargetOptions(.{});
    const optimize = b.standardOptimizeOption(.{});

    const options = Options {
        .use_double_precision = b.option(bool, "use_double_precision", "use double precision") orelse false,
        .enable_asserts = b.option(bool, "enable_asserts", "enable asserts") orelse false,
        .enable_debug_renderer = b.option(bool, "enable_debug_renderer", "enable debug renderer") orelse false,
        .enable_cross_platform_determinism = b.option(bool, "enable_cross_platform_determinism", "enable cross platform determinism") orelse false,
    };

    compile(options, b, b.addSharedLibrary(.{ .name = "joltc", .target = target, .optimize = optimize }));
    compile(options, b, b.addStaticLibrary(.{ .name = "joltc", .target = target, .optimize = optimize }));
}
