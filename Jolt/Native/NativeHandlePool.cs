using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Assertions;

namespace Jolt
{
    internal unsafe class NativeHandlePool
    {
        private struct NativeResource
        {
            public uint Version;
            public IntPtr Pointer;
        }

        /// <summary>
        /// The raw resource pointers.
        /// </summary>
        private NativeResource[] resources;

        /// <summary>
        /// The stack of indices that have been disposed and can be reused.
        /// </summary>
        private Stack<uint> disposed = new ();

        /// <summary>
        /// The next never-used index.
        /// </summary>
        private uint nextUnusedIndex;

        public NativeHandlePool(int initialCapacity)
        {
            resources = new NativeResource[initialCapacity];
        }

        /// <summary>
        /// Returns true if the handle is valid and can be converted into a resource pointer. There is no guarantee that the untyped handle is from this pool.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsValidHandle(NativeHandle handle)
        {
            return handle.Version != 0 && resources[handle.Index].Version == handle.Version && resources[handle.Index].Pointer != IntPtr.Zero;
        }

        /// <summary>
        /// Returns true if the handle is valid and can be converted into a resource pointer. There is no guarantee that the handle is from this pool.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsValidHandle<T>(NativeHandle<T> handle) where T : unmanaged
        {
            return handle.Version != 0 && resources[handle.Index].Version == handle.Version && resources[handle.Index].Pointer != IntPtr.Zero;
        }

        private uint TakeNextIndex()
        {
            if (disposed.TryPop(out var index))
            {
                return index;
            }

            nextUnusedIndex += 1;

            return nextUnusedIndex;
        }

        public NativeHandle<T> CreateHandle<T>(T* ptr) where T : unmanaged
        {
            if (ptr == null)
            {
                throw new ArgumentException("The resource pointer cannot be null."); // TODO ifdef safety checks
            }

            var index = TakeNextIndex();

            if (resources.Length <= index)
            {
                // TODO check for overflow

                Array.Resize(ref resources, resources.Length * 2);
            }

            ref var resource = ref resources[index];

            Assert.IsTrue(resource.Pointer == IntPtr.Zero); // assert any previous resource was disposed

            resource.Pointer = (IntPtr) ptr;
            resource.Version = resource.Version + 1;

            return new NativeHandle<T> { Index = index, Version = resource.Version };
        }

        /// <summary>
        /// Create a handle owned by a resource in this pool.
        /// </summary>
        public NativeOwnedHandle<U> CreateOwnedHandle<T, U>(NativeHandle<T> owner, U* ptr) where T : unmanaged where U : unmanaged
        {
            if (!IsValidHandle(owner))
            {
                throw new NullReferenceException("The owner handle is invalid."); // TODO ifdef safety checks
            }

            return new NativeOwnedHandle<U> { Owner = owner.Untyped(), Resource = ptr };
        }

        /// <summary>
        /// Dispose a resource in the pool.Any future attempts to convert the handle to a pointer will throw.
        /// </summary>
        /// <remarks>
        /// This does not actually free any memory represented by the handle; it only marks the handle as invalid and prevents future access through this pool
        /// </remarks>
        public void DisposeHandle<T>(NativeHandle<T> handle) where T : unmanaged
        {
            ref var resource = ref resources[handle.Index];

            if (handle.Version != resource.Version)
            {
                throw new NullReferenceException("The handle is invalid."); // TODO ifdef safety checks
            }

            resource.Pointer = IntPtr.Zero;

            disposed.Push(handle.Index); // make the index available for reuse
        }

        /// <summary>
        /// Convert the handle into a raw pointer. Throws if the resource has been disposed.
        /// </summary>
        public T* GetPointer<T>(NativeHandle<T> handle) where T : unmanaged
        {
            if (handle.Index >= resources.Length)
            {
                throw new NullReferenceException("The handle is invalid."); // TODO ifdef safety checks
            }

            ref var resource = ref resources[handle.Index];

            if (resource.Pointer == null || handle.Version != resource.Version)
            {
                throw new NullReferenceException("The resource has been disposed."); // TODO ifdef safety checks
            }

            return (T*) resource.Pointer;
        }

        /// <summary>
        /// Convert the handle into a raw pointer. Throws if the owning resource has been disposed.
        /// </summary>
        public T* GetOwnedPointer<T>(NativeOwnedHandle<T> handle) where T : unmanaged
        {
            if (!IsValidHandle(handle.Owner))
            {
                throw new NullReferenceException("The owning resource has been disposed."); // TODO ifdef safety checks
            }

            return handle.Resource;
        }
    }
}
