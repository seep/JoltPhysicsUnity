using System.Collections.Generic;
using Jolt.Native;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace Jolt.Unity
{
    public class JoltEditorSettingsProvider
    {
        private static readonly HashSet<string> keywords = new () { "jolt", "physics" };

        [SettingsProvider]
        public static SettingsProvider CreateJoltSettingsProvider()
        {
            var provider = new SettingsProvider("Project/Jolt Physics", SettingsScope.Project);

            provider.label = "Jolt Physics";
            provider.keywords = keywords;
            provider.guiHandler = GUIHandler;

            return provider;
        }

        private static void GUIHandler(string ctx)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.Toggle("Native Library Found", NativeLibrary.IsLoaded);
            EditorGUI.EndDisabledGroup();

            if (GUILayout.Button("Reload Native Library"))
            {
                NativeLibrary.LoadLibrary();
            }
        }
    }
}

#endif
