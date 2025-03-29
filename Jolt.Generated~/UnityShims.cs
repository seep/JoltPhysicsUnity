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
    public struct NativeHashSet<T> : System.IDisposable
    {
        public NativeHashSet(int _, Allocator __) { }

        public bool IsCreated => true;

        public void Add(T _) { }

        public bool Contains(T _) => true;

        public void Dispose() { }
    }
}
