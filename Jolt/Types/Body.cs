using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_Body")]
    public partial struct Body
    {
        internal NativeHandle<JPH_Body> Handle;

        public static Body GetFixedToWorldBody()
        {
            return new Body { Handle = JPH_Body_GetFixedToWorldBody() }; // TODO generate
        }
    }
}
