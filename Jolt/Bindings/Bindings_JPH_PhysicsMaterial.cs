using System;
using System.Runtime.InteropServices;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        public static NativeHandle<JPH_PhysicsMaterial> JPH_PhysicsMaterial_Create(string name, uint color)
        {
            AssertInitialized();

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
            AssertInitialized();

            UnsafeBindings.JPH_PhysicsMaterial_Destroy(material);
            material.Dispose();
        }

        public static string JPH_PhysicsMaterial_GetDebugName(NativeHandle<JPH_PhysicsMaterial> material)
        {
            AssertInitialized();

            throw new NotImplementedException(); // TODO marshal sbyte* pointer into string
        }

        public static uint JPH_PhysicsMaterial_GetDebugColor(NativeHandle<JPH_PhysicsMaterial> material)
        {
            AssertInitialized();

            return UnsafeBindings.JPH_PhysicsMaterial_GetDebugColor(material);
        }
    }
}
