namespace Jolt
{
    [GenerateHandle("JPH_HingeConstraintSettings"), GenerateBindings("JPH_HingeConstraintSettings", "JPH_TwoBodyConstraintSettings", "JPH_ConstraintSettings")]
    public readonly partial struct HingeConstraintSettings
    {
        [OverrideBinding("JPH_HingeConstraintSettings_Create")]
        public static HingeConstraintSettings Create()
        {
            return new HingeConstraintSettings(Bindings.JPH_HingeConstraintSettings_Create());
        }
    }
}
