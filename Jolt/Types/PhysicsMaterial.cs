using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_PhysicsMaterial")]
    public partial struct PhysicsMaterial
    {
        internal NativeHandle<JPH_PhysicsMaterial> Handle;

        public static PhysicsMaterial Create(string name, Color color)
        {
            return new PhysicsMaterial { Handle = JPH_PhysicsMaterial_Create(name, color) };
        }
    }
}
