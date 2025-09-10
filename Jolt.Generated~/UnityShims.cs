// Shims for a handful of Unity types that are needed to generate the Jolt wrappers without errors. The implementation
// is irrelevant, we just need the types to be present so that the project can compile.

using System;

namespace Unity.Mathematics
{
    public struct double3
    {
        public double x;
        public double y;
        public double z;
    }

    public struct float2 { }

    public struct float3
    {
        public float x;
        public float y;
        public float z;

        public float3(float _, float __, float ___)
        {
            x = default;
            y = default;
            z = default;
        }
    }

    public struct float4 { }

    public struct float4x4
    {
        public float4x4(float4 _, float4 __, float4 ___, float4 ____)
        {
            
        }
    }

    public struct quaternion { }
}

namespace Unity.Collections
{
    public unsafe struct NativeList<T> : System.IDisposable
    {
        public NativeList(int _, Allocator __) { }

        public int Length => 0;

        public T this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Add(T _) { }

        public void Dispose() { }

        public UnsafeList<T>* GetUnsafeList() => throw new NotImplementedException();
    }

    public struct NativeHashMap<T, U> : System.IDisposable
    {
        public NativeHashMap(int _, Allocator __) { }

        public bool IsCreated => true;

        public void Add(T _, U __) { }

        public bool TryGetValue(T _, out U __)
        {
            __ = default;
            return false;
        }

        public void Dispose() { }
    }

    public struct UnsafeList<T>
    {
        public int Length => 0;

        public int Capacity => 0;

        public void AddNoResize(T _) { }
    }
}
