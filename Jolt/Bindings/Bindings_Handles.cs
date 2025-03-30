using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Jolt
{
    internal static unsafe partial class Bindings
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static NativeHandle<T> CreateHandle<T>(T* ptr) where T : unmanaged
        {
            return new NativeHandle<T>(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static NativeHandle<U> CreateOwnedHandle<T, U>(NativeHandle<T> owner, U* ptr) where T : unmanaged where U : unmanaged
        {
            return owner.CreateOwnedHandle(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T* GetOptionalPointer<T>(NativeHandle<T> handle) where T : unmanaged
        {
            // avoid disposed exception for pointer conversion of optional handles
            return handle.RawValue != 0 ? handle.IntoPointer() : null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static nint GetDelegatePointer(Delegate @delegate)
        {
            return Marshal.GetFunctionPointerForDelegate(@delegate);
        }
    }
}
