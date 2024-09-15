namespace Jolt
{
    [GenerateHandle("JPH_DistanceConstraintSettings"),  GenerateBindings("JPH_DistanceConstraintSettings", "JPH_TwoBodyConstraintSettings", "JPH_ConstraintSettings")]
    public readonly partial struct DistanceConstraintSettings
    {
        [OverrideBinding("JPH_DistanceConstraintSettings_Create")]
        public static DistanceConstraintSettings Create()
        {
            return new DistanceConstraintSettings(Bindings.JPH_DistanceConstraintSettings_Create());
        }
    }
}
