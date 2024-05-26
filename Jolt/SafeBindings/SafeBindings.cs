using System.Runtime.CompilerServices;

namespace Jolt
{
    internal static unsafe partial class SafeBindings
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
        private static T* GetPointer<T>(NativeHandle<T> handle) where T : unmanaged
        {
            return handle.Unwrap();
        }
    }
}
