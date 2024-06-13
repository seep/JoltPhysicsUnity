using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle("JPH_MutableCompoundShapeSettings"), GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_CompoundShapeSettings"), GenerateBindings("JPH_MutableCompoundShapeSettings")]
    public readonly partial struct MutableCompoundShapeSettings
    {
        internal readonly NativeHandle<JPH_MutableCompoundShapeSettings> Handle;

        internal MutableCompoundShapeSettings(NativeHandle<JPH_MutableCompoundShapeSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_MutableCompoundShapeSettings_Create")]
        public static MutableCompoundShapeSettings Create()
        {
            return new MutableCompoundShapeSettings(JPH_MutableCompoundShapeSettings_Create());
        }

        [OverrideBinding("JPH_CompoundShapeSettings_AddShape")]
        public void AddShape(float3 position, quaternion rotation, ShapeSettings shape, uint userData = 0)
        {
            JPH_CompoundShapeSettings_AddShape(Handle.Reinterpret<JPH_CompoundShapeSettings>(), position, rotation, shape.Handle, userData);
        }

        [OverrideBinding("JPH_CompoundShapeSettings_AddShape2")]
        public void AddShape(float3 position, quaternion rotation, Shape shape, uint userData)
        {
            JPH_CompoundShapeSettings_AddShape2(Handle.Reinterpret<JPH_CompoundShapeSettings>(), position, rotation, shape.Handle, userData);
        }
    }
}
