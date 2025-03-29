using static Jolt.Bindings;

namespace Jolt
{
    [GenerateBindings("JPH_PhysicsMaterial")]
    public partial struct PhysicsMaterial
    {
        internal NativeHandle<JPH_PhysicsMaterial> Handle;

        /// <summary>
        /// Create a new PhysicsMaterial.
        /// </summary>
        /// <remarks>
        /// The "color" of the material is named to maintain compatibility with Jolt, but it can be used for any
        /// material information that would be useful for the simulation output. It could be used to select the
        /// sound effect produced by a collision, for example. Use it for arbitrary surface data.
        /// </remarks>
        public static PhysicsMaterial Create(string name, uint color)
        {
            return new PhysicsMaterial { Handle = JPH_PhysicsMaterial_Create(name, color) };
        }
    }
}
