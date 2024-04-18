namespace Jolt
{
    public interface IContactListener
    {
        public ValidateResult OnContactValidate();

        public void OnContactAdded();
        public void OnContactPersisted();
        public void OnContactRemoved();
    }
}
