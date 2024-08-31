using System;

using static Jolt.Bindings;

namespace Jolt
{
    public static class Jolt
    {
        private static bool initialized;

        /// <summary>
        /// Initialize Jolt, returning true if initialization succeeded.
        /// </summary>
        public static bool Initialize()
        {
            if (initialized)
            {
                throw new Exception("Jolt is already initialized.");
            }

            return initialized = JPH_Init();
        }

        /// <summary>
        /// Set the assertion failure handler for Jolt.
        /// </summary>
        public static void SetAssertFailureHandler(AssertFailureHandler handler)
        {
            JPH_SetAssertFailureHandler(handler);
        }

        /// <summary>
        /// Shutdown Jolt.
        /// </summary>
        public static void Shutdown()
        {
            JPH_Shutdown();

            initialized = false;
        }
    }
}
