namespace Jolt
{
    public enum PhysicsUpdateError : uint
    {
        None = 0,
        ManifoldCacheFull = 1 << 0,
        BodyPairCacheFull = 1 << 1,
        ContactConstraintsFull = 1 << 2,
    }
}
