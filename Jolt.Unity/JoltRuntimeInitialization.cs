using UnityEngine;

namespace Jolt.Unity
{
    internal static class JoltRuntimeInitialization
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Initialize()
        {
            Jolt.SetAssertFailureHandler(OnAssertFailure);

            if (Jolt.Initialize())
            {
                Application.quitting -= OnApplicationQuit;
                Application.quitting += OnApplicationQuit;
            }
            else
            {
                Debug.LogError("Jolt initialization failed.");
            }
        }

        private static void OnApplicationQuit()
        {
            Jolt.Shutdown();
        }

        private static bool OnAssertFailure(string expr, string message, string file, uint line)
        {
            Debug.Log($"Jolt Assertion Failed:\n{expr}\n{message}\n{file}\n{line}");
            return false;
        }
    }
}
