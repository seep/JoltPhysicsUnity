using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_TaperedCapsuleShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public partial struct TaperedCapsuleShapeSettings
    {
        internal NativeHandle<JPH_TaperedCapsuleShapeSettings> Handle;
        
        public static TaperedCapsuleShapeSettings Create(float halfHeightOfCylinder, float topRadius, float bottomRadius)
        {
            return new TaperedCapsuleShapeSettings { Handle = JPH_TaperedCapsuleShapeSettings_Create(halfHeightOfCylinder, topRadius, bottomRadius) };
        }
    }
}
