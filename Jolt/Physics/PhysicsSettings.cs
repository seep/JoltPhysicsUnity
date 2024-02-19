namespace Jolt
{
    public class PhysicsSettings
    {
        public const float DefaultConvexRadius = 0.05f;

        public const float DefaultCollisionTolerance = 1.0e-4f;

        public const float DefaultPenetrationTolerance = 1.0e-4f; ///< Stop when there's less than 1% change

        public const float CapsuleProjectionSlop = 0.02f;

        public const int MaxPhysicsJobs = 2048;

        public const int MaxPhysicsBarriers = 8;
    }
}
