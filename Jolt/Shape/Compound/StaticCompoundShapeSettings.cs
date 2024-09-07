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
