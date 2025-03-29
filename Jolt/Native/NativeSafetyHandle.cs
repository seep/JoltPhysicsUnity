#if !JOLT_DISABLE_SAFETY_CHECKS

using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

[assembly: InternalsVisibleTo("Jolt.Unity")]
[assembly: InternalsVisibleTo("Jolt.Editor")]

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

        // TODO investigate more sophisticated use-after-free safety checks

        public uint Index;

        private static uint nextHandleIndex;

        private static NativeHashSet<uint> disposed;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        internal static void Initialize()
        {
            if (disposed.IsCreated)
            {
                disposed.Clear();
            }
            else
            {
                disposed = new NativeHashSet<uint>(1024, Allocator.Persistent);
            }
        }

        internal static void TrackHandleLeaks()
        {
            // TODO log about unreleased handles
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NativeSafetyHandle Create()
        {
            return new NativeSafetyHandle { Index = nextHandleIndex++ };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Release(in NativeSafetyHandle handle)
        {
            if (!disposed.IsCreated)
            {
                Initialize();
            }

            if (disposed.Contains(handle.Index))
            {
                Debug.LogWarning("A NativeSafetyHandle is being released for a handle index that was already released.");
            }

            disposed.Add(handle.Index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AssertExists(in NativeSafetyHandle handle)
        {
            if (!disposed.IsCreated)
            {
                Initialize();
            }

            if (disposed.Contains(handle.Index))
            {
                throw new ObjectDisposedException("The native resource has been disposed.");
            }
        }
    }
}

#endif
