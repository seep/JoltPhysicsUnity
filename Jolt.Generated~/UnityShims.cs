// Shims for a handful of Unity types that are needed to generate the Jolt wrappers without errors. The implementation
// is irrelevant, we just need the types to be present so that the project can compile.

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
    }

    public struct float4 { }

    public struct float4x4 { }

    public struct quaternion { }
}

namespace Unity.Collections
{
    public struct NativeList<T> : System.IDisposable
    {
        public NativeList(int _, Allocator __) { }

        public int Length => 0;

        public T this[int index]
        {
            get { return default; }
            set { }
        }

        public void Add(T _) { }

        public void Dispose() { }
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
}
