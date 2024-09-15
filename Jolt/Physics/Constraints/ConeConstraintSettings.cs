namespace Jolt
{
    [GenerateHandle("JPH_ConeConstraintSettings"), GenerateBindings("JPH_ConeConstraintSettings", "JPH_TwoBodyConstraintSettings", "JPH_ConstraintSettings")]
    public readonly partial struct ConeConstraintSettings
    {
        [OverrideBinding("JPH_ConeConstraintSettings_Create")]
        public static ConeConstraintSettings Create()
        {
            return new ConeConstraintSettings(Bindings.JPH_ConeConstraintSettings_Create());
        }
    }
}