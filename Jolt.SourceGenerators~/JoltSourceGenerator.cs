using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jolt.SourceGenerators;

[Generator]
internal class JoltSourceGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext ctx)
    {
        ctx.RegisterForSyntaxNotifications(() => new JoltSyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext ctx)
    {
        if (ctx.SyntaxReceiver is not JoltSyntaxReceiver recv) return;

        var bindings = IngestNativeBindings(recv);
        var wrappers = CreateNativeTypeWrapperList(recv, ctx);

        foreach (var wrapper in wrappers)
        {
            try
            {
                var filename = $"Jolt_{wrapper.TypeName}.g.cs";
                var filetext = GenerateNativeTypeWrapper(wrapper, bindings);

                ctx.AddSource(filename, filetext);
            }
            catch
            {
                continue; // TODO surface error
            }
        }
    }

    /// <summary>
    /// Construct an optimized map of native extern functions from the syntax receiver pass.
    /// </summary>
    private static JoltNativeBindings IngestNativeBindings(JoltSyntaxReceiver recv)
    {
        var bindings = new JoltNativeBindings();

        foreach (var decl in recv.Bindings)
        {
            var parts = decl.Identifier.ValueText.Split('_');

            if (parts.Length < 3) continue; // we are only interested in JPH_SomeType_MethodFoo bindings

            var prefix = $"{parts[0]}_{parts[1]}";
            var method = parts[2];

            var details = new JoltNativeBindingDetails(prefix, method, decl);

            if (bindings.BindingsByNativeType.TryGetValue(prefix, out var value))
            {
                value.Add(details);
            }
            else
            {
                bindings.BindingsByNativeType.Add(prefix, [details]);
            }
        }

        return bindings;
    }

    /// <summary>
    /// Construct a list of native type wrapper metadata from the syntax receiver pass.
    /// </summary>
    private static List<JoltNativeTypeWrapper> CreateNativeTypeWrapperList(JoltSyntaxReceiver recv, GeneratorExecutionContext ctx)
    {
        var result = new List<JoltNativeTypeWrapper>();

        foreach (var decl in recv.Targets)
        {
            result.Add(CreateNativeTypeWrapper(ctx, decl));
        }

        return result;
    }

    private static JoltNativeTypeWrapper CreateNativeTypeWrapper(GeneratorExecutionContext ctx, StructDeclarationSyntax decl)
    {
        var generateBindingsAttributeSymbol = ctx.Compilation.GetTypeByMetadataName("Jolt.GenerateBindingsAttribute");
        var overrideBindingAttributeSymbol = ctx.Compilation.GetTypeByMetadataName("Jolt.OverrideBindingAttribute");

        Debug.Assert(generateBindingsAttributeSymbol != null);

        var symbol = ctx.Compilation.GetSemanticModel(decl.SyntaxTree).GetDeclaredSymbol(decl);
        var result = new JoltNativeTypeWrapper(decl.Identifier.ValueText);

        Debug.Assert(symbol != null);

        foreach (var attr in symbol.GetAttributes())
        {
            if (!generateBindingsAttributeSymbol.Equals(attr.AttributeClass, SymbolEqualityComparer.Default))
            {
                continue;
            }

            if (attr.ConstructorArguments.IsEmpty)
            {
                continue;
            }

            var prefix = attr.ConstructorArguments[0].Value?.ToString();

            result.NativeTypePrefixes.Add(prefix);
        }

        foreach (var member in symbol.GetMembers())
        {
            if (member is IMethodSymbol { DeclaredAccessibility: Accessibility.Public } method)
            {
                foreach (var attr in method.GetAttributes())
                {
                    if (!overrideBindingAttributeSymbol.Equals(attr.AttributeClass, SymbolEqualityComparer.Default))
                    {
                        continue;
                    }

                    if (attr.ConstructorArguments.IsEmpty)
                    {
                        continue;
                    }

                    var excluded = attr.ConstructorArguments[0].Value?.ToString();

                    result.ExcludedBindings.Add(excluded);
                }
            }
        }

        return result;
    }

    private static string GenerateNativeTypeWrapper(JoltNativeTypeWrapper target, JoltNativeBindings bindings)
    {
        var writer = new IndentedTextWriter(new StringWriter());

        writer.WriteLine("using System;");
        writer.WriteLine("using Jolt;");
        writer.WriteLine("using Unity.Mathematics;");
        writer.WriteLine();

        StartBlock(writer, "namespace Jolt");
        StartBlock(writer, $"public partial struct {target.TypeName} : IEquatable<{target.TypeName}>");

        GenerateEquatableInterface(writer, target.TypeName);

        foreach (var prefix in target.NativeTypePrefixes)
        {
            GenerateBindingsWithPrefix(writer, target, bindings, prefix);
        }

        CloseBlock(writer);
        CloseBlock(writer);

        Debug.Assert(writer.Indent == 0);

        return writer.InnerWriter.ToString();
    }

    private static void GenerateEquatableInterface(IndentedTextWriter writer, string type)
    {
        WritePaddedLine(writer, "#region IEquatable");

        WritePaddedLine(writer, $"public bool Equals({type} other) => Handle.Equals(other.Handle);");

        WritePaddedLine(writer, $"public override bool Equals(object obj) => obj is {type} other && Equals(other);");

        WritePaddedLine(writer, "public override int GetHashCode() => Handle.GetHashCode();");

        WritePaddedLine(writer, $"public static bool operator ==({type} lhs, {type} rhs) => lhs.Equals(rhs);");

        WritePaddedLine(writer, $"public static bool operator !=({type} lhs, {type} rhs) => !lhs.Equals(rhs);");

        WritePaddedLine(writer, "#endregion");
    }

    private static void GenerateBindingsWithPrefix(IndentedTextWriter writer, JoltNativeTypeWrapper target, JoltNativeBindings bindings, string prefix)
    {
        if (!bindings.BindingsByNativeType.TryGetValue(prefix, out var bindingsWithPrefix))
        {
            return; // no bindings exist for this prefix
        }

        WritePaddedLine(writer, $"#region {prefix}");

        foreach (var b in bindingsWithPrefix)
        {
            // TODO skip bindings already defined in the wrapper

            if (target.ExcludedBindings.Contains(b.BindingDeclaration.Identifier.ValueText))
            {
                continue; // target has explicitly excluded this binding
            }

            var publicBindingName        = b.BindingMethodName;
            var publicBindingParams      = b.BindingDeclaration.ParameterList.Parameters.RemoveAt(0);
            var publicBindingReturns     = b.BindingDeclaration.ReturnType.ToString();
            var publicBindingModifiers   = publicBindingName == "GetType" ? "new " : "";
            var publicBindingDeclaration = $"public {publicBindingModifiers}{publicBindingReturns} {publicBindingName}({publicBindingParams})";

            var proxiedBindingName = b.BindingDeclaration.Identifier.ValueText;
            var proxiedBindingArgs = new List<string> { "Handle" }; // always pass the handle

            foreach (var param in publicBindingParams)
            {
                proxiedBindingArgs.Add(param.Identifier.ValueText);
            }

            var proxiedBindingArgsString = string.Join(", ", proxiedBindingArgs);
            var proxiedBindingExpression = $"SafeBindings.{proxiedBindingName}({proxiedBindingArgsString});";

            WritePaddedLine(writer, $"{publicBindingDeclaration} => {proxiedBindingExpression}");
        }

        WritePaddedLine(writer, "#endregion");
    }

    private static void StartBlock(IndentedTextWriter writer, string line)
    {
        writer.WriteLine(line);
        writer.WriteLine("{");

        writer.Indent++;
    }

    private static void CloseBlock(IndentedTextWriter writer)
    {
        writer.Indent--;

        writer.WriteLine("}");
    }

    private static void WritePaddedLine(IndentedTextWriter writer, string line)
    {
        writer.WriteLine(line);
        writer.WriteLine();
    }

    private static void Log(string message)
    {
        try
        {
            File.AppendAllText(Path.Combine(@"C:\Users\Chris", "JoltSourceGenerator.log"), $"{message}{Environment.NewLine}");
        }
        catch
        {
            // ignore
        }
    }
}

/// <summary>
/// An optimized lookup of native extern functions.
/// </summary>
internal class JoltNativeBindings
{
    public readonly Dictionary<string, List<JoltNativeBindingDetails>> BindingsByNativeType = new ();
}

/// <summary>
/// Metadata about an individual native extern function we will proxy.
/// </summary>
internal class JoltNativeBindingDetails(string type, string method, MethodDeclarationSyntax decl)
{
    public readonly string NativeTypeName = type;

    public readonly string BindingMethodName = method;

    public readonly MethodDeclarationSyntax BindingDeclaration = decl;
}

/// <summary>
/// Metadata about a native type wrapper we will generate.
/// </summary>
internal class JoltNativeTypeWrapper(string type)
{
    public readonly string TypeName = type;

    public readonly HashSet<string> NativeTypePrefixes = [];

    public readonly HashSet<string> ExcludedBindings = [];
}
