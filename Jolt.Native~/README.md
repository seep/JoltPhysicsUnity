# Jolt.Native

This folder contains the dotnet solution used to build the native plugins and bindings used in the
package. `jolt` and `joltc` are built with the Vezel Zig Toolset from Nuget. To build from scratch,
first [install ClangSharpPInvokeGenerator as a dotnet tool](https://github.com/dotnet/ClangSharp):

```pwsh
dotnet tool install --global ClangSharpPInvokeGenerator
```

then build the project:

```pwsh
dotnet build -c Debug
```

or

```pwsh
dotnet build -c Release
```

Building the native project will automatically export new C# bindings into `Jolt/Bindings`. To rebuild just the
bindings (after changing `clangsharp.rsp` for example), use:

```pwsh
dotnet build -target:"Generate Jolt Bindings"
```

### Include Files

`build.zig` must be kept up to date with the list of cpp files to include. The list can be obtained with:

```pwsh
Get-ChildItem -Path lib/jolt/Jolt -Recurse -Filter "*.cpp" | Resolve-Path -Relative -RelativeBasePath lib/jolt
````