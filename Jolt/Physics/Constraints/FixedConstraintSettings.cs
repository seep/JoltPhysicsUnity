namespace Jolt
{
    [GenerateHandle("JPH_FixedConstraintSettings"), GenerateBindings("JPH_ConstraintSettings"), GenerateBindings("JPH_FixedConstraintSettings")]
    public readonly partial struct FixedConstraintSettings
    {
        internal readonly NativeHandle<JPH_FixedConstraintSettings> Handle;

        internal FixedConstraintSettings(NativeHandle<JPH_FixedConstraintSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_FixedConstraintSettings_Create")]
        public FixedConstraintSettings Create()
        {
            return new FixedConstraintSettings(Bindings.JPH_FixedConstraintSettings_Create());
        }
    }
}
