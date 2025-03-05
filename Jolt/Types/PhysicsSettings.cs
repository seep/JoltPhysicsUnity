using System.Runtime.InteropServices;

namespace Jolt
{
    [ExpectedStructSize(typeof(JPH_PhysicsSettings))]
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicsSettings
    {
        public const float DefaultConvexRadius = 0.05f;

        public int MaxInFlightBodyPairs;

        public int StepListenersBatchSize;

        public int StepListenerBatchesPerJob;

        public float Baumgarte;

        public float SpeculativeContactDistance;

        public float PenetrationSlop;

        public float LinearCastThreshold;

        public float LinearCastMaxPenetration;

        public float ManifoldTolerance;

        public float MaxPenetrationDistance;

        public float BodyPairCacheMaxDeltaPositionSq;

        public float BodyPairCacheCosMaxDeltaRotationDiv2;

        public float ContactNormalCosMaxDeltaRotation;

        public float ContactPointPreserveLambdaMaxDistSq;

        public uint NumVelocitySteps;

        public uint NumPositionSteps;

        public float MinVelocityForRestitution;

        public float TimeBeforeSleep;

        public float PointVelocitySleepThreshold;

        public NativeBool DeterministicSimulation;

        public NativeBool ConstraintWarmStart;

        public NativeBool UseBodyPairContactCache;

        public NativeBool UseManifoldReduction;

        public NativeBool UseLargeIslandSplitter;

        public NativeBool AllowSleeping;

        public NativeBool CheckActiveEdges;
    }
}
