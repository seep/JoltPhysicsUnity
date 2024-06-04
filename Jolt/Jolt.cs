using System;

using static Jolt.SafeBindings;

namespace Jolt
{
    public static class Jolt
    {
        public const uint DefaultTempAllocatorSize = 10 * 1024 * 1024; // 10MB

        private static bool initialized;

        /// <summary>
        /// Initialize Jolt, returning true if initialization succeeded.
        /// </summary>
        public static bool Initialize(uint tempAllocatorSize = DefaultTempAllocatorSize)
        {
            if (initialized)
            {
                throw new Exception("Jolt is already initialized.");
            }

            return (initialized = JPH_Init(tempAllocatorSize));
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
