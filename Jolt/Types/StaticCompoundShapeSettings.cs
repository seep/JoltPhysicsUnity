using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_StaticCompoundShapeSettings", "JPH_CompoundShapeSettings", "JPH_ShapeSettings")]
    public partial struct StaticCompoundShapeSettings
    {
        internal NativeHandle<JPH_StaticCompoundShapeSettings> Handle;

        public static StaticCompoundShapeSettings Create()
        {
            return new StaticCompoundShapeSettings { Handle = JPH_StaticCompoundShapeSettings_Create() };
        }
    }
}
