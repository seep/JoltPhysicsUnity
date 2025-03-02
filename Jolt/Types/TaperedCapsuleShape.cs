namespace Jolt
{
    [GenerateBindings("JPH_TaperedCapsuleShape", "JPH_ConvexShape", "JPH_Shape")]
    public partial struct TaperedCapsuleShape
    {
        internal NativeHandle<JPH_TaperedCapsuleShape> Handle;

        // TODO no JPH_TaperedCapsuleShape_Create binding?
    }
}
