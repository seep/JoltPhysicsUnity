namespace Jolt
{
    [GenerateHandle("JPH_PointConstraintSettings"), GenerateBindings("JPH_PointConstraintSettings"), GenerateBindings("JPH_ConstraintSettings")]
    public readonly partial struct PointConstraintSettings
    {
        [OverrideBinding("JPH_PointConstraintSettings_Create")]
        public static PointConstraintSettings Create()
        {
            return new PointConstraintSettings(Bindings.JPH_PointConstraintSettings_Create());
        }
    }
}
