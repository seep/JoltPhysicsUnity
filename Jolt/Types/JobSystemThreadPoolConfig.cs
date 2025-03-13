using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_JobSystemThreadPoolConfig))]
    public struct JobSystemThreadPoolConfig
    {
        public uint MaxJobs;

        public uint MaxBarriers;

        public int NumThreads;
    }
}
