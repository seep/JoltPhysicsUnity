using UnityEngine;

namespace Jolt.Unity
{
    internal static class JoltRuntimeInitialization
    {
        [RuntimeInitializeOnLoadMethod]
        public static void Initialize()
        {
            Jolt.SetAssertFailureHandler(OnAssertFailure);

            if (Jolt.Initialize())
            {
                Application.quitting += static () => Jolt.Shutdown();
            }
            else
            {
                Debug.LogError("Jolt initialization failed.");
            }
        }

        private static bool OnAssertFailure(string expr, string message, string file, uint line)
        {
            Debug.Log($"Jolt Assertion Failed:\n{expr}\n{message}\n{file}\n{line}");
            return false;
        }
    }
}
