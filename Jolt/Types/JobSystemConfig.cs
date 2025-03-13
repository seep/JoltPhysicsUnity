using System.Runtime.InteropServices;

namespace Jolt
{
    [StructLayout(LayoutKind.Sequential), ExpectedStructSize(typeof(JPH_JobSystemConfig))]
    public struct JobSystemConfig
    {
        public nint Context; // TODO replace nint

        public nint QueueJob; // TODO replace nint

        public nint QueueJobs; // TODO replace nint

        public uint MaxConcurrency;

        public uint MaxBarriers;
    }
}
