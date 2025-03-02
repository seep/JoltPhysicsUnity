### Modifying the Source Generator

After modifying the source generator, run this command to rebuild and regenerate the wrapper types:

```pwsh
dotnet build Jolt.SourceGenerator~ && dotnet build Jolt.Generated~
```