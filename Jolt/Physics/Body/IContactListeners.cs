namespace Jolt
{
    public interface IContactListener
    {
        public void OnContactValidate();
        public void OnContactAdded();
        public void OnContactPersisted();
        public void OnContactRemoved();
    }
}
