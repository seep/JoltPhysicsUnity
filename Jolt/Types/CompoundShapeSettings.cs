namespace Jolt
{
    /// <summary>
    /// A widened CompoundShapeSettings instance handle.
    /// </summary>
    [GenerateBindings("JPH_CompoundShapeSettings", "JPH_ShapeSettings")]
    public partial struct CompoundShapeSettings
    {
        internal NativeHandle<JPH_CompoundShapeSettings> Handle;
        
        public static implicit operator CompoundShapeSettings(MutableCompoundShapeSettings settings)
        {
            return new CompoundShapeSettings { Handle = settings.Handle.Reinterpret<JPH_CompoundShapeSettings>() };
        }

        public static implicit operator CompoundShapeSettings(StaticCompoundShapeSettings settings)
        {
            return new CompoundShapeSettings { Handle = settings.Handle.Reinterpret<JPH_CompoundShapeSettings>() };
        }
    }
}
