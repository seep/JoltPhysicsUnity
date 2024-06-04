using System.Runtime.InteropServices;

namespace Jolt
{
    internal static unsafe partial class SafeBindings
    {
        public static bool JPH_Init(uint tempAllocatorSize)
        {
            return Bindings.JPH_Init(tempAllocatorSize);
        }

        public static void JPH_Shutdown()
        {
            Bindings.JPH_Shutdown();
        }

        public static void JPH_SetAssertFailureHandler(AssertFailureHandler handler)
        {
            Bindings.JPH_SetAssertFailureHandler(Marshal.GetFunctionPointerForDelegate(handler));
        }
    }

    /// <summary>
    /// A delegate for receiving Jolt assertion failures.
    /// </summary>
    public delegate void AssertFailureHandler(string expr, string message, string file, uint line);
}
