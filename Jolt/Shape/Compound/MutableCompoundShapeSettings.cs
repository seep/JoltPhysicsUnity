using Unity.Mathematics;
using static Jolt.SafeBindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_CompoundShapeSettings"), GenerateBindings("JPH_MutableCompoundShapeSettings")]
    public readonly partial struct MutableCompoundShapeSettings : IShapeSettings
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
            JPH_CompoundShapeSettings_AddShape(Handle, position, rotation, shape.Handle, userData);
        }

        [OverrideBinding("JPH_CompoundShapeSettings_AddShape2")]
        public void AddShape(float3 position, quaternion rotation, Shape shape, uint userData)
        {
            JPH_CompoundShapeSettings_AddShape2(Handle, position, rotation, shape.Handle, userData);
        }
    }
}
