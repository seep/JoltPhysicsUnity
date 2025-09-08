using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Scripting;

// Unity quietly strips unreferenced assemblies when compiling for IL2CPP. AlwaysLinkAssembly
// ensures the Jolt.Native initialization code will run even when unreferenced.

[assembly: AlwaysLinkAssembly]

namespace Jolt.Native
{
    public static class NativeLibrary
    {
        #if JOLT_DOUBLE_PRECISION
        public const string JOLT_LIB = "joltc_double";
        #else
        public const string JOLT_LIB = "joltc";
        #endif

        [DllImport("kernel32", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "LoadLibrary")]
        private static extern IntPtr LoadLibraryWindows(string path);

        [DllImport("libc", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "dlopen")]
        private static extern IntPtr LoadLibraryLinux(string path, int flags);

        [DllImport("libdl", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "dlopen")]
        private static extern IntPtr LoadLibraryMacOS(string path, int flags);

        private static IntPtr libptr;

        public static bool IsLoaded => libptr != IntPtr.Zero;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void LoadLibrary()
        {
            try
            {
                MaybeLoadLibrary();
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }

        private static void MaybeLoadLibrary()
        {
            if (libptr != IntPtr.Zero)
            {
                return;
            }

            var libpath = GetLibraryRelativePath();

            #if UNITY_EDITOR
            var paths = EditorLibraryPaths();
            #else
            var paths = RuntimeLibraryPaths();
            #endif

            foreach (var path in paths)
            {
                var combined = Path.Combine(path, libpath);

                if (TryLoadLibrary(combined, out libptr))
                {
                    Debug.Log($"Loaded Jolt library at {path}{Path.DirectorySeparatorChar}{libpath}");
                    break;
                }
            }

            if (libptr == IntPtr.Zero)
            {
                throw new Exception("Failed to load native lib.");
            }
        }

        private static bool TryLoadLibrary(string path, out IntPtr handle)
        {
            handle = IntPtr.Zero;

            if (IsWindows())
            {
                handle = LoadLibraryWindows(path);
            }
            else if (IsLinux())
            {
                handle = LoadLibraryLinux(path, 0x101);
            }
            else if (IsMacOS())
            {
                handle = LoadLibraryMacOS(path, 0x101);
            }

            return handle != IntPtr.Zero;
        }

        private static string GetLibraryRelativePath()
        {
            var arch = RuntimeInformation.ProcessArchitecture;
            var archFolderPrefix = string.Empty;

            if (arch == Architecture.X64)
            {
                archFolderPrefix = "x86_64";
            }
            else if (arch == Architecture.Arm64)
            {
                archFolderPrefix = "aarch64";
            }
            else
            {
                throw new InvalidOperationException($"Unsupported architecture {arch}, unable to load native lib.");
            }

            if (IsWindows())
            {
                return $"{archFolderPrefix}-windows\\{JOLT_LIB}.dll";
            }

            if (IsMacOS())
            {
                return $"{archFolderPrefix}-macos\\{JOLT_LIB}.dll";
            }

            if (IsLinux())
            {
                return $"{archFolderPrefix}-linux\\{JOLT_LIB}.dll";
            }

            throw new InvalidOperationException("Unsupported platform, unable to load native lib.");
        }

        private static bool IsWindows()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }

        private static bool IsLinux()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }

        private static bool IsMacOS()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        }

        private static string[] EditorLibraryPaths()
        {
            const string package = "com.seep.jolt";

            #if JOLT_RELEASE
            const string config = "Release";
            #else
            const string config = "Debug";
            #endif

            return new[]
            {
                Path.GetFullPath($"Packages/{package}/Jolt.Native/{config}")
            };
        }

        private static string[] RuntimeLibraryPaths()
        {
            return new[]
            {
                $"{Application.dataPath}/Plugins/aarch64",
                $"{Application.dataPath}/Plugins/x86_64",
                $"{Application.dataPath}/Plugins"
            };
        }
    }
}
