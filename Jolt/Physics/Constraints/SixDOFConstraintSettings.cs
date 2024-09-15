namespace Jolt
{
    [GenerateHandle("JPH_SixDOFConstraintSettings"), GenerateBindings("JPH_SixDOFConstraintSettings", "JPH_TwoBodyConstraintSettings", "JPH_ConstraintSettings")]
    public readonly partial struct SixDOFConstraintSettings
    {
        [OverrideBinding("JPH_SixDOFConstraintSettings_Create")]
        public static SixDOFConstraintSettings Create()
        {
            return new SixDOFConstraintSettings(Bindings.JPH_SixDOFConstraintSettings_Create());
        }
    }
}