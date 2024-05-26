using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Jolt
{
    internal static unsafe partial class JoltAPI
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

        public static bool JPH_Init(uint tempAllocatorSize)
        {
            return Bindings.JPH_Init(tempAllocatorSize);
        }

        public static void JPH_Shutdown()
        {
            Bindings.JPH_Shutdown();
        }

        public static void JPH_SetAssertFailureHandler(AssertFailureHandler handler)
        {
            Bindings.JPH_SetAssertFailureHandler(Marshal.GetFunctionPointerForDelegate(handler));
        }

        internal delegate void AssertFailureHandler(string expr, string message, string file, uint line);
    }
}
