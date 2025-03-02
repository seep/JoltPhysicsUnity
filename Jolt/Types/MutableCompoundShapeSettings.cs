using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_MutableCompoundShapeSettings", "JPH_CompoundShapeSettings", "JPH_ShapeSettings")]
    public partial struct MutableCompoundShapeSettings
    {
        internal NativeHandle<JPH_MutableCompoundShapeSettings> Handle;

        public static MutableCompoundShapeSettings Create()
        {
            return new MutableCompoundShapeSettings { Handle = JPH_MutableCompoundShapeSettings_Create() };
        }
    }
}
