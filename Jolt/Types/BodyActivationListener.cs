using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_BodyActivationListener")]
    public partial struct BodyActivationListener
    {
        internal NativeHandle<JPH_BodyActivationListener> Handle;

        public static BodyActivationListener Create(IBodyActivationListener delegates)
        {
            return new BodyActivationListener { Handle = JPH_BodyActivationListener_Create(delegates) };
        }
    }
}
