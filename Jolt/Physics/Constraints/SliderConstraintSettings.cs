namespace Jolt
{
    [GenerateHandle("JPH_SliderConstraintSettings"), GenerateBindings("JPH_SliderConstraintSettings", "JPH_TwoBodyConstraintSettings", "JPH_ConstraintSettings")]
    public readonly partial struct SliderConstraintSettings
    {
        [OverrideBinding("JPH_SliderConstraintSettings_Create")]
        public static SliderConstraintSettings Create()
        {
            return new SliderConstraintSettings(Bindings.JPH_SliderConstraintSettings_Create());
        }
    }
}
