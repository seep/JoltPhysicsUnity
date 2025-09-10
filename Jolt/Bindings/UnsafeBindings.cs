namespace Jolt
{
    internal partial class UnsafeBindings
    {
        #if JOLT_DOUBLE_PRECISION
        private const string JOLT_LIB = "joltc_double";
        #else
        private const string JOLT_LIB = "joltc";
        #endif

    }
}
