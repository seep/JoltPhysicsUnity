namespace Jolt
{
    [GenerateHandle("JPH_FixedConstraintSettings"), GenerateBindings("JPH_ConstraintSettings"), GenerateBindings("JPH_FixedConstraintSettings")]
    public readonly partial struct FixedConstraintSettings
    {
        [OverrideBinding("JPH_FixedConstraintSettings_Create")]
        public static FixedConstraintSettings Create()
        {
            return new FixedConstraintSettings(Bindings.JPH_FixedConstraintSettings_Create());
        }
    }
}
