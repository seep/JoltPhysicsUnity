const std = @import("std");

const Build = std.Build;

const Options = struct {
    enable_asserts: bool = false,
    enable_debug_renderer: bool = false,
    enable_cross_platform_determinism: bool = true,
    use_double_precision: bool = false,
};

const flags= [_][]const u8 {
   "-g",
   "-std=c++17",
   "-fdeclspec",
};

const files = [_][]const u8 {

    "joltc/joltc.cpp",
    "joltc/joltc_assert.cpp",

    "jolt/Jolt/RegisterTypes.cpp",
    "jolt/Jolt/AABBTree/AABBTreeBuilder.cpp",
    "jolt/Jolt/Core/Color.cpp",
    "jolt/Jolt/Core/Factory.cpp",
    "jolt/Jolt/Core/IssueReporting.cpp",
    "jolt/Jolt/Core/JobSystemSingleThreaded.cpp",
    "jolt/Jolt/Core/JobSystemThreadPool.cpp",
    "jolt/Jolt/Core/JobSystemWithBarrier.cpp",
    "jolt/Jolt/Core/LinearCurve.cpp",
    "jolt/Jolt/Core/Memory.cpp",
    "jolt/Jolt/Core/Profiler.cpp",
    "jolt/Jolt/Core/RTTI.cpp",
    "jolt/Jolt/Core/Semaphore.cpp",
    "jolt/Jolt/Core/StringTools.cpp",
    "jolt/Jolt/Core/TickCounter.cpp",
    "jolt/Jolt/Geometry/ConvexHullBuilder.cpp",
    "jolt/Jolt/Geometry/ConvexHullBuilder2D.cpp",
    "jolt/Jolt/Geometry/Indexify.cpp",
    "jolt/Jolt/Geometry/OrientedBox.cpp",
    "jolt/Jolt/Math/Vec3.cpp",
    "jolt/Jolt/ObjectStream/ObjectStream.cpp",
    "jolt/Jolt/ObjectStream/ObjectStreamBinaryIn.cpp",
    "jolt/Jolt/ObjectStream/ObjectStreamBinaryOut.cpp",
    "jolt/Jolt/ObjectStream/ObjectStreamIn.cpp",
    "jolt/Jolt/ObjectStream/ObjectStreamOut.cpp",
    "jolt/Jolt/ObjectStream/ObjectStreamTextIn.cpp",
    "jolt/Jolt/ObjectStream/ObjectStreamTextOut.cpp",
    "jolt/Jolt/ObjectStream/SerializableObject.cpp",
    "jolt/Jolt/ObjectStream/TypeDeclarations.cpp",
    "jolt/Jolt/Physics/DeterminismLog.cpp",
    "jolt/Jolt/Physics/IslandBuilder.cpp",
    "jolt/Jolt/Physics/LargeIslandSplitter.cpp",
    "jolt/Jolt/Physics/PhysicsScene.cpp",
    "jolt/Jolt/Physics/PhysicsSystem.cpp",
    "jolt/Jolt/Physics/PhysicsUpdateContext.cpp",
    "jolt/Jolt/Physics/StateRecorderImpl.cpp",
    "jolt/Jolt/Physics/Body/Body.cpp",
    "jolt/Jolt/Physics/Body/BodyCreationSettings.cpp",
    "jolt/Jolt/Physics/Body/BodyInterface.cpp",
    "jolt/Jolt/Physics/Body/BodyManager.cpp",
    "jolt/Jolt/Physics/Body/MassProperties.cpp",
    "jolt/Jolt/Physics/Body/MotionProperties.cpp",
    "jolt/Jolt/Physics/Character/Character.cpp",
    "jolt/Jolt/Physics/Character/CharacterBase.cpp",
    "jolt/Jolt/Physics/Character/CharacterVirtual.cpp",
    "jolt/Jolt/Physics/Collision/CastConvexVsTriangles.cpp",
    "jolt/Jolt/Physics/Collision/CastSphereVsTriangles.cpp",
    "jolt/Jolt/Physics/Collision/CollideConvexVsTriangles.cpp",
    "jolt/Jolt/Physics/Collision/CollideSphereVsTriangles.cpp",
    "jolt/Jolt/Physics/Collision/CollisionDispatch.cpp",
    "jolt/Jolt/Physics/Collision/CollisionGroup.cpp",
    "jolt/Jolt/Physics/Collision/EstimateCollisionResponse.cpp",
    "jolt/Jolt/Physics/Collision/GroupFilter.cpp",
    "jolt/Jolt/Physics/Collision/GroupFilterTable.cpp",
    "jolt/Jolt/Physics/Collision/ManifoldBetweenTwoFaces.cpp",
    "jolt/Jolt/Physics/Collision/NarrowPhaseQuery.cpp",
    "jolt/Jolt/Physics/Collision/NarrowPhaseStats.cpp",
    "jolt/Jolt/Physics/Collision/PhysicsMaterial.cpp",
    "jolt/Jolt/Physics/Collision/PhysicsMaterialSimple.cpp",
    "jolt/Jolt/Physics/Collision/TransformedShape.cpp",
    "jolt/Jolt/Physics/Collision/BroadPhase/BroadPhase.cpp",
    "jolt/Jolt/Physics/Collision/BroadPhase/BroadPhaseBruteForce.cpp",
    "jolt/Jolt/Physics/Collision/BroadPhase/BroadPhaseQuadTree.cpp",
    "jolt/Jolt/Physics/Collision/BroadPhase/QuadTree.cpp",
    "jolt/Jolt/Physics/Collision/Shape/BoxShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/CapsuleShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/CompoundShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/ConvexHullShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/ConvexShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/CylinderShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/DecoratedShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/EmptyShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/HeightFieldShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/MeshShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/MutableCompoundShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/OffsetCenterOfMassShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/PlaneShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/RotatedTranslatedShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/ScaledShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/Shape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/SphereShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/StaticCompoundShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/TaperedCapsuleShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/TaperedCylinderShape.cpp",
    "jolt/Jolt/Physics/Collision/Shape/TriangleShape.cpp",
    "jolt/Jolt/Physics/Constraints/ConeConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/Constraint.cpp",
    "jolt/Jolt/Physics/Constraints/ConstraintManager.cpp",
    "jolt/Jolt/Physics/Constraints/ContactConstraintManager.cpp",
    "jolt/Jolt/Physics/Constraints/DistanceConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/FixedConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/GearConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/HingeConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/MotorSettings.cpp",
    "jolt/Jolt/Physics/Constraints/PathConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/PathConstraintPath.cpp",
    "jolt/Jolt/Physics/Constraints/PathConstraintPathHermite.cpp",
    "jolt/Jolt/Physics/Constraints/PointConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/PulleyConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/RackAndPinionConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/SixDOFConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/SliderConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/SpringSettings.cpp",
    "jolt/Jolt/Physics/Constraints/SwingTwistConstraint.cpp",
    "jolt/Jolt/Physics/Constraints/TwoBodyConstraint.cpp",
    "jolt/Jolt/Physics/Ragdoll/Ragdoll.cpp",
    "jolt/Jolt/Physics/SoftBody/SoftBodyCreationSettings.cpp",
    "jolt/Jolt/Physics/SoftBody/SoftBodyMotionProperties.cpp",
    "jolt/Jolt/Physics/SoftBody/SoftBodyShape.cpp",
    "jolt/Jolt/Physics/SoftBody/SoftBodySharedSettings.cpp",
    "jolt/Jolt/Physics/Vehicle/MotorcycleController.cpp",
    "jolt/Jolt/Physics/Vehicle/TrackedVehicleController.cpp",
    "jolt/Jolt/Physics/Vehicle/VehicleAntiRollBar.cpp",
    "jolt/Jolt/Physics/Vehicle/VehicleCollisionTester.cpp",
    "jolt/Jolt/Physics/Vehicle/VehicleConstraint.cpp",
    "jolt/Jolt/Physics/Vehicle/VehicleController.cpp",
    "jolt/Jolt/Physics/Vehicle/VehicleDifferential.cpp",
    "jolt/Jolt/Physics/Vehicle/VehicleEngine.cpp",
    "jolt/Jolt/Physics/Vehicle/VehicleTrack.cpp",
    "jolt/Jolt/Physics/Vehicle/VehicleTransmission.cpp",
    "jolt/Jolt/Physics/Vehicle/Wheel.cpp",
    "jolt/Jolt/Physics/Vehicle/WheeledVehicleController.cpp",
    "jolt/Jolt/Renderer/DebugRenderer.cpp",
    "jolt/Jolt/Renderer/DebugRendererPlayback.cpp",
    "jolt/Jolt/Renderer/DebugRendererRecorder.cpp",
    "jolt/Jolt/Renderer/DebugRendererSimple.cpp",
    "jolt/Jolt/Skeleton/SkeletalAnimation.cpp",
    "jolt/Jolt/Skeleton/Skeleton.cpp",
    "jolt/Jolt/Skeleton/SkeletonMapper.cpp",
    "jolt/Jolt/Skeleton/SkeletonPose.cpp",
    "jolt/Jolt/TriangleSplitter/TriangleSplitter.cpp",
    "jolt/Jolt/TriangleSplitter/TriangleSplitterBinning.cpp",
    "jolt/Jolt/TriangleSplitter/TriangleSplitterMean.cpp",
};

