using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Scripting;

// Unity quietly strips unreferenced assemblies when compiling for IL2CPP. AlwaysLinkAssembly
// ensures the Jolt.Native initialization code will run even when unreferenced.

[assembly: AlwaysLinkAssembly]

namespace Jolt.Native
{
    // TODO 处理Android 和 IOS
    public static class NativeLibrary
    {
        [DllImport("kernel32", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi,
            EntryPoint = "LoadLibrary")]
        private static extern IntPtr LoadLibraryWindows(string path);

        [DllImport("libc", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi,
            EntryPoint = "dlopen")]
        private static extern IntPtr LoadLibraryLinux(string path, int flags);

        [DllImport("libdl", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi,
            EntryPoint = "dlopen")]
        private static extern IntPtr LoadLibraryMacOS(string path, int flags);

        private static IntPtr libptr;

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

            List<string> libnames = new List<string>();

            if (IsWindows())
            {
                libnames.Add("win-x64/native/joltc.dll");
                libnames.Add("win-arm64/native/joltc.dll");
                libnames.Add("win-x86/native/joltc.dll");
            }
            else if (IsLinux())
            {
                libnames.Add("linux-x64/native/libjoltc.so");
                libnames.Add("linux-arm64/native/libjoltc.so");
            }
            else if (IsMacOS())
            {
                libnames.Add("osx/native/libjoltc.dylib");
                libnames.Add("osx-x64/native/libjoltc.dylib");
                libnames.Add("osx-arm64/native/libjoltc.dylib");
            }
            // else if (IsAndroid())
            // {
            //     libnames.Add("android-arm/native/libjoltc.so");
            //     libnames.Add("android-arm64/native/libjoltc.so");
            //     libnames.Add("android-x64/native/libjoltc.so");
            // }
            // else if (IsIOS())
            // {
            // }
            else
            {
                throw new Exception("Unrecognized platform, unable to load native lib.");
            }

#if UNITY_EDITOR
            var paths = EditorLibraryPaths();
#else
            var paths = RuntimeLibraryPaths();
#endif

            foreach (var path in paths)
            {
                foreach (var libname in libnames)
                {
                    if (TryLoadLibrary(Path.Combine(path, libname), out libptr))
                    {
                        Debug.Log($"Loaded Jolt library at {path}/{libname}");
                        goto ok;
                    }
                }
            }

            ok:
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
            const string config = "Release";

            return new[]
            {
                Path.GetFullPath($"Packages/{package}/Jolt.Native/{config}")
            };
        }

        private static string[] RuntimeLibraryPaths()
        {
            return new[]
            {
                $"{Application.dataPath}/Plugins/x86_64",
                $"{Application.dataPath}/Plugins"
            };
        }
    }
}
