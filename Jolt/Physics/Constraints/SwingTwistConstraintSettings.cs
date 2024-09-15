namespace Jolt
{
    [GenerateHandle("JPH_SwingTwistConstraintSettings"), GenerateBindings("JPH_SwingTwistConstraintSettings", "JPH_TwoBodyConstraintSettings", "JPH_ConstraintSettings")]
    public readonly partial struct SwingTwistConstraintSettings
    {
        [OverrideBinding("JPH_SwingTwistConstraintSettings_Create")]
        public static SwingTwistConstraintSettings Create()
        {
            return new SwingTwistConstraintSettings(Bindings.JPH_SwingTwistConstraintSettings_Create());
        }
    }
}