fn defineCMacro(lib: *Build.Step.Compile, name: []const u8) void {
  lib.root_module.addCMacro(name, "1");
}

pub fn compile(options: Options, b: *Build, lib: *Build.Step.Compile) void {
    defineCMacro(lib, "JPH_SHARED_LIBRARY_BUILD");

    if (options.use_double_precision) {
        defineCMacro(lib, "JPH_DOUBLE_PRECISION");
    }

    if (options.enable_asserts) {
        defineCMacro(lib, "JPH_ENABLE_ASSERTS");
    }

    if (options.enable_cross_platform_determinism) {
        defineCMacro(lib, "JPH_CROSS_PLATFORM_DETERMINISTIC");
    }

    if (options.enable_debug_renderer) {
        defineCMacro(lib, "JPH_DEBUG_RENDERER");
    }

    lib.addIncludePath(b.path("lib/jolt"));
    lib.addIncludePath(b.path("lib/joltc"));

    lib.addCSourceFiles(.{
        .root = b.path("lib"),
        .files = &files,
        .flags = &flags,
    });

    b.installArtifact(lib);
}

pub fn build(b: *Build) void {
    const target = b.standardTargetOptions(.{});
    const optimize = b.standardOptimizeOption(.{});

    const options = Options {
        .use_double_precision = b.option(bool, "use_double_precision", "use double precision") orelse false,
        .enable_asserts = b.option(bool, "enable_asserts", "enable asserts") orelse (optimize == .Debug),
        .enable_debug_renderer = b.option(bool, "enable_debug_renderer", "enable debug renderer") orelse false,
        .enable_cross_platform_determinism = b.option(bool, "enable_cross_platform_determinism", "enable cross platform determinism") orelse false,
    };

    const name = if (options.use_double_precision) "joltc_double" else "joltc";
    const strip = (optimize != .Debug);

    const module = b.createModule(.{
        .strip = strip,
        .target = target,
        .optimize = optimize,
        .link_libc = true,
        .link_libcpp = true,
    });

    compile(options, b, b.addLibrary(.{ .name = name, .root_module = module, .linkage = .dynamic })); // TODO add optional static linking
}