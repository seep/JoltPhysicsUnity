using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Jolt
{
    internal unsafe struct NativeHandle<T> : IDisposable, IEquatable<NativeHandle<T>> where T : unmanaged
    {
        private NativeSafetyHandle safety;

        private T* ptr;

        public nint RawValue => (nint)ptr;
        
        public NativeHandle(T* ptr)
        {
            #if !JOLT_DISABLE_SAFETY_CHECKS
            safety = NativeSafetyHandle.Create();
            #endif

            this.ptr = ptr;
        }

        /// <summary>
        /// Create a NativeHandle to a new pointer with the same safety handle as this handle. If this handle is disposed of, the owned handle will throw if it is dereferenced.
        /// </summary>
        public NativeHandle<U> CreateOwnedHandle<U>(U* ptr) where U : unmanaged
        {
            #if !JOLT_DISABLE_SAFETY_CHECKS
            return new NativeHandle<U> { ptr = ptr, safety = safety };
            #else
            return new NativeHandle<U> { ptr = ptr };
            #endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly NativeHandle<U> Reinterpret<U>() where U : unmanaged
        {
            #if !JOLT_DISABLE_SAFETY_CHECKS
            return new NativeHandle<U> { ptr = (U*) ptr, safety = safety };
            #else
            return new NativeHandle<U> { ptr = (U*) ptr };
            #endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly T* IntoPointer()
        {
            #if !JOLT_DISABLE_SAFETY_CHECKS
            NativeSafetyHandle.AssertExists(in safety);
            #endif

            return ptr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator T* (NativeHandle<T> handle)
        {
            return handle.IntoPointer();
        }

        #region IDisposable

        public void Dispose()
        {
            #if !JOLT_DISABLE_SAFETY_CHECKS
            NativeSafetyHandle.Release(safety);
            #endif

            ptr = null;
        }

        #endregion

        #region IEquatable

        public bool Equals(NativeHandle<T> other)
        {
            return ptr == other.ptr;
        }

        public override bool Equals(object obj)
        {
            return obj is NativeHandle<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((nint) ptr);
        }

        public static bool operator ==(NativeHandle<T> lhs, NativeHandle<T> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(NativeHandle<T> lhs, NativeHandle<T> rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion
    }
}
