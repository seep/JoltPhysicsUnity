using Unity.Mathematics;
using static Jolt.Bindings;

namespace Jolt
{
    [GenerateHandle, GenerateBindings("JPH_ShapeSettings"), GenerateBindings("JPH_CompoundShapeSettings"), GenerateBindings("JPH_StaticCompoundShapeSettings")]
    public readonly partial struct StaticCompoundShapeSettings : IShapeSettings
    {
        internal readonly NativeHandle<JPH_StaticCompoundShapeSettings> Handle;

        internal StaticCompoundShapeSettings(NativeHandle<JPH_StaticCompoundShapeSettings> handle)
        {
            Handle = handle;
        }

        [OverrideBinding("JPH_StaticCompoundShapeSettings_Create")]
        public static StaticCompoundShapeSettings Create()
        {
            return new StaticCompoundShapeSettings(JPH_StaticCompoundShapeSettings_Create());
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
