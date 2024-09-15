namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_SixDOFConstraintSettings> JPH_SixDOFConstraintSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_SixDOFConstraintSettings_Create());
        }

        public static NativeHandle<JPH_SixDOFConstraint> JPH_SixDOFConstraintSettings_CreateConstraint(NativeHandle<JPH_SixDOFConstraintSettings> settings, NativeHandle<JPH_Body> bodyA, NativeHandle<JPH_Body> bodyB)
        {
            return CreateHandle(UnsafeBindings.JPH_SixDOFConstraintSettings_CreateConstraint(settings, bodyA, bodyB));
        }
    }
}