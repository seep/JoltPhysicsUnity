using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_CapsuleShape", "JPH_ConvexShape", "JPH_Shape")]
    public partial struct CapsuleShape
    {
        internal NativeHandle<JPH_CapsuleShape> Handle;
        
        public static CapsuleShape Create(float halfHeightOfCylinder, float radius)
        {
            return new CapsuleShape { Handle = JPH_CapsuleShape_Create(halfHeightOfCylinder, radius) };
        }
    }
}
