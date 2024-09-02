namespace Jolt
{
    [GenerateHandle("JPH_PointConstraintSettings"), GenerateBindings("JPH_ConstraintSettings"), GenerateBindings("JPH_FixedConstraintSettings")]
    public readonly partial struct PointConstraintSettings
    {
        internal readonly NativeHandle<JPH_PointConstraintSettings> Handle;

        internal PointConstraintSettings(NativeHandle<JPH_PointConstraintSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_PointConstraintSettings_Create")]
        public static PointConstraintSettings Create()
        {
            return new PointConstraintSettings(Bindings.JPH_PointConstraintSettings_Create());
        }
    }
}
