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

        #if UNITY_EDITOR
        private const bool IsEditor = true;
        #else
        private const bool IsEditor = false;
        #endif

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
            if (IsLoaded)
            {
                return;
            }

            var dir = IsEditor ? GetEditorLibraryFolder() : GetRuntimeLibraryFolder();
            var ext = GetLibraryExtension();

            var libname = $"{JOLT_LIB}.{ext}";
            var libpath = Path.Combine(dir, libname);

            if (TryLoadLibrary(libpath, out libptr))
            {
                Debug.Log($"Loaded Jolt library at {libpath}");
            }
            else
            {
                throw new Exception($"Failed to load native lib from {libpath}");
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

        private static string GetEditorLibraryFolder()
        {
            string arch;

            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
            {
                arch = "x86_64";
            }
            else if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
            {
                arch = "aarch64";
            }
            else
            {
                throw new InvalidOperationException("Unsupported architecture, unable to load native lib.");
            }

            string relpath;

            if (IsWindows())
            {
                relpath = $"{arch}-windows";
            }
            else if (IsMacOS())
            {
                relpath = $"{arch}-macos";
            }
            else if (IsLinux())
            {
                relpath = $"{arch}-linux";
            }
            else
            {
                throw new InvalidOperationException("Unsupported platform, unable to load native lib.");
            }

            const string package = "com.seep.jolt";

            #if JOLT_RELEASE
            const string config = "Release";
            #else
            const string config = "Debug";
            #endif

            return Path.GetFullPath($"Packages\\{package}\\Jolt.Native\\{config}\\{relpath}");
        }

        private static string GetRuntimeLibraryFolder()
        {
            if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
            {
                return $"{Application.dataPath}/Plugins/x86_64";
            }

            if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
            {
                return $"{Application.dataPath}/Plugins/ARM64";
            }

            throw new InvalidOperationException("Unsupported architecture, unable to load native lib.");
        }

        private static string GetLibraryExtension()
        {
            if (IsWindows())
            {
                return "dll";
            }

            if (IsMacOS())
            {
                return "dylib";
            }

            if (IsLinux())
            {
                return "so";
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
    }
}
