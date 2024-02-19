using UnityEngine;
using Jolt.Native;

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

            if (!JoltAPI.JPH_Init(DefaultTempAllocatorSize))
            {
                Debug.LogError("JPH_Init failed");
            }

            initialized = true;

            Application.quitting += Shutdown;
        }

        private static void Shutdown()
        {
            JoltAPI.JPH_Shutdown();

            initialized = false;
        }
    }
}
