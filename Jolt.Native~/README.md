# Jolt.Native

This folder contains the dotnet solution used to build the native plugins and bindings used in the
package. `jolt` and `joltc` are built with the Vezel Zig Toolset from Nuget. To build from scratch,
first [install ClangSharpPInvokeGenerator as a dotnet tool](https://github.com/dotnet/ClangSharp):

```
dotnet tool install --global ClangSharpPInvokeGenerator
```

then build the project:

```
dotnet build -c Debug
```

or

```
dotnet build -c Release
```
