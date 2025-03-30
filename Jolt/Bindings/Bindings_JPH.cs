using System.Runtime.InteropServices;

namespace Jolt
{
    /// <summary>
    /// A delegate for receiving Jolt traces.
    /// </summary>
    public delegate void TraceHandler(string message);

    /// <summary>
    /// A delegate for receiving Jolt assertion failures.
    /// </summary>
    public delegate bool AssertFailureHandler(string expr, string message, string file, uint line);

    internal static partial class Bindings
    {
        public static bool JPH_Init()
        {
            return UnsafeBindings.JPH_Init();
        }

        public static void JPH_Shutdown()
        {
            UnsafeBindings.JPH_Shutdown();
        }

        public static void JPH_SetTraceHandler(TraceHandler handler)
        {
            UnsafeBindings.JPH_SetTraceHandler(Marshal.GetFunctionPointerForDelegate(handler));
        }

        public static void JPH_SetAssertFailureHandler(AssertFailureHandler handler)
        {
            UnsafeBindings.JPH_SetAssertFailureHandler(Marshal.GetFunctionPointerForDelegate(handler));
        }
    }
}
