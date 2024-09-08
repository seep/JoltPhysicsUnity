using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_Body"), GenerateBindings("JPH_Body")]
    public readonly partial struct Body
    {
        [OverrideBinding("JPH_Body_GetFixedToWorldBody")]
        public static Body GetFixedToWorldBody()
        {
            return new Body(JPH_Body_GetFixedToWorldBody());
        }
    }
}
