namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_SwingTwistConstraintSettings> JPH_SwingTwistConstraintSettings_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_SwingTwistConstraintSettings_Create());
        }

        public static NativeHandle<JPH_SwingTwistConstraint> JPH_SwingTwistConstraintSettings_CreateConstraint(NativeHandle<JPH_SwingTwistConstraintSettings> settings, NativeHandle<JPH_Body> bodyA, NativeHandle<JPH_Body> bodyB)
        {
            return CreateHandle(UnsafeBindings.JPH_SwingTwistConstraintSettings_CreateConstraint(settings, bodyA, bodyB));
        }
    }
}