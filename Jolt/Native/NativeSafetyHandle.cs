using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Jolt
{
    /// <summary>
    /// A safety handle for detecting use-after-free access of native objects.
    /// </summary>
    public struct NativeSafetyHandle
    {
        // Initially I tried to reuse AtomicSafetyHandle to offload complexity out of the lib, but
        // AtomicSafetyHandle is tightly coupled to the ENABLE_UNITY_COLLECTIONS_CHECKS scripting
        // define, and ideally the Jolt safety checks can be enabled independently.

        public uint Index;

        private static uint nextHandleIndex;

        private static NativeHashSet<uint> disposed;

        static NativeSafetyHandle()
        {
            disposed = new NativeHashSet<uint>(1024, Allocator.Persistent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NativeSafetyHandle Create()
        {
            return new NativeSafetyHandle { Index = nextHandleIndex++ };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Release(in NativeSafetyHandle handle)
        {
            disposed.Add(handle.Index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AssertExists(in NativeSafetyHandle handle)
        {
            // TODO handle threading

            if (disposed.Contains(handle.Index))
            {
                throw new ObjectDisposedException("The native resource has been disposed.");
            }
        }
    }
}
