using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_ContactListener")]
    public partial struct ContactListener
    {
        internal NativeHandle<JPH_ContactListener> Handle;

        public static ContactListener Create(IContactListener delegates)
        {
            return new ContactListener { Handle = JPH_ContactListener_Create(delegates) };
        }
    }
}
