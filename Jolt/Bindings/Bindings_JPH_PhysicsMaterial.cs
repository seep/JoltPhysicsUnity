namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_PhysicsMaterial> JPH_PhysicsMaterial_Create()
        {
            return CreateHandle(UnsafeBindings.JPH_PhysicsMaterial_Create());
        }
        
        public static void JPH_PhysicsMaterial_Destroy(NativeHandle<JPH_PhysicsMaterial> material)
        {
            UnsafeBindings.JPH_PhysicsMaterial_Destroy(material);
            
            material.Dispose();
        }
    }
}