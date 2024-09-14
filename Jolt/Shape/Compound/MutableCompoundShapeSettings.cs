using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_MutableCompoundShapeSettings"), GenerateBindings("JPH_MutableCompoundShapeSettings", "JPH_CompoundShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct MutableCompoundShapeSettings
    {
        [OverrideBinding("JPH_MutableCompoundShapeSettings_Create")]
        public static MutableCompoundShapeSettings Create()
        {
            return new MutableCompoundShapeSettings(JPH_MutableCompoundShapeSettings_Create());
        }
    }
}
