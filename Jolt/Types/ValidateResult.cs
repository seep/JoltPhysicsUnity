namespace Jolt
{
    public enum ValidateResult : uint
    {
        AcceptAllContactsForThisBodyPair = 0,
        AcceptContact = 1,
        RejectContact = 2,
        RejectAllContactsForThisBodyPair = 3,
    }
}
