using System;
using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_ConvexShapeSettings"), GenerateBindings("JPH_TaperedCapsuleShapeSettings")]
    public readonly partial struct TaperedCapsuleShapeSettings : IConvexShapeSettings
    {
        internal readonly NativeHandle<JPH_TaperedCapsuleShapeSettings> Handle;

        internal TaperedCapsuleShapeSettings(NativeHandle<JPH_TaperedCapsuleShapeSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_TaperedCapsuleShapeSettings_Create")]
        public static TaperedCapsuleShapeSettings Create(float halfHeightOfCylinder, float topRadius, float bottomRadius)
        {
            return new TaperedCapsuleShapeSettings(JPH_TaperedCapsuleShapeSettings_Create(halfHeightOfCylinder, topRadius, bottomRadius));
        }

        [OverrideBinding("JPH_TaperedCapsuleShapeSettings_CreateShape")]
        public TaperedCapsuleShape CreateShape()
        {
            throw new NotImplementedException(); // TODO JPH_TaperedCapsuleShapeSettings_CreateShape is missing from bindings?
        }
    }
}
