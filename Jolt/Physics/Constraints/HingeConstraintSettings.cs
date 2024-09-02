namespace Jolt
{
    [GenerateHandle("JPH_HingeConstraintSettings"), GenerateBindings("JPH_ConstraintSettings"), GenerateBindings("JPH_HingeConstraintSettings")]
    public readonly partial struct HingeConstraintSettings
    {
        internal readonly NativeHandle<JPH_HingeConstraintSettings> Handle;

        internal HingeConstraintSettings(NativeHandle<JPH_HingeConstraintSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_HingeConstraintSettings_Create")]
        public static HingeConstraintSettings Create()
        {
            return new HingeConstraintSettings(Bindings.JPH_HingeConstraintSettings_Create());
        }
    }
}
