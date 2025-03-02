namespace Jolt
{
    public interface IBodyActivationListener
    {
        public void OnBodyActivated(BodyID bodyID, ulong bodyUserData);

        public void OnBodyDeactivated(BodyID bodyID, ulong bodyUserData);
    }
}
