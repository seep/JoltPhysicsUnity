using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    /// <summary>
    /// A widened CompoundShapeSettings instance handle.
    /// </summary>
    [GenerateHandle("JPH_CompoundShapeSettings"), GenerateBindings("JPH_CompoundShapeSettings", "JPH_ShapeSettings")]
    public readonly partial struct CompoundShapeSettings
    {
        public static implicit operator CompoundShapeSettings(MutableCompoundShapeSettings settings)
        {
            return new CompoundShapeSettings(settings.Handle.Reinterpret<JPH_CompoundShapeSettings>());
        }

        public static implicit operator CompoundShapeSettings(StaticCompoundShapeSettings settings)
        {
            return new CompoundShapeSettings(settings.Handle.Reinterpret<JPH_CompoundShapeSettings>());
        }
    }
}
