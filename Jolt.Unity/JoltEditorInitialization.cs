#if UNITY_EDITOR

using UnityEditor;

namespace Jolt.Unity
{
    /// <summary>
    /// Automatically disposes the NativeSafetyHandle context after exiting play mode.
    /// </summary>
    internal static class JoltEditorInitialization
    {
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange change)
        {
            if (change == PlayModeStateChange.EnteredEditMode)
            {
                OnEnteredEditMode();
            }
        }

        private static void OnEnteredEditMode()
        {
            Jolt.Shutdown();
            NativeSafetyHandle.Dispose();
        }
    }
}

#endif
