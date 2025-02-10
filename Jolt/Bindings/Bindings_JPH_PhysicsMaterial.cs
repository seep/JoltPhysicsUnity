using System.Runtime.InteropServices;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_PhysicsMaterial> JPH_PhysicsMaterial_Create(string name, uint color)
        {
            nint nameptr = default;
            
            try
            {
                nameptr = Marshal.StringToHGlobalAnsi(name); // TODO look for a way to generate unsafe binding with marshalling attributes
                
                return CreateHandle(UnsafeBindings.JPH_PhysicsMaterial_Create((sbyte*)nameptr, color));
            }
            finally
            {
                Marshal.FreeHGlobal(nameptr);
            }
        }
        
        public static void JPH_PhysicsMaterial_Destroy(NativeHandle<JPH_PhysicsMaterial> material)
        {
            UnsafeBindings.JPH_PhysicsMaterial_Destroy(material);
            material.Dispose();
        }
    }
}