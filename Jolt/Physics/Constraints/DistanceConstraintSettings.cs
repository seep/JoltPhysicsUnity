namespace Jolt
{
    [GenerateHandle("JPH_DistanceConstraintSettings"), GenerateBindings("JPH_ConstraintSettings"), GenerateBindings("JPH_DistanceConstraintSettings")]
    public readonly partial struct DistanceConstraintSettings
    {
        internal readonly NativeHandle<JPH_DistanceConstraintSettings> Handle;

        internal DistanceConstraintSettings(NativeHandle<JPH_DistanceConstraintSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_DistanceConstraintSettings_Create")]
        public static DistanceConstraintSettings Create()
        {
            return new DistanceConstraintSettings(Bindings.JPH_DistanceConstraintSettings_Create());
        }
    }
}
