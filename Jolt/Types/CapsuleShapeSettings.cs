using System;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_CapsuleShapeSettings", "JPH_ConvexShapeSettings", "JPH_ShapeSettings")]
    public partial struct CapsuleShapeSettings
    {
        internal NativeHandle<JPH_CapsuleShapeSettings> Handle;
        
        public static CapsuleShapeSettings Create(float halfHeightOfCylinder, float radius)
        {
            return new CapsuleShapeSettings { Handle = JPH_CapsuleShapeSettings_Create(halfHeightOfCylinder, radius) };
        }
    }
}
