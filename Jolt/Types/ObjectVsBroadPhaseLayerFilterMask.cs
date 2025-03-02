using static Jolt.Bindings;

namespace Jolt
{
    public partial struct ObjectVsBroadPhaseLayerFilterMask
    {
        internal NativeHandle<JPH_ObjectVsBroadPhaseLayerFilter> Handle;
        
        public static ObjectVsBroadPhaseLayerFilterMask Create(BroadPhaseLayerInterface @interface)
        {
            return new ObjectVsBroadPhaseLayerFilterMask { Handle = JPH_ObjectVsBroadPhaseLayerFilterMask_Create(@interface.Handle) };
        }
    }
}
