using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Jolt
{
    internal static class ManagedReference
    {
        private static readonly Dictionary<nint, GCHandle> lookup = new ();
        
        public static void Add<T>(NativeHandle<T> context, GCHandle handle) where T : unmanaged
        {
            lock (lookup)
            {
                lookup.Add(context.RawValue, handle);   
            }
        }
        
        public static bool Remove<T>(NativeHandle<T> context, out GCHandle handle) where T : unmanaged
        {
            lock (lookup)
            {
                return lookup.Remove(context.RawValue, out handle);   
            }
        }
        
        public static T Deref<T>(IntPtr ptr)
        {
            return (T)GCHandle.FromIntPtr(ptr).Target;
        }
    }
}
