using UnityEngine;
using Jolt.Native;

using static Jolt.JoltAPI;

namespace Jolt
{
    internal class JoltAutoInitialization : MonoBehaviour
    {
        private static bool initialized;

        private const uint DefaultTempAllocatorSize = 10 * 1024 * 1024; // 10MB

        [RuntimeInitializeOnLoadMethod]
        public static void Initialize()
        {
            if (initialized) return;

            NativeLibrary.LoadLibrary();

            if (!JPH_Init(DefaultTempAllocatorSize))
            {
                Debug.LogError("JPH_Init failed");
            }

            JPH_SetAssertFailureHandler(OnAssertFailure);

            initialized = true;

            Application.quitting += Shutdown;
        }

        private static void OnAssertFailure(string expr, string message, string file, uint line)
        {
            Debug.Log($"Jolt Assertion Failed:\n{expr}\n{message}\n{file}\n{line}");
        }

        private static void Shutdown()
        {
            JPH_Shutdown();

            initialized = false;
        }
    }
}
