﻿namespace Jolt
{
    [GenerateHandle("JPH_FixedConstraintSettings"), GenerateBindings("JPH_FixedConstraintSettings"), GenerateBindings("JPH_ConstraintSettings")]
    public readonly partial struct FixedConstraintSettings
    {
        [OverrideBinding("JPH_FixedConstraintSettings_Create")]
        public static FixedConstraintSettings Create()
        {
            return new FixedConstraintSettings(Bindings.JPH_FixedConstraintSettings_Create());
        }
    }
}
