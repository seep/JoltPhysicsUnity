using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jolt.SourceGenerators;

[Generator]
internal class JoltSourceGenerator : ISourceGenerator
{
    private static readonly LogStream Log = new ();
    
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
                Log.Debug($"Generating {wrapper.TypeName}");
                
                var filename = $"{wrapper.TypeName}.g.cs";
                var filetext = GenerateNativeTypeWrapper(wrapper, bindings);

                ctx.AddSource(filename, filetext);
            }
            catch (Exception ex)
            {
                Log.Error($"Exception while generating {wrapper.TypeName}:");
                Log.Error($"{ex}");
            }
        }
        
        Log.Flush();
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

            if (parts.Length < 3)
            {
                continue; // we are only interested in JPH_SomeType_Method bindings
            }

            var details = new JoltNativeBindingDetails($"{parts[0]}_{parts[1]}", decl);

            if (bindings.BindingsByNativeType.TryGetValue(details.NativeTypeName, out var value))
            {
                value.Add(details);
            }
            else
            {
                bindings.BindingsByNativeType.Add(details.NativeTypeName, [details]);
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

        foreach (var decl in recv.Wrappers)
        {
            result.Add(CreateNativeTypeWrapper(ctx, decl));
        }

        return result;
    }

    private static JoltNativeTypeWrapper CreateNativeTypeWrapper(GeneratorExecutionContext ctx, StructDeclarationSyntax decl)
    {
        var symbol = ctx.Compilation.GetSemanticModel(decl.SyntaxTree).GetDeclaredSymbol(decl);
        var result = new JoltNativeTypeWrapper(decl.Identifier.ValueText);

        Debug.Assert(symbol != null);

        foreach (var attr in symbol.GetAttributes())
        {
            if (IsAttributeType(ctx, attr, "Jolt.GenerateHandleAttribute"))
            {
                result.NativeTypeName = attr.ConstructorArguments[0].Value!.ToString();
            }

            if (IsAttributeType(ctx, attr, "Jolt.GenerateBindingsAttribute"))
            {
                foreach (var type in attr.ConstructorArguments[0].Values)
                {
                    result.NativeTypePrefixes.Add(type.Value!.ToString());
                }
            }
        }

        foreach (var member in symbol.GetMembers())
        {
            if (member is IMethodSymbol { DeclaredAccessibility: Accessibility.Public } method)
            {
                foreach (var attr in method.GetAttributes())
                {
                    if (IsAttributeType(ctx, attr, "Jolt.OverrideBindingAttribute"))
                    {
                        Log.Debug($"Excluding {attr.ConstructorArguments[0].Value} from {result.TypeName}");

                        result.ExcludedBindings.Add(attr.ConstructorArguments[0].Value!.ToString());
                    }
                }
            }
        }

        return result;
    }

    private static bool IsAttributeType(GeneratorExecutionContext ctx, AttributeData attr, string type)
    {
        return ctx.Compilation.GetTypeByMetadataName(type)?.Equals(attr.AttributeClass, SymbolEqualityComparer.Default) ?? false;
    }

    private static string GenerateNativeTypeWrapper(JoltNativeTypeWrapper target, JoltNativeBindings bindings)
    {
        var writer = new IndentedTextWriter(new StringWriter());

        writer.WriteLine("using System;");
        writer.WriteLine("using Jolt;");
        writer.WriteLine("using Unity.Mathematics;");
        writer.WriteLine();

        StartBlock(writer, "namespace Jolt");
        StartBlock(writer, $"public readonly partial struct {target.TypeName} : IEquatable<{target.TypeName}>");

        GenerateHandle(writer, target);
        
        GenerateEquatableInterface(writer, target);

        foreach (var prefix in target.NativeTypePrefixes)
        {
            GenerateBindingsWithPrefix(writer, target, bindings, prefix);
        }

        CloseBlock(writer);
        CloseBlock(writer);

        Debug.Assert(writer.Indent == 0);

        return writer.InnerWriter.ToString();
    }

    private static void GenerateHandle(IndentedTextWriter writer, JoltNativeTypeWrapper target)
    {
        WritePaddedLine(writer, $"internal readonly NativeHandle<{target.NativeTypeName}> Handle;");
        
        WritePaddedLine(writer, $"internal {target.TypeName}(NativeHandle<{target.NativeTypeName}> handle) => Handle = handle;");
    }

    private static void GenerateEquatableInterface(IndentedTextWriter writer, JoltNativeTypeWrapper target)
    {
        WritePaddedLine(writer, "#region IEquatable");

        WritePaddedLine(writer, $"public bool Equals({target.TypeName} other) => Handle.Equals(other.Handle);");

        WritePaddedLine(writer, $"public override bool Equals(object obj) => obj is {target.TypeName} other && Equals(other);");

        WritePaddedLine(writer, "public override int GetHashCode() => Handle.GetHashCode();");

        WritePaddedLine(writer, $"public static bool operator ==({target.TypeName} lhs, {target.TypeName} rhs) => lhs.Equals(rhs);");

        WritePaddedLine(writer, $"public static bool operator !=({target.TypeName} lhs, {target.TypeName} rhs) => !lhs.Equals(rhs);");

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
            var internalName = b.BindingDeclaration.Identifier.ValueText;
            var declaredName = internalName.Substring(b.NativeTypeName.Length + 1); // JPH_SomeType_Method => Method

            if (target.ExcludedBindings.Contains(internalName))
            {
                continue; // target has explicitly excluded this binding
            }

            if (b.BindingDeclaration.ParameterList.Parameters.Count == 0)
            {
                continue; // TODO handle generating Create methods
            }

            var internalParams = new List<string>();
            var declaredParams = new List<string>();

            var internalSelfParam = b.BindingDeclaration.ParameterList.Parameters[0];

            if (internalSelfParam.Type!.ToString().StartsWith("NativeHandle") == false)
            {
                continue; // TODO this is the Create category, or generally anything that is not a method binding 
            }
            
            var internalSelfParamNativeType = ExtractGenericHandleType(internalSelfParam.Type!.ToString());

            // Reinterpret the handle if the self param of the binding (ie first parameter) is for a different native
            // type. For example, SphereShape generates bindings for JPH_ConvexShape and JPH_Shape (because the native
            // class is a subclass of these two classes) and so we can safely call these functions on the native
            // JPH_SphereShape handle. JPH_ConvexShape bindings will take a NativeHandle<JPH_ConvexShape> as the
            // first parameter.

            if (internalSelfParamNativeType != target.NativeTypeName)
            {
                internalParams.Add($"Handle.Reinterpret<{internalSelfParamNativeType}>()");
            }
            else
            {
                internalParams.Add("Handle");
            }

            // Build the declared parameters and proxied arguments simultaneously. If any of the proxied arguments are
            // native handles, we use the wrapper type as the parameter type and pass the wrapped handle to the binding.

            foreach (var p in b.BindingDeclaration.ParameterList.Parameters.RemoveAt(0))
            {
                Debug.Assert(p.Type != null);

                var internalParamType = p.Type.ToString();
                var internalParamName = p.Identifier.ValueText;

                string internalParam; // the string we will use for the arg passed to the binding
                string declaredParam; // the string we will use for the arg on the public method

                if (internalParamType.StartsWith("NativeHandle"))
                {
                    var declaredParamType = ExtractGenericHandleType(internalParamType).Substring("JPH_".Length);
                    var declaredParamName = internalParamName;

                    internalParam = $"{internalParamName}.Handle"; // use internal handle 
                    declaredParam = $"{declaredParamType} {declaredParamName}";
                }
                else
                {
                    var declaredParamType = internalParamType; // reuse binding type
                    var declaredParamName = internalParamName;

                    internalParam = internalParamName;
                    declaredParam = $"{declaredParamType} {declaredParamName}";
                    
                    if (p.Modifiers.Any(SyntaxKind.OutKeyword))
                    {
                        internalParam = $"out {internalParam}";
                        declaredParam = $"out {declaredParam}";
                    }
                }
                
                internalParams.Add(internalParam);
                declaredParams.Add(declaredParam);
            }

            var internalParamsString = string.Join(", ", internalParams);
            var declaredParamsString = string.Join(", ", declaredParams);

            // Build the expression by invoking the binding with the args string.

            var expression = $"Bindings.{internalName}({internalParamsString})";

            // If the binding return type is a NativeHandle we derive and return the wrapper type instead.

            var internalReturn = b.BindingDeclaration.ReturnType.ToString();
            var declaredReturn = internalReturn;

            if (declaredReturn.StartsWith("NativeHandle"))
            {
                declaredReturn = ExtractGenericHandleType(declaredReturn).Substring("JPH_".Length);

                expression = $"new {declaredReturn}({expression})";
            }

            // Handle the special case of the JPH_Shape_GetType binding.

            var declaredModifier = (declaredName == "GetType") ? "new " : "";

            // Interpolate the public declaration.

            var declaration = $"public {declaredModifier}{declaredReturn} {declaredName}({declaredParamsString})";

            WritePaddedLine(writer, $"{declaration} => {expression};");
        }

        WritePaddedLine(writer, "#endregion");
    }

    private static string ExtractGenericHandleType(string type)
    {
        var lbracket = type.IndexOf('<');
        var rbracket = type.IndexOf('>');
        return type.Substring(lbracket + 1, rbracket - lbracket - 1);
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
internal class JoltNativeBindingDetails(string type, MethodDeclarationSyntax decl)
{
    public readonly string NativeTypeName = type;

    public readonly MethodDeclarationSyntax BindingDeclaration = decl;
}

/// <summary>
/// Metadata about a native type wrapper we will generate.
/// </summary>
internal class JoltNativeTypeWrapper(string type)
{
    public readonly string TypeName = type;

    public string NativeTypeName;

    public readonly HashSet<string> NativeTypePrefixes = [];

    public readonly HashSet<string> ExcludedBindings = [];
}

/// <summary>
/// Simple log stream that writes to a temp file if possible.
/// </summary>
internal class LogStream
{
    private StreamWriter writer;

    public LogStream()
    {
        var path = Path.Combine(Path.GetTempPath(), "JoltPhysicsUnitySourceGenerator.log");
        
        try
        {
            writer = new StreamWriter(File.Open(path, FileMode.Append, FileAccess.Write));
        }
        catch
        {
            // skip logging
        }
    }

    public void Debug(string message)
    {
        writer?.WriteLine($"[DEBUG {DateTime.Now}] {message}");
    }

    public void Error(string message)
    {
        writer?.WriteLine($"[ERROR {DateTime.Now}] {message}");
    }
    
    public void Flush()
    {
        writer?.Flush();
    }
}
