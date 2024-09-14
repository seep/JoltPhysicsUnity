using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_StaticCompoundShapeSettings"), GenerateBindings("JPH_StaticCompoundShapeSettings", "JPH_CompoundShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct StaticCompoundShapeSettings
    {
        [OverrideBinding("JPH_StaticCompoundShapeSettings_Create")]
        public static StaticCompoundShapeSettings Create()
        {
            return new StaticCompoundShapeSettings(JPH_StaticCompoundShapeSettings_Create());
        }
    }
}
