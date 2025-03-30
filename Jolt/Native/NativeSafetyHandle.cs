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
    public struct NativeSafetyHandle : IEquatable<NativeSafetyHandle>
    {
        private static NativeHashMap<nint, int> indexes;

        private static NativeList<int> versions;

        private static readonly object @lock = new();

        private static bool initialized;

        private int index;
        private int version;

        internal static void Initialize()
        {
            if (initialized)
            {
                return;
            }

            lock (@lock)
            {
                indexes = new(1024, Allocator.Persistent);
                versions = new(1024, Allocator.Persistent);
                initialized = true;
            }
        }

        internal static void Dispose()
        {
            lock (@lock)
            {
                indexes.Dispose();
                versions.Dispose();
                initialized = false;
            }
        }

        /// <summary>
        /// Create (or reuse) a safety handle for a <paramref name="ptr"/>.
        /// </summary>
        public static NativeSafetyHandle Create(nint ptr)
        {
            Initialize();

            lock (@lock)
            {
                if (indexes.TryGetValue(ptr, out var index))
                {
                    // Pointer is already registered. This pattern happens a lot; Body.GetMaterial is a good example.
                    // The material is a single ref counted resource in Jolt, but the binding code can create a lot
                    // of distinct handles to it from different bodies. They should all share the same safety
                    // handle so that destroying the material invalidates all of the handles.
                    return new NativeSafetyHandle { index = index, version = versions[index] };
                }

                index = versions.Length;

                indexes.Add(ptr, index);
                versions.Add(1);

                return new NativeSafetyHandle { index = index, version = 1 };
            }
        }

        /// <summary>
        /// Release a safety handle. A future attempt to assert the handle will throw an exception.
        /// </summary>
        public static void Release(in NativeSafetyHandle handle)
        {
            Initialize();

            lock (@lock)
            {
                if (versions.Length < handle.index)
                {
                    Debug.LogWarning("A NativeSafetyHandle is being released for a handle index that is out of range.");
                    return;
                }

                if (versions[handle.index] != handle.version)
                {
                    Debug.LogWarning("A NativeSafetyHandle is being released for a handle index that was already released.");
                    return;
                }

                versions[handle.index] += 1;
            }
        }

        public static void Assert(in NativeSafetyHandle handle)
        {
            Initialize();

            lock (@lock)
            {
                if (versions.Length < handle.index)
                {
                    // very unexpected situation, this would be a safety handle that survived a domain reload
                    throw new ObjectDisposedException("The native resource has been disposed.");
                }

                if (versions[handle.index] != handle.version)
                {
                    throw new ObjectDisposedException("The native resource has been disposed.");
                }
            }
        }

        #region IEquatable

        public bool Equals(NativeSafetyHandle other)
        {
            return index == other.index && version == other.version;
        }

        public override bool Equals(object obj)
        {
            return obj is NativeSafetyHandle other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(index, version);
        }

        public static bool operator ==(NativeSafetyHandle left, NativeSafetyHandle right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NativeSafetyHandle left, NativeSafetyHandle right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}

#endif